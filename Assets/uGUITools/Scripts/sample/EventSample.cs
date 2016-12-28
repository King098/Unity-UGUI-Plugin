using UnityEngine;
using System.Collections;
using UGUITools;

public class EventSample : UIBase {

	public override void OnClick (GameObject go)
	{
		base.OnClick (go);
		Debug.Log ("click " + go.name);
	}

	public override void OnHover (GameObject go)
	{
		base.OnHover (go);
		Debug.Log ("hover " + go.name);
	}

	public override void OnExit (GameObject go)
	{
		base.OnExit (go);
		Debug.Log ("exit " + go.name);
	}
}
