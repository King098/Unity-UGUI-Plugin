using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

namespace UGUITools
{
	public enum SoundPlayType
	{
		CloseOtherPlayThis,
		PlayDirectly
	}

	public class ComponentSound : UGUIEventBase {
		[SerializeField]
		private AudioClip eventAudio;
		[SerializeField]
		private float audioVolume = 1f;
		[SerializeField]
		private float audioPitch = 1f;
		[SerializeField]
		private SoundPlayType soundType;

		private GameObject obj;

		public void OnEnable()
		{
			obj = this.gameObject;
			if(eventTarget == null)
			{
				Debug.LogError("there is no target button found!");
				return;
			}
			RigisterEvent (eventType);
		}

		public void OnDisable()
		{
			UnRigisterEvent (eventType);
		}

		public override void GetEvent (GameObject go, EventType type)
		{
			if(go == obj && type == eventType)
			{
				if(eventAudio == null)
				{
					Debug.LogError("There is no audio clip found!");
					return;
				}
				if(soundType == SoundPlayType.CloseOtherPlayThis)
				{
					UGUITool.PlayReplaceSound(eventAudio,audioVolume,audioPitch);
				}
				else if(soundType == SoundPlayType.PlayDirectly)
				{
					UGUITool.PlayUISound(eventAudio,audioVolume,audioPitch);
				}
			}
		}

		public AudioClip EventAudio
		{
			get
			{
				return eventAudio;
			}
			set
			{
				eventAudio = value;
			}
		}
	}
}