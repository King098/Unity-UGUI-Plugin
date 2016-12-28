using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(UGUITools.ComponentEventBase))]
public class UGUIComponentEventBaseInspector : Editor {
	SerializedObject obj;
	SerializedProperty targetBase;
	SerializedProperty events;

	private UGUITools.EventType eventType;

	public void OnEnable()
	{
		obj = new SerializedObject (target);
		targetBase = obj.FindProperty ("targetBase");
		events = obj.FindProperty("events");
	}


	public override void OnInspectorGUI ()
	{
		obj.Update ();

		targetBase.objectReferenceValue = EditorGUILayout.ObjectField ("Event Root:", targetBase.objectReferenceValue, typeof(UGUITools.UIBase), true);

		EditorGUILayout.Space ();

		EditorGUILayout.LabelField ("Event Types:");

		for(int i = 0;i<events.arraySize;i++)
		{
			SerializedProperty element = events.GetArrayElementAtIndex(i);
			GUILayout.BeginHorizontal();
			if(GUILayout.Button("Delete",GUILayout.Width(50f)))
			{
				events.DeleteArrayElementAtIndex(i);
				break;
			}
			EditorGUILayout.LabelField(element.enumNames[element.enumValueIndex]);
			GUILayout.EndHorizontal();
		}

		GUILayout.BeginHorizontal ();
		eventType = (UGUITools.EventType)EditorGUILayout.EnumPopup (eventType);
		if(GUILayout.Button("add new event"))
		{
			events.InsertArrayElementAtIndex(0);
			SerializedProperty element = events.GetArrayElementAtIndex(0);
			element.enumValueIndex = System.Convert.ToInt32(eventType);
		}
		GUILayout.EndHorizontal ();

		obj.ApplyModifiedProperties ();
	}


    [MenuItem("uGUITools/Components/Event Base")]
    static void AddComponentEventBaseToSelect()
    {
        GameObject[] objs = Selection.gameObjects;
        if (objs == null || objs.Length == 0)
        {
            Debug.LogWarning("There is no game object was selected!");
            return;
        }
        for (int i = 0; i < objs.Length; i++)
        {
            UGUITools.ComponentEventBase eventBase = objs[i].GetComponent<UGUITools.ComponentEventBase>();
            if (eventBase == null)
            {
                objs[i].AddComponent<UGUITools.ComponentEventBase>();
            }
        }
    }
}
