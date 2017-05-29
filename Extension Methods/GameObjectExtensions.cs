using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;

public static class GameObjectExtensions
{
    public static bool HasComponent<T>(this GameObject gameObject) where T : Component
    {
        return (gameObject.GetComponent<T>() != null);
    }

    public static T[] GetComponentsInChildrenWithTag<T>(this GameObject gameObject, string tag)
		where T: Component
	{
		List<T> results = new List<T>();

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject childObject = gameObject.transform.GetChild(i).gameObject;
            if (childObject.CompareTag(tag))
                if (childObject.HasComponent<T>())
                    results.Add(childObject.GetComponent<T>());
        }
		
		return results.ToArray();
	}

    /// <summary>
    /// Tranforms an object's position to give the effect of a shake. Must be called from "StartCoroutine" within a Monobehaviour 
    /// </summary>
    /// <param name="gameObject">the GameObject to be shaken.</param>
    /// <param name="shakeDuration">The duration that the shake should occur for.</param>
    /// <param name="shakeIntensity">The max distance from the origin point the shake can move the object to. Sensible range between 0.01f and 1f.</param>
    /// <param name="shakeSpeed">The frequency with which a new position is assigned. Use Time.Deltatime for new shake position every frame.</param>
    /// <returns></returns>
    public static IEnumerator ApplyShake3D(this GameObject gameObject, float shakeDuration,
                                     float shakeIntensity, float shakeSpeed)
    {
        float timer = 0f;
        Vector3 shakeValue = Vector3.zero;

        while (timer < shakeDuration)
        {
            //remove the previous shake value
            gameObject.transform.position -= shakeValue;

            //calculate a new shake value and apply it
            shakeValue = new Vector3(Random.Range(-shakeIntensity, shakeIntensity),
                                     Random.Range(-shakeIntensity, shakeIntensity),
                                     Random.Range(-shakeIntensity, shakeIntensity));
            gameObject.transform.position += shakeValue;

            timer += Time.deltaTime;
            yield return new WaitForSeconds(shakeSpeed);
        }
        //correct for any residual shake difference
        gameObject.transform.position -= shakeValue;
    }

    public static IEnumerator ApplyShake2D(this GameObject gameObject, float shakeDuration,
                                     float shakeIntensity, float shakeSpeed)
    {
        float timer = 0f;
        Vector2 shakeValue = Vector2.zero;
        Vector3 startPosition = gameObject.transform.position;
        float gObjectZPos = gameObject.transform.position.z;

        while (timer < shakeDuration)
        {
            gameObject.transform.position -= shakeValue.ToVector3(gObjectZPos);

            shakeValue = new Vector2(Random.Range(-shakeIntensity, shakeIntensity),
                                     Random.Range(-shakeIntensity, shakeIntensity));
            gameObject.transform.position += shakeValue.ToVector3(gObjectZPos);

            timer += Time.deltaTime;
            yield return new WaitForSeconds(shakeSpeed);
        }
        gameObject.transform.position = startPosition;
    }
}
