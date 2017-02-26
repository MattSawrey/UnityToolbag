using UnityEngine;
using System.Collections.Generic;
using System.Collections;

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

    //public static IEnumerator ApplyShake(this GameObject gameObj, float shakeDuration,
    //                                 float shakeIntensity, float shakeSpeedReducer)
    //{
    //    float timer = 0f;
    //    Vector3 shakeValue = Vector3.zero;

    //    while (timer < shakeDuration)
    //    {
    //        //remove the previous shake value
    //        gameObj.transform.position -= shakeValue;

    //        //calculate a new shake value and apply it
    //        shakeValue = new Vector3(Random.Range(-shakeIntensity, shakeIntensity),
    //                                 Random.Range(-shakeIntensity, shakeIntensity),
    //                                 Random.Range(-shakeIntensity, shakeIntensity));
    //        gameObj.transform.position += shakeValue;

    //        timer += Time.deltaTime;
    //        yield return new WaitForSeconds(shakeSpeedReducer);
    //    }
    //    //correct for any residual shake difference
    //    gameObj.transform.position -= shakeValue;
    //    Debug.Log(Time.fixedTime);
    //}
}
