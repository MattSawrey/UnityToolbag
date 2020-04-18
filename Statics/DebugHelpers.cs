using UnityEngine;

public static class DebugHelpers
{
	public static void DebugWithFrameCount(string message)
	{
		Debug.Log("Frame: " + Time.frameCount + ". " + message);
	}
}
