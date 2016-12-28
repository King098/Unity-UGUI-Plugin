using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UGUITools
{
	public class ComponentScale : UGUIEventBase {
		[SerializeField]
		private Vector3 normalSclae;
		[SerializeField]
		private Vector3 scaleChangeVec;
		[SerializeField]
		private float duration = 0.2f;

		private Vector3 tempScale;
		private GameObject obj;
		private float timePercent;
		private float curTime;

		public void OnEnable()
		{
			if(eventTarget == null)
			{
				Debug.LogError("there is no target button found!");
				return;
			}
			obj = eventTarget;
//			normalSclae = obj.transform.localScale;
			RigisterEvent (eventType);
		}

		public override void RigisterEvent (EventType type)
		{
			switch(type)
			{
				case EventType.Click:
					Debug.Log("To use press or release event to instead of click event!");
					break;
				case EventType.Press:
				case EventType.Release:
					EventTriggerListener.Get (eventTarget).onPress += OnPress;
					EventTriggerListener.Get (eventTarget).onRelease += OnRelease;
					break;
				case EventType.Hover:
				case EventType.Exit:
					EventTriggerListener.Get (eventTarget).onHover += OnHover;
					EventTriggerListener.Get (eventTarget).onExit += OnExit;
					break;
				case EventType.Scroll:
					//EventTriggerListener.Get (eventTarget).onScroll += OnScroll;
					Debug.Log ("Cannot use scroll event to scale object!");
					break;
				case EventType.Select:
					EventTriggerListener.Get (eventTarget).onSelect += OnSelect;
					break;
				case EventType.Deselect:
					EventTriggerListener.Get (eventTarget).onDeselect += OnDeselect;
					break;
				case EventType.UpdateSelect:
					//EventTriggerListener.Get (eventTarget).onUpdateSelect += OnUpdateSelect;
					Debug.Log ("Cannot use update select event to scale object!");
					break;
				case EventType.Drop:
					//EventTriggerListener.Get (eventTarget).onDrop += OnDrop;
					Debug.Log ("Cannot use drag event to scale object!");
					break;
				case EventType.BeginDrag:
				case EventType.EndDrag:
					EventTriggerListener.Get (eventTarget).onBeginDrag += OnBeginDrag;
					EventTriggerListener.Get (eventTarget).onEndDrag += OnEndDrag;
					break;
				case EventType.Drag:
					//EventTriggerListener.Get (eventTarget).onDrag += OnDrag;
					Debug.Log ("To use begin drag event or end drag event to scale object!");
					break;
				default:break;
			}
		}


		public override void UnRigisterEvent (EventType type)
		{
			switch(type)
			{
				case EventType.Press:
				case EventType.Release:
					EventTriggerListener.Get (eventTarget).onPress -= OnPress;
					EventTriggerListener.Get (eventTarget).onRelease -= OnRelease;
					break;
				case EventType.Hover:
				case EventType.Exit:
					EventTriggerListener.Get (eventTarget).onHover -= OnHover;
					EventTriggerListener.Get (eventTarget).onExit -= OnExit;
					break;
				case EventType.Select:
				case EventType.Deselect:
					EventTriggerListener.Get (eventTarget).onSelect -= OnSelect;
					EventTriggerListener.Get (eventTarget).onDeselect -= OnDeselect;
					break;
				case EventType.BeginDrag:
				case EventType.EndDrag:
					EventTriggerListener.Get (eventTarget).onBeginDrag -= OnBeginDrag;
					EventTriggerListener.Get (eventTarget).onEndDrag -= OnEndDrag;
					break;
				default:break;
			}
		}


		public void OnDisable()
		{
			UnRigisterEvent (eventType);
		}

		public override void GetEvent (GameObject go, EventType type)
		{
			if(go == obj && type == eventType)
			{
				StartCoroutine(PlayScaleChange(normalSclae,scaleChangeVec));
			}
			else
			{
				StopAllCoroutines();
				obj.transform.localScale = normalSclae;
			}
		}

		IEnumerator PlayScaleChange(Vector3 from,Vector3 to)
		{
			tempScale = to - from;	
			curTime = 0f;
			while(curTime < duration)
			{
				curTime += Time.deltaTime;
				tempScale = to - obj.transform.localScale;
				timePercent = curTime / duration;
				obj.transform.localScale += tempScale * timePercent;
				yield return new WaitForEndOfFrame();
			}
		}
	}
}