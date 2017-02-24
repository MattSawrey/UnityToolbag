using UnityEngine;
using System.Collections;

public class InputManager : Singleton<InputManager>
{
	public delegate void InputControl();
	public static event InputControl moveLeft = delegate {};
	public static event InputControl moveRight = delegate {};
	public static event InputControl moveDown = delegate {};

	void FixedUpdate()
	{
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			moveLeft();
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			moveRight();
		}
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			moveDown();
		}
	}
}
