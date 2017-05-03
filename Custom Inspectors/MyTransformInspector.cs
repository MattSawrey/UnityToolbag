using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Transform), true)]
public class MyTransformInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Transform transform = (Transform) target;

        GUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("Zero Position"))
            {
                transform.position = Vector3.zero;
            }
            if (GUILayout.Button("Snap To Int"))
            {
                transform.position = new Vector3(transform.position.x.RoundTo(0), transform.position.y.RoundTo(0), transform.position.z.RoundTo(0));
            }
        }
        GUILayout.EndHorizontal();
    }
}


