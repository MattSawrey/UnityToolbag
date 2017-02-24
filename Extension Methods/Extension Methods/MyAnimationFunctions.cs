using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class MyAnimationFunctions 
{
	public static IEnumerator AnimCurveToPosition(this Transform t, AnimationCurve animCurve,
	                                              float secondsToReachNewPos, Vector3 newPosition)
	{
		Vector3 startPosition = t.transform.position;
		float timer = 0f;
		
		while(t.transform.position != newPosition)
		{
			timer += Time.deltaTime/secondsToReachNewPos;
			
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
		for(int i = 0; i < loopPositions.Length; i++)
		{
			//reset timer
			timer = 0f;
			fromPosition = trans.position;
			while(timer <= 1f)
			{
				trans.position = Vector3.Lerp(fromPosition, loopPositions[i], animCurve.Evaluate(timer));
				timer += Time.deltaTime * (1 / timePerLoop);
				yield return null;              
			}             
		}                 
	}

	public static IEnumerator ApplyShake(this GameObject gameObj, float shakeDuration,
	                                     float shakeIntensity, float shakeSpeedReducer)
	{
		float timer = 0f;
		Vector3 shakeValue = Vector3.zero;
		
		while(timer < shakeDuration)
		{             
			//remove the previous shake value
			gameObj.transform.position -= shakeValue;
			
			//calculate a new shake value and apply it
			shakeValue = new Vector3(Random.Range(-shakeIntensity, shakeIntensity),
			                         Random.Range(-shakeIntensity, shakeIntensity),
			                         Random.Range(-shakeIntensity, shakeIntensity));            
			gameObj.transform.position += shakeValue;
			
			timer += Time.deltaTime;
			yield return new WaitForSeconds(shakeSpeedReducer);
		}
		//correct for any residual shake difference
		gameObj.transform.position -= shakeValue;
		Debug.Log(Time.fixedTime);
	}
			
	public static void SetSpeed(this Animation anim, float newSpeed)
	{
		anim[anim.clip.name].speed = newSpeed; 
	}
}
