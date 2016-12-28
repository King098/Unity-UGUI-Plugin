using UnityEngine;
using System.Collections;

namespace UGUITools
{
	public class UGUIEventBase : MonoBehaviour {
		[SerializeField][HideInInspector]
		protected GameObject eventTarget;
		[SerializeField][HideInInspector]
		protected EventType eventType;

		public virtual void RigisterEvent(EventType type)
		{
			switch(type)
			{
				case EventType.Click:
					EventTriggerListener.Get (eventTarget).onClick += OnClick;
					break;
				case EventType.Press:
					EventTriggerListener.Get (eventTarget).onPress += OnPress;
					break;
				case EventType.Release:
					EventTriggerListener.Get (eventTarget).onRelease += OnRelease;
					break;
				case EventType.Hover:
					EventTriggerListener.Get (eventTarget).onHover += OnHover;
					break;
				case EventType.Exit:
					EventTriggerListener.Get (eventTarget).onExit += OnExit;
					break;
				case EventType.Scroll:
					EventTriggerListener.Get (eventTarget).onScroll += OnScroll;
					break;
				case EventType.Select:
					EventTriggerListener.Get (eventTarget).onSelect += OnSelect;
					break;
				case EventType.Deselect:
					EventTriggerListener.Get (eventTarget).onDeselect += OnDeselect;
					break;
				case EventType.UpdateSelect:
					EventTriggerListener.Get (eventTarget).onUpdateSelect += OnUpdateSelect;
					break;
				case EventType.Drop:
					EventTriggerListener.Get (eventTarget).onDrop += OnDrop;
					break;
				case EventType.BeginDrag:
					EventTriggerListener.Get (eventTarget).onBeginDrag += OnBeginDrag;
					break;
				case EventType.Drag:
					EventTriggerListener.Get (eventTarget).onDrag += OnDrag;
					break;
				case EventType.EndDrag:
					EventTriggerListener.Get (eventTarget).onEndDrag += OnEndDrag;
					break;
				default:break;
			}
		}


		public virtual void UnRigisterEvent(EventType type)
		{
			switch(type)
			{
				case EventType.Click:
					EventTriggerListener.Get (eventTarget).onClick -= OnClick;
					break;
				case EventType.Press:
					EventTriggerListener.Get (eventTarget).onPress -= OnPress;
					break;
				case EventType.Release:
					EventTriggerListener.Get (eventTarget).onRelease -= OnRelease;
					break;
				case EventType.Hover:
					EventTriggerListener.Get (eventTarget).onHover -= OnHover;
					break;
				case EventType.Exit:
					EventTriggerListener.Get (eventTarget).onExit -= OnExit;
					break;
				case EventType.Scroll:
					EventTriggerListener.Get (eventTarget).onScroll -= OnScroll;
					break;
				case EventType.Select:
					EventTriggerListener.Get (eventTarget).onSelect -= OnSelect;
					break;
				case EventType.Deselect:
					EventTriggerListener.Get (eventTarget).onDeselect -= OnDeselect;
					break;
				case EventType.UpdateSelect:
					EventTriggerListener.Get (eventTarget).onUpdateSelect -= OnUpdateSelect;
					break;
				case EventType.Drop:
					EventTriggerListener.Get (eventTarget).onDrop -= OnDrop;
					break;
				case EventType.BeginDrag:
					EventTriggerListener.Get (eventTarget).onBeginDrag -= OnBeginDrag;
					break;
				case EventType.Drag:
					EventTriggerListener.Get (eventTarget).onDrag -= OnDrag;
					break;
				case EventType.EndDrag:
					EventTriggerListener.Get (eventTarget).onEndDrag -= OnEndDrag;
					break;
				default:break;
			}
		}

		public virtual void RigisterEvent()
		{
			EventTriggerListener.Get (eventTarget).onClick += OnClick;
			EventTriggerListener.Get (eventTarget).onPress += OnPress;
			EventTriggerListener.Get (eventTarget).onRelease += OnRelease;
			EventTriggerListener.Get (eventTarget).onHover += OnHover;
			EventTriggerListener.Get (eventTarget).onExit += OnExit;
			EventTriggerListener.Get (eventTarget).onScroll += OnScroll;
			EventTriggerListener.Get (eventTarget).onSelect += OnSelect;
			EventTriggerListener.Get (eventTarget).onDeselect += OnDeselect;
			EventTriggerListener.Get (eventTarget).onUpdateSelect += OnUpdateSelect;
			EventTriggerListener.Get (eventTarget).onDrop += OnDrop;
			EventTriggerListener.Get (eventTarget).onBeginDrag += OnBeginDrag;
			EventTriggerListener.Get (eventTarget).onDrag += OnDrag;
			EventTriggerListener.Get (eventTarget).onEndDrag += OnEndDrag;
		}

		public virtual void UnRigisterEvent()
		{
			EventTriggerListener.Get (eventTarget).onClick -= OnClick;
			EventTriggerListener.Get (eventTarget).onPress = OnPress;
			EventTriggerListener.Get (eventTarget).onRelease -= OnRelease;
			EventTriggerListener.Get (eventTarget).onHover -= OnHover;
			EventTriggerListener.Get (eventTarget).onExit -= OnExit;
			EventTriggerListener.Get (eventTarget).onScroll -= OnScroll;
			EventTriggerListener.Get (eventTarget).onSelect -= OnSelect;
			EventTriggerListener.Get (eventTarget).onDeselect -= OnDeselect;
			EventTriggerListener.Get (eventTarget).onUpdateSelect -= OnUpdateSelect;
			EventTriggerListener.Get (eventTarget).onDrop -= OnDrop;
			EventTriggerListener.Get (eventTarget).onBeginDrag -= OnBeginDrag;
			EventTriggerListener.Get (eventTarget).onDrag -= OnDrag;
			EventTriggerListener.Get (eventTarget).onEndDrag -= OnEndDrag;
		}

		public virtual void OnClick(GameObject go){GetEvent (go, EventType.Click);}
		public virtual void OnPress(GameObject go){GetEvent (go, EventType.Press);}
		public virtual void OnRelease(GameObject go){GetEvent (go, EventType.Release);}
		public virtual void OnHover(GameObject go){GetEvent (go, EventType.Hover);}
		public virtual void OnExit(GameObject go){GetEvent (go, EventType.Exit);}
		public virtual void OnSelect(GameObject go){GetEvent (go, EventType.Select);}
		public virtual void OnDeselect(GameObject go){GetEvent (go, EventType.Deselect);}
		public virtual void OnUpdateSelect(GameObject go){GetEvent (go, EventType.UpdateSelect);}
		public virtual void OnDrop(GameObject go){GetEvent (go, EventType.Drop);}
		public virtual void OnBeginDrag(GameObject go){GetEvent (go, EventType.BeginDrag);}
		public virtual void OnDrag(GameObject go){GetEvent (go, EventType.Drag);}
		public virtual void OnEndDrag(GameObject go){GetEvent (go, EventType.EndDrag);}
		public virtual void OnScroll(GameObject go){GetEvent (go, EventType.Scroll);}


		public virtual void GetEvent(GameObject go,EventType type)
		{

		}

		public EventType GetEventType()
		{
			return eventType;
		}

		public void SetEventType(EventType type)
		{
			eventType = type;
		}
	}
}
