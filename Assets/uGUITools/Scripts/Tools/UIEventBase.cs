using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UGUITools
{
	public class UIEventBase : UGUIEventBase {
		/// <summary>
		/// all need to rigistered UI paramters
		/// </summary>
		[SerializeField]
		protected List<GameObject> uGUIParamters;

		/// <summary>
		/// all need to rigistered event
		/// </summary>
		[SerializeField]
		protected List<EventType> events;

		public override void RigisterEvent (EventType type)
		{
			for(int i = 0;i<uGUIParamters.Count;i++)
			{
				switch(type)
				{
					case EventType.Click:
						EventTriggerListener.Get (uGUIParamters[i]).onClick += OnClick;
						break;
					case EventType.Press:
						EventTriggerListener.Get (uGUIParamters[i]).onPress += OnPress;
						break;
					case EventType.Release:
						EventTriggerListener.Get (uGUIParamters[i]).onRelease += OnRelease;
						break;
					case EventType.Hover:
						EventTriggerListener.Get (uGUIParamters[i]).onHover += OnHover;
						break;
					case EventType.Exit:
						EventTriggerListener.Get (uGUIParamters[i]).onExit += OnExit;
						break;
					case EventType.Scroll:
						EventTriggerListener.Get (uGUIParamters[i]).onScroll += OnScroll;
						break;
					case EventType.Select:
						EventTriggerListener.Get (uGUIParamters[i]).onSelect += OnSelect;
						break;
					case EventType.Deselect:
						EventTriggerListener.Get (uGUIParamters[i]).onDeselect += OnDeselect;
						break;
					case EventType.UpdateSelect:
						EventTriggerListener.Get (uGUIParamters[i]).onUpdateSelect += OnUpdateSelect;
						break;
					case EventType.Drop:
						EventTriggerListener.Get (uGUIParamters[i]).onDrop += OnDrop;
						break;
					case EventType.BeginDrag:
						EventTriggerListener.Get (uGUIParamters[i]).onBeginDrag += OnBeginDrag;
						break;
					case EventType.Drag:
						EventTriggerListener.Get (uGUIParamters[i]).onDrag += OnDrag;
						break;
					case EventType.EndDrag:
						EventTriggerListener.Get (uGUIParamters[i]).onEndDrag += OnEndDrag;
						break;
					default:break;
				}
			}
		}

		public override void UnRigisterEvent (EventType type)
		{
			for(int i = 0;i<uGUIParamters.Count;i++)
			{
				switch(type)
				{
					case EventType.Click:
						EventTriggerListener.Get (uGUIParamters[i]).onClick -= OnClick;
						break;
					case EventType.Press:
						EventTriggerListener.Get (uGUIParamters[i]).onPress -= OnPress;
						break;
					case EventType.Release:
						EventTriggerListener.Get (uGUIParamters[i]).onRelease -= OnRelease;
						break;
					case EventType.Hover:
						EventTriggerListener.Get (uGUIParamters[i]).onHover -= OnHover;
						break;
					case EventType.Exit:
						EventTriggerListener.Get (uGUIParamters[i]).onExit -= OnExit;
						break;
					case EventType.Scroll:
						EventTriggerListener.Get (uGUIParamters[i]).onScroll -= OnScroll;
						break;
					case EventType.Select:
						EventTriggerListener.Get (uGUIParamters[i]).onSelect -= OnSelect;
						break;
					case EventType.Deselect:
						EventTriggerListener.Get (uGUIParamters[i]).onDeselect -= OnDeselect;
						break;
					case EventType.UpdateSelect:
						EventTriggerListener.Get (uGUIParamters[i]).onUpdateSelect -= OnUpdateSelect;
						break;
					case EventType.Drop:
						EventTriggerListener.Get (uGUIParamters[i]).onDrop -= OnDrop;
						break;
					case EventType.BeginDrag:
						EventTriggerListener.Get (uGUIParamters[i]).onBeginDrag -= OnBeginDrag;
						break;
					case EventType.Drag:
						EventTriggerListener.Get (uGUIParamters[i]).onDrag -= OnDrag;
						break;
					case EventType.EndDrag:
						EventTriggerListener.Get (uGUIParamters[i]).onEndDrag -= OnEndDrag;
						break;
					default:break;
				}
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

		public void OnEnable()
		{
			RigisterEvent ();
		}

		public void OnDisable()
		{
			UnRigisterEvent ();
		}
	}
}