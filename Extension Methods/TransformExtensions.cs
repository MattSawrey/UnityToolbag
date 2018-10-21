using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public static class TransformExtensions
{
    public static float GetPositionX(this Transform t) { return t.position.x; }
    public static float GetPositionY(this Transform t) { return t.position.y; }
    public static float GetPositionZ(this Transform t) { return t.position.z; }

    public static void SetPositionX(this Transform t, float newX){t.position = new Vector3(newX, t.position.y, t.position.z);}
    public static void SetPositionY(this Transform t, float newY){t.position = new Vector3(t.position.x, newY, t.position.z);}
    public static void SetPositionZ(this Transform t, float newZ){t.position = new Vector3(t.position.x, t.position.y, newZ);}

    public static Vector3 DirectionToObject(this Transform t, Transform objectTransform)
    {
        float distanceToObj = Mathf.Abs(Vector3.Distance(t.position, objectTransform.transform.position));
        Vector3 direction = (t.position - objectTransform.transform.position) / distanceToObj;
        return -direction;
    }

    public static void RotateToFaceObject(this Transform t, Transform objectTransform)
    {
        t.rotation = Quaternion.LookRotation(t.DirectionToObject(objectTransform));
    }

    public static void AddForceToObjectsInRadiusWithTag(this Transform transform, float sphereRadius,
                                                   float forceToAdd, bool reduceForceWithDistance, string tag)
    {
        List<Rigidbody> rigidBodies = new List<Rigidbody>();
        float forceValue;
        float distanceToTransform;
        Vector3 directionToTransform;

        //Populate the list off objects to be affected
        Collider[] hits = Physics.OverlapSphere(transform.position, sphereRadius);
        if (tag != null)
        {
            for (int i = 0; i < hits.Length; i++)
                if (hits[i].transform.tag == tag)
                    if (hits[i].gameObject.HasComponent<Rigidbody>())
                        rigidBodies.Add(hits[i].gameObject.GetComponent<Rigidbody>());
        }
        else
        {
            for (int i = 0; i < hits.Length; i++)
                if(hits[i].gameObject.HasComponent<Rigidbody>())
                    rigidBodies.Add(hits[i].gameObject.GetComponent<Rigidbody>());
        }
        //Remove the base object
        rigidBodies.Remove(transform.GetComponent<Rigidbody>());

        //Calculate everything neccassary to apply the correct force to each object, then apply it
        for (int i = 0; i < rigidBodies.Count; i++)
        {
            distanceToTransform = Mathf.Abs(Vector3.Distance(transform.position, rigidBodies[i].gameObject.transform.position));

            if (reduceForceWithDistance)
                forceValue = forceToAdd * ((sphereRadius - distanceToTransform)/sphereRadius);
            else
                forceValue = forceToAdd;

            directionToTransform = transform.DirectionToObject(rigidBodies[i].gameObject.transform);

            rigidBodies[i].AddForce(directionToTransform * forceValue);
        }
    }

    public static void AddForceToObjectsInRadius(this Transform transform, float sphereRadius, float forceToAdd, bool reduceForceWithDistance)
    {
        AddForceToObjectsInRadiusWithTag(transform, sphereRadius, forceToAdd, reduceForceWithDistance, null);
    }

    //To Test
    public static IEnumerator LerpToPositionByAnimCurve(this Transform t, Vector3 newPosition, AnimationCurve animCurve, float secondsToReachNewPos, bool isLoop) 
    {
        Vector3 startPosition = t.transform.position;
        float timer = 0f;
        bool nextLoop = true;

        while (nextLoop)
        {
            timer = 0f;
            while (t.transform.position != newPosition)
            {
                timer += Time.deltaTime / secondsToReachNewPos;
                t.position = Vector3.Lerp(startPosition, newPosition, animCurve.Evaluate(timer));
                yield return new WaitForSeconds(Time.deltaTime);
            }
            nextLoop = isLoop;
        }
    }

    public static IEnumerator LerpToMultiPositionByAnimCurve(this Transform trans, Vector3[] positions, AnimationCurve animCurve, float timeToCompleteLoop, bool isLoop)
    { 
        float timer = 0f;
        float timePerLoop = timeToCompleteLoop / positions.Length;
        Vector3 fromPosition;
        bool nextLoop = true;

        while (nextLoop)
        {
            timer = 0f;
            for (int i = 0; i < positions.Length; i++)
            {
                timer = 0f;
                fromPosition = trans.position;
                while (timer <= 1f)
                {
                    trans.position = Vector3.Lerp(fromPosition, positions[i], animCurve.Evaluate(timer));
                    timer += Time.deltaTime * (1 / timePerLoop);
                    yield return null;
                }
            }
            nextLoop = isLoop;
        }
    }
}
