using UnityEngine;
using System.Collections;

namespace UGUITools
{
	public class UGUITool {

		public static Camera mainCamera;
		public static AudioSource audioSource;

		public static void PlayUISound(AudioClip clip,float volume = 1f,float pitch = 1f)
		{
			if(clip == null)
				return;
			if(mainCamera == null)
			{
				mainCamera = Camera.main;
			}
			if(audioSource == null)
			{
				audioSource = mainCamera.GetComponent<AudioSource>();
				if(audioSource == null)
				{
					audioSource = mainCamera.gameObject.AddComponent<AudioSource>();
					audioSource.playOnAwake = false;
					audioSource.loop = false;
				}
			}
			//播放声音
			audioSource.PlayOneShot(clip);
		}

		public static void PlayReplaceSound(AudioClip clip,float volum = 1f,float pitch = 1f)
		{
			if(clip == null)
				return;
			if(mainCamera == null)
			{
				mainCamera = Camera.main;
			}
			if(audioSource == null)
			{
				audioSource = mainCamera.GetComponent<AudioSource>();
				if(audioSource == null)
				{
					audioSource = mainCamera.gameObject.AddComponent<AudioSource>();
					audioSource.playOnAwake = false;
					audioSource.loop = false;
				}
			}
			//播放声音
			audioSource.clip = clip;
			audioSource.Play();
		}

	}
}
