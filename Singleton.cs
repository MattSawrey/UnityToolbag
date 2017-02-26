using UnityEngine;

/// <summary>
/// Enforces the presence of only a single instance of a Monobehaviour derived class at runtime and allows access to the class through the Instance property
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
	public static T Instance { get; private set; }
	
	protected virtual void Awake()
	{
		if (Instance == null)
		{
			Instance = (T) this;
		}
		else
		{
			Debug.LogError("There is a second instance of the" + this.GetType() + "class");
		}
	}
}