using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class MyGameObjectFunctions
{
	public static bool HasRigidbody(this GameObject gobj)
	{
		return (gobj.GetComponent<Rigidbody>() != null);
	}
	
	public static bool HasAnimation(this GameObject gobj)
	{
		return (gobj.GetComponent<Animation>() != null);
	}

	public static T[] GetComponentsInChildrenWithTag<T>(this GameObject gameObject, string tag)
		where T: Component
	{
		List<T> results = new List<T>();
		
		if(gameObject.CompareTag(tag))
			results.Add(gameObject.GetComponent<T>());
		
		foreach(Transform t in gameObject.transform)
			results.AddRange(t.gameObject.GetComponentsInChildrenWithTag<T>(tag));
		
		return results.ToArray();
	}
}
