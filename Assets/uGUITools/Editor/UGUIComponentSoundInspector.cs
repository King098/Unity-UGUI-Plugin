using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(UGUITools.ComponentSound))]
public class UGUIComponentSoundInspector : Editor {
	SerializedObject obj;
	SerializedProperty eventTarget;
	SerializedProperty eventType;
	SerializedProperty eventAudioClip;
	SerializedProperty audioVolume;
	SerializedProperty audioPitch;
	SerializedProperty soundType;

	private AudioSource audioSource;

	public void OnEnable()
	{
		obj = new SerializedObject (target);
		eventTarget = obj.FindProperty ("eventTarget");
		eventType = obj.FindProperty("eventType");
		eventAudioClip = obj.FindProperty("eventAudio");
		audioVolume = obj.FindProperty("audioVolume");
		audioPitch = obj.FindProperty("audioPitch");
		soundType = obj.FindProperty("soundType");
	}

	public override void OnInspectorGUI ()
	{
		obj.Update ();

		UGUITools.ComponentSound gobj = target as UGUITools.ComponentSound;

		if(audioSource == null)
		{
			audioSource = gobj.GetComponent<AudioSource> ();
			if(audioSource != null && audioSource.playOnAwake)
			{
				audioSource.playOnAwake = false;
			}
		}

		if(eventTarget.objectReferenceValue == null)
		{
			eventTarget.objectReferenceValue = gobj.gameObject;
		}
		eventTarget.objectReferenceValue = EditorGUILayout.ObjectField("target object:",eventTarget.objectReferenceValue,typeof(GameObject),true);
		eventType.enumValueIndex = System.Convert.ToInt32(EditorGUILayout.EnumPopup("Event Type:",(UGUITools.EventType)eventType.enumValueIndex));
		eventAudioClip.objectReferenceValue = EditorGUILayout.ObjectField ("sound:", eventAudioClip.objectReferenceValue, typeof(AudioClip), false);
		audioVolume.floatValue = EditorGUILayout.Slider ("volume:", audioVolume.floatValue, 0f, 1f);
		audioPitch.floatValue = EditorGUILayout.Slider ("pitch:", audioPitch.floatValue, -3f, 3f);
		EditorGUILayout.PropertyField(soundType,new GUIContent("play sound type:"),true);
		obj.ApplyModifiedProperties ();
	}


    [MenuItem("uGUITools/Components/Component Sound")]
    static void AddCompnonetSound()
    {
        GameObject[] objs = Selection.gameObjects;
        if (objs == null || objs.Length == 0)
        {
            Debug.LogWarning("There is no game object was selected!");
            return;
        }
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].AddComponent<UGUITools.ComponentSound>();
        }
    }
}
