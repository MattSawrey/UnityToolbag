using UnityEngine;
using System;
using System.Collections;

public static class MyGroundCheckFunctions
{
	public static bool GroundChecker(this Transform transf, float distanceToCheck)
	{
		var hitColliders = Physics.RaycastAll(transf.position, Vector3.down, distanceToCheck);
		if(hitColliders != null)
			return true;
		else
			return false;
	}
	
	public static bool GroundChecker(this Transform transf, float distanceToCheck, string tagCheck)
	{
		var hitColliders = Physics.RaycastAll(transf.position, Vector3.down, distanceToCheck);
		for(int i = 0; i < hitColliders.Length; i++)
		{
			if(hitColliders[i].transform.tag == tagCheck)
				return true;
		}
		return false;
	}
	
	public static bool GroundChecker(this Transform transf, float distanceToCheck, string[] tagsToCheck)
	{
		var hitColliders = Physics.RaycastAll(transf.position, Vector3.down, distanceToCheck);
		for(int i = 0; i < hitColliders.Length; i++)
		{
			for(int z = 0; z < tagsToCheck.Length; z++)
			{				
				if(hitColliders[i].transform.tag == tagsToCheck[z])
					return true;
			}
		}
		return false;
	}
	
	public static bool GroundChecker2D(this Transform transf, float distanceToCheck)
	{
		var hitColliders = Physics2D.RaycastAll(transf.position, -Vector2.up, distanceToCheck);
		if(hitColliders != null)
			return true;
		else
			return false;
	}
	
	public static bool GroundChecker2D(this Transform transf, float distanceToCheck, string tagCheck)
	{
		var hitColliders = Physics2D.RaycastAll(transf.position, -Vector2.up, distanceToCheck);
		for(int i = 0; i < hitColliders.Length; i++)
		{
			if(hitColliders[i].transform.tag == tagCheck)
				return true;
		}
		return false;
	}
	
	public static bool GroundChecker2D(this Transform transf, float distanceToCheck, string[] tagsToCheck)
	{
		var hitColliders = Physics2D.RaycastAll(transf.position, -Vector2.up, distanceToCheck);
		for(int i = 0; i < hitColliders.Length; i++)
		{
			for(int z = 0; z < tagsToCheck.Length; z++)
			{				
				if(hitColliders[i].transform.tag == tagsToCheck[z])
					return true;
			}
		}
		return false;
	}

	public static Vector3 GroundPosition(this Transform transf, float distanceToCheck, int groundLayerMask)
	{
		var groundHit = new RaycastHit();

		if(Physics.Raycast(transf.position, Vector3.down, out groundHit, distanceToCheck, groundLayerMask))
		{
			return groundHit.point;
		}
		else
		{
			Debug.Log("Ground Not Found!");
			return Vector3.zero;
		}
	}
}
