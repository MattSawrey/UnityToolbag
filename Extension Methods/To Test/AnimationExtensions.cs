using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AnimationExtensions 
{
	public static void SetSpeed(this Animation anim, float newSpeed)
	{
		anim[anim.clip.name].speed = newSpeed; 
	}
}
