using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UGUITools
{
	public class ComponentEventBase : UGUIEventBase {

		/// <summary>
		/// realize the event func obj
		/// </summary>
		[SerializeField]
		protected UIBase targetBase;

		/// <summary>
		/// all need to rigistered event
		/// </summary>
		[SerializeField]
		protected List<EventType> events;

		public override void RigisterEvent (EventType type)
		{
			switch(type)
			{
				case EventType.Click:
					EventTriggerListener.Get (this.gameObject).onClick += targetBase.OnClick;
					break;
				case EventType.Press:
					EventTriggerListener.Get (this.gameObject).onPress += targetBase.OnPress;
					break;
				case EventType.Release:
					EventTriggerListener.Get (this.gameObject).onRelease += targetBase.OnRelease;
					break;
				case EventType.Hover:
					EventTriggerListener.Get (this.gameObject).onHover += targetBase.OnHover;
					break;
				case EventType.Exit:
					EventTriggerListener.Get (this.gameObject).onExit += targetBase.OnExit;
					break;
				case EventType.Scroll:
					EventTriggerListener.Get (this.gameObject).onScroll += targetBase.OnScroll;
					break;
				case EventType.Select:
					EventTriggerListener.Get (this.gameObject).onSelect += targetBase.OnSelect;
					break;
				case EventType.Deselect:
					EventTriggerListener.Get (this.gameObject).onDeselect += targetBase.OnDeselect;
					break;
				case EventType.UpdateSelect:
					EventTriggerListener.Get (this.gameObject).onUpdateSelect += targetBase.OnUpdateSelect;
					break;
				case EventType.Drop:
					EventTriggerListener.Get (this.gameObject).onDrop += targetBase.OnDrop;
					break;
				case EventType.BeginDrag:
					EventTriggerListener.Get (this.gameObject).onBeginDrag += targetBase.OnBeginDrag;
					break;
				case EventType.Drag:
					EventTriggerListener.Get (this.gameObject).onDrag += targetBase.OnDrag;
					break;
				case EventType.EndDrag:
					EventTriggerListener.Get (this.gameObject).onEndDrag += targetBase.OnEndDrag;
					break;
				default:break;
			}
		}
		
		public override void UnRigisterEvent (EventType type)
		{
			switch(type)
			{
				case EventType.Click:
					EventTriggerListener.Get (this.gameObject).onClick -= targetBase.OnClick;
					break;
				case EventType.Press:
					EventTriggerListener.Get (this.gameObject).onPress -= targetBase.OnPress;
					break;
				case EventType.Release:
					EventTriggerListener.Get (this.gameObject).onRelease -= targetBase.OnRelease;
					break;
				case EventType.Hover:
					EventTriggerListener.Get (this.gameObject).onHover -= targetBase.OnHover;
					break;
				case EventType.Exit:
					EventTriggerListener.Get (this.gameObject).onExit -= targetBase.OnExit;
					break;
				case EventType.Scroll:
					EventTriggerListener.Get (this.gameObject).onScroll -= targetBase.OnScroll;
					break;
				case EventType.Select:
					EventTriggerListener.Get (this.gameObject).onSelect -= targetBase.OnSelect;
					break;
				case EventType.Deselect:
					EventTriggerListener.Get (this.gameObject).onDeselect -= targetBase.OnDeselect;
					break;
				case EventType.UpdateSelect:
					EventTriggerListener.Get (this.gameObject).onUpdateSelect -= targetBase.OnUpdateSelect;
					break;
				case EventType.Drop:
					EventTriggerListener.Get (this.gameObject).onDrop -= targetBase.OnDrop;
					break;
				case EventType.BeginDrag:
					EventTriggerListener.Get (this.gameObject).onBeginDrag -= targetBase.OnBeginDrag;
					break;
				case EventType.Drag:
					EventTriggerListener.Get (this.gameObject).onDrag -= targetBase.OnDrag;
					break;
				case EventType.EndDrag:
					EventTriggerListener.Get (this.gameObject).onEndDrag -= targetBase.OnEndDrag;
					break;
				default:break;
			}
		}
		
		public override void RigisterEvent ()
		{
			for(int i = 0;i<events.Count;i++)
			{
				RigisterEvent (events[i]);
			}
		}
		
		public override void UnRigisterEvent ()
		{
			for(int i = 0;i<events.Count;i++)
			{
				UnRigisterEvent (events[i]);
			}
		}

		void Awake()
		{
			if(targetBase == null)
			{
				Debug.LogWarning("event target is not aviliable!\nevent target must implment from UGUIEventBase class!");
				return;
			}
		}

		public void OnEnable()
		{
			if(targetBase == null)
			{
				Debug.LogWarning("rigister error!");
				return;
			}
			RigisterEvent ();
		}


		public void OnDisable()
		{
			if(targetBase == null)
			{
				Debug.LogWarning ("unrigister error!");
				return;
			}
			UnRigisterEvent ();
		}
	}
}