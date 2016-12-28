using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class EventTriggerListener : UnityEngine.EventSystems.EventTrigger{
	public delegate void VoidDelegate (GameObject go);
	public VoidDelegate onClick;
	public VoidDelegate onPress;
	public VoidDelegate onHover;
	public VoidDelegate onExit;
	public VoidDelegate onRelease;
	public VoidDelegate onSelect;
	public VoidDelegate onDeselect;
	public VoidDelegate onUpdateSelect;
	public VoidDelegate onDrop;
	public VoidDelegate onBeginDrag;
	public VoidDelegate onDrag;
	public VoidDelegate onEndDrag;
	public VoidDelegate onScroll;
	
	static public EventTriggerListener Get (GameObject go)
	{
		EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
		if (listener == null) listener = go.AddComponent<EventTriggerListener>();
		return listener;
	}
	public override void OnPointerClick(PointerEventData eventData)
	{
		if(onClick != null) onClick(gameObject);
	}
	public override void OnPointerDown (PointerEventData eventData){
		if(onPress != null) onPress(gameObject);
	}
	public override void OnPointerEnter (PointerEventData eventData){
		if(onHover != null) onHover(gameObject);
	}
	public override void OnPointerExit (PointerEventData eventData){
		if(onExit != null) onExit(gameObject);
	}
	public override void OnPointerUp (PointerEventData eventData){
		if(onRelease != null) onRelease(gameObject);
	}
	public override void OnSelect (BaseEventData eventData){
		if(onSelect != null) onSelect(gameObject);
	}
	public override void OnUpdateSelected (BaseEventData eventData){
		if(onUpdateSelect != null) onUpdateSelect(gameObject);
	}
	public override void OnDrop (PointerEventData eventData)
	{
		if (onDrop != null) onDrop (gameObject);
	}
	public override void OnDeselect (BaseEventData eventData)
	{
		if(onDeselect != null) onDeselect(gameObject);
	}
	public override void OnBeginDrag (PointerEventData eventData)
	{
		if(onBeginDrag != null) onBeginDrag(gameObject);
	}
	public override void OnDrag (PointerEventData eventData)
	{
		if(onDrag != null) onDrag(gameObject);
	}
	public override void OnEndDrag (PointerEventData eventData)
	{
		if(onEndDrag != null) onEndDrag(gameObject);
	}
	public override void OnScroll (PointerEventData eventData)
	{
		if(onScroll != null) onScroll(gameObject);
	}
}


namespace UGUITools
{
	public enum EventType
	{
		None,
		Hover,
		Exit,
		Press,
		Release,
		Click,
		Select,
		Deselect,
		UpdateSelect,
		BeginDrag,
		Drag,
		EndDrag,
		Drop,
		Scroll
	}
}