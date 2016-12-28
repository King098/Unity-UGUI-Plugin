using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(UGUITools.ComponentScale))]
public class UGUIComponentScaleInspector : Editor {
	SerializedObject obj;
	SerializedProperty eventTarget;
	SerializedProperty eventType;
	SerializedProperty normalVecScale;
	SerializedProperty changeVecScale;
	SerializedProperty scaleChangeDuration;

	string[] enumNames;

	public void OnEnable()
	{
		obj = new SerializedObject (target);
		eventTarget = obj.FindProperty("eventTarget");
		eventType = obj.FindProperty("eventType");
		normalVecScale = obj.FindProperty ("normalSclae");
		changeVecScale = obj.FindProperty ("scaleChangeVec");
		scaleChangeDuration = obj.FindProperty("duration");

		enumNames = eventType.enumNames;
	}


	public override void OnInspectorGUI ()
	{
		obj.Update ();

		UGUITools.ComponentScale gobj = target as UGUITools.ComponentScale;
		
		if(eventTarget.objectReferenceValue == null)
		{
			eventTarget.objectReferenceValue = gobj.gameObject;
		}
		eventTarget.objectReferenceValue = EditorGUILayout.ObjectField("target object:",eventTarget.objectReferenceValue,typeof(GameObject),true);
		scaleChangeDuration.floatValue = EditorGUILayout.FloatField ("duration:", scaleChangeDuration.floatValue);
		if(CheckEventTypeIsAvaliable(gobj))
		{
			eventType.enumValueIndex = System.Convert.ToInt32(EditorGUILayout.EnumPopup("Event Type:",(UGUITools.EventType)eventType.enumValueIndex));
		}
		else
		{
			EditorUtility.DisplayDialog("error","event type is already exist!\nwill set another object event type to none!","ok");
			eventType.enumValueIndex = System.Convert.ToInt32(EditorGUILayout.EnumPopup("Event Type:",(UGUITools.EventType)0));
		}

		switch(enumNames[eventType.enumValueIndex])
		{
			case "Hover":
				normalVecScale.vector3Value = EditorGUILayout.Vector3Field("Exit Scale:",normalVecScale.vector3Value);
				changeVecScale.vector3Value = EditorGUILayout.Vector3Field("Hover Scale:",changeVecScale.vector3Value);
				break;
			case "Exit":
				normalVecScale.vector3Value = EditorGUILayout.Vector3Field("Hover Scale:",normalVecScale.vector3Value);
				changeVecScale.vector3Value = EditorGUILayout.Vector3Field("Exit Scale:",changeVecScale.vector3Value);
				break;
			case "Press":
				normalVecScale.vector3Value = EditorGUILayout.Vector3Field("Release Scale:",normalVecScale.vector3Value);
				changeVecScale.vector3Value = EditorGUILayout.Vector3Field("Press Scale:",changeVecScale.vector3Value);
				break;
			case "Release":
				normalVecScale.vector3Value = EditorGUILayout.Vector3Field("Press Scale:",normalVecScale.vector3Value);
				changeVecScale.vector3Value = EditorGUILayout.Vector3Field("Release Scale:",changeVecScale.vector3Value);
				break;
			case "Select":
				normalVecScale.vector3Value = EditorGUILayout.Vector3Field("Deselect Scale:",normalVecScale.vector3Value);
				changeVecScale.vector3Value = EditorGUILayout.Vector3Field("Select Scale:",changeVecScale.vector3Value);
				break;
			case "Deselect":
				normalVecScale.vector3Value = EditorGUILayout.Vector3Field("Select Scale:",normalVecScale.vector3Value);
				changeVecScale.vector3Value = EditorGUILayout.Vector3Field("Deselect Scale:",changeVecScale.vector3Value);
				break;
			case "BeginDrag":
				normalVecScale.vector3Value = EditorGUILayout.Vector3Field("EndDrag Scale:",normalVecScale.vector3Value);
				changeVecScale.vector3Value = EditorGUILayout.Vector3Field("BeginDrag Scale:",changeVecScale.vector3Value);
				break;
			case "EndDrag":
				normalVecScale.vector3Value = EditorGUILayout.Vector3Field("BeginDrag Scale:",normalVecScale.vector3Value);
				changeVecScale.vector3Value = EditorGUILayout.Vector3Field("EndDrag Scale:",changeVecScale.vector3Value);
				break;
			default:break;
		}
		obj.ApplyModifiedProperties ();
	}


	bool CheckEventTypeIsAvaliable(UGUITools.ComponentScale scale)
	{
		//Check is this event scale has already exist!
		UGUITools.ComponentScale[] scales = scale.GetComponents<UGUITools.ComponentScale> ();
		if (scales.Length <= 1)
			return true;
		for(int i = 0;i<scales.Length;i++)
		{
			if(scales[i].GetInstanceID() == scale.GetInstanceID())
				continue;
			if((scales[i].GetEventType() == UGUITools.EventType.Press || scales[i].GetEventType() == UGUITools.EventType.Release) && (scale.GetEventType() == UGUITools.EventType.Press || scale.GetEventType() == UGUITools.EventType.Release))
			{
				return false;
			}
			else if((scales[i].GetEventType() == UGUITools.EventType.Hover || scales[i].GetEventType() == UGUITools.EventType.Exit) && (scale.GetEventType() == UGUITools.EventType.Hover || scale.GetEventType() == UGUITools.EventType.Exit))
			{
				return false;
			}
			else if((scales[i].GetEventType() == UGUITools.EventType.Select || scales[i].GetEventType() == UGUITools.EventType.Deselect) && (scale.GetEventType() == UGUITools.EventType.Select || scale.GetEventType() == UGUITools.EventType.Deselect))
			{
				return false;
			}
			else if((scales[i].GetEventType() == UGUITools.EventType.BeginDrag || scales[i].GetEventType() == UGUITools.EventType.EndDrag) && (scale.GetEventType() == UGUITools.EventType.BeginDrag || scale.GetEventType() == UGUITools.EventType.EndDrag))
			{
				return false;
			}
		}
		return true;
	}


    [MenuItem("uGUITools/Components/Component Scale")]
    static void AddCompnonetScale()
    {
        GameObject[] objs = Selection.gameObjects;
        if (objs == null || objs.Length == 0)
        {
            Debug.LogWarning("There is no game object was selected!");
            return;
        }
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].AddComponent<UGUITools.ComponentScale>();
        }
    }
}
