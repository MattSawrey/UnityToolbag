using UnityEditor;
using UnityEngine;

///<summary>
/// Provides base event and position variables needed in multiple custom Editors 
///</summary>
public class EditorBase : Editor
{
    protected Event currentEvent;

    // Positions
    protected Vector2 mouseDownPosition;
    protected Vector2 mouseDraggedPosition;
    protected Vector2 mousePosition;
	protected Vector2 mousePositionReal;
	
	public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
	}

	public virtual void OnSceneGUI()
    {
        currentEvent = Event.current;

        // Get mouse position as world point and snap to grid point
        mousePosition = currentEvent.mousePosition;
        mousePosition = Camera.current.ScreenToWorldPoint(mousePosition);
        mousePosition.y = -mousePosition.y; // Y axis is inverted from Screen to World points. (Annoying)
        mousePosition.y += SceneView.currentDrawingSceneView.camera.transform.position.y * 2;
		
		mousePositionReal = Camera.current.WorldToScreenPoint(mousePosition);
        mousePositionReal = new Vector2(mousePositionReal.x, Camera.current.pixelHeight - mousePositionReal.y); // Invert the Y value

		// Debug.Log(mousePositionReal);

		if (currentEvent.type == EventType.mouseDown && currentEvent.button == 0) // Left-Click
			mouseDownPosition = mousePositionReal;
		if (currentEvent.type == EventType.mouseDrag && currentEvent.button == 0) // Left-Drag
			mouseDraggedPosition = mousePositionReal;
	}
}
