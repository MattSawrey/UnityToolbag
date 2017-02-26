using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class TransformExtensions
{
    public static IEnumerator AnimCurveToPosition(this Transform t, AnimationCurve animCurve,
                                              float secondsToReachNewPos, Vector3 newPosition)
    {
        Vector3 startPosition = t.transform.position;
        float timer = 0f;

        while (t.transform.position != newPosition)
        {
            timer += Time.deltaTime / secondsToReachNewPos;

            t.position = Vector3.Lerp(startPosition, newPosition, animCurve.Evaluate(timer));

            //wait a frame
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public static IEnumerator MultiPositionAnimation(this Transform trans, AnimationCurve animCurve,
                                                     float timeToCompleteLoop, Vector3[] loopPositions)
    {
        float timer = 0f;
        float timePerLoop = timeToCompleteLoop / loopPositions.Length;
        Vector3 fromPosition;

        //Loop through the positions
        for (int i = 0; i < loopPositions.Length; i++)
        {
            //reset timer
            timer = 0f;
            fromPosition = trans.position;
            while (timer <= 1f)
            {
                trans.position = Vector3.Lerp(fromPosition, loopPositions[i], animCurve.Evaluate(timer));
                timer += Time.deltaTime * (1 / timePerLoop);
                yield return null;
            }
        }
    }

    public static void SetObjectHeightToGround(this Transform transF, float heightAboveGroundToSpawn)
	{
		RaycastHit hit;
		LayerMask groundLayer = LayerMask.NameToLayer("Ground");
		
		if(Physics.Raycast(transF.position, -Vector3.up, out hit, 1000f, 1<<groundLayer.value)) 
		{
			transF.SetPositionY(hit.point.y + heightAboveGroundToSpawn);
		}
		else
		{
			Debug.Log("Can't find the ground to set spawn position!");
		}
	}

	//TRANSFORM extension methods
	public static void AddForceToObjectsInRadiusWithTag(this Transform transform, float sphereRadius,
	                                                   float forceFactor, string tag)
	{
		List<Rigidbody> rigidBodies = new List<Rigidbody>();
		float forceValue;
		float distanceFromTransform;
		Vector3 direction;

		//Cast the sphere and collect all the hits within the sphere
		Collider[] hits = Physics.OverlapSphere(transform.position, sphereRadius);

		Debug.Log(hits.Length);

		//Filter through the tags of the hits and then populate the list of relevant rigidbodies
		foreach(Collider r in hits)
		{
			if(r.transform.tag == tag)
			{
				rigidBodies.Add(r.gameObject.GetComponent<Rigidbody>());
			}
		}
			
		//calculate direction and force values
		for(int i = 0; i < rigidBodies.Count; i++)
		{
			//Calc distance to the objects in sphere
			distanceFromTransform = Mathf.Abs(Vector3.Distance(transform.position, rigidBodies[i].transform.position));

			//Calculate how much force to apply
			forceValue = forceFactor * (sphereRadius/distanceFromTransform);

			//Calculate the direction between 2 objects and then normalise it by dividing by distance
			direction = transform.DirectionToObject(rigidBodies[i].gameObject.transform, distanceFromTransform);

			Debug.Log(direction * forceValue);

			//Apply the force to the rigidbody
			rigidBodies[i].AddForce(direction * forceValue);
		}
	}

	public static void ModifyYRotation(this Transform transf, float valueToAdd)
	{
		Vector3 currentRotation = transf.rotation.eulerAngles;
		transf.rotation = Quaternion.Euler(currentRotation + new Vector3(0f, valueToAdd, 0f));
	}

	public static Vector3 DirectionToObject(this Transform t, Transform objectTransform)
	{
		float distanceToObj = Mathf.Abs(Vector3.Distance(t.position, objectTransform.transform.position));
		Vector3 direction = (t.position - objectTransform.transform.position)/distanceToObj;
		return -direction;
	}
	
	public static Vector3 DirectionToObject(this Transform t, Transform objectTransform, float distanceToObject)
	{
		Vector3 direction = (t.position - objectTransform.transform.position)/distanceToObject;
		return -direction;
	}

	public static void SetPosition(this Transform t, float newX, float newY, float newZ)
	{
		t.position = new Vector3(newX, newY, newZ);
	}
	
	public static void SetPositionX(this Transform t, float newX)
	{
		t.position = new Vector3(newX, t.position.y, t.position.z);
	}
	
	public static void SetPositionY(this Transform t, float newY)
	{
		t.position = new Vector3(t.position.x, newY, t.position.z);
	}
	
	public static void SetPositionZ(this Transform t, float newZ)
	{
		t.position = new Vector3(t.position.x, t.position.y, newZ);
	}
	
	public static float GetPositionX(this Transform t)
	{
		return t.position.x;
	}
	
	public static float GetPositionY(this Transform t)
	{
		return t.position.y;
	}
	
	public static float GetPositionZ(this Transform t)
	{
		return t.position.z;
	}
}
