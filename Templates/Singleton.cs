using UnityEngine;

/// <summary>
/// Enforces the presence of only a single instance of a Monobehaviour derived class at runtime and allows access to the class through the Instance property
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance { get; set; }
    public static T Instance {
        get
        {
            if (instance == null)
                instance = FindObjectOfType(typeof(T)) as T;
            return instance;
        }
    }
}