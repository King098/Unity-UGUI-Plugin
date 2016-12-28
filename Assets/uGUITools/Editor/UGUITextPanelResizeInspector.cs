using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;

[CustomEditor(typeof(UGUITools.TextInPanelResize))]
public class UGUITextPanelResizeInspector : Editor {
	SerializedObject obj;
	SerializedProperty frame;
	SerializedProperty targetText;
	SerializedProperty targetFontWidthTemp;
	SerializedProperty targetFontHeightTemp;
	SerializedProperty targetRelativeToParentLeft;
	SerializedProperty targetRelativeToParentTop;
	SerializedProperty targetRelativeToParentRight;
	SerializedProperty targetRelativeToParentBottom;
	SerializedProperty resizeType;
	SerializedProperty parentWidth;
	SerializedProperty parentHeight;

	public void OnEnable()
	{
		obj = new SerializedObject (target);
		frame = obj.FindProperty("frame");
		targetText = obj.FindProperty ("text");
		targetFontWidthTemp = obj.FindProperty ("fontWidthTemp");
		targetFontHeightTemp = obj.FindProperty("fontHeightTemp");
		targetRelativeToParentLeft = obj.FindProperty("left");
		targetRelativeToParentTop = obj.FindProperty ("top");
		targetRelativeToParentRight = obj.FindProperty("right");
		targetRelativeToParentBottom = obj.FindProperty("bottom");
		resizeType = obj.FindProperty ("resizeType");
		parentWidth = obj.FindProperty ("H");
		parentHeight = obj.FindProperty("V");
	}

	public override void OnInspectorGUI ()
	{
		obj.Update ();

		UGUITools.TextInPanelResize gobj = target as UGUITools.TextInPanelResize;

		if(frame.objectReferenceValue == null)
		{
			frame.objectReferenceValue = gobj.GetComponent<RectTransform>();
		}

		targetText.objectReferenceValue = EditorGUILayout.ObjectField ("target text", targetText.objectReferenceValue,typeof(Text),true);
		targetFontWidthTemp.floatValue = EditorGUILayout.FloatField ("text font width border", targetFontWidthTemp.floatValue);
		targetFontHeightTemp.floatValue = EditorGUILayout.FloatField ("text font height border", targetFontHeightTemp.floatValue);

		EditorGUILayout.LabelField("text border of parent:");
		GUILayout.BeginHorizontal ();
		EditorGUILayout.LabelField("top",GUILayout.Width(30f));
		targetRelativeToParentLeft.floatValue = EditorGUILayout.FloatField (targetRelativeToParentLeft.floatValue);
		EditorGUILayout.LabelField("left",GUILayout.Width(30f));
		targetRelativeToParentTop.floatValue = EditorGUILayout.FloatField (targetRelativeToParentTop.floatValue);
		EditorGUILayout.LabelField("right",GUILayout.Width(30f));
		targetRelativeToParentRight.floatValue = EditorGUILayout.FloatField (targetRelativeToParentRight.floatValue);
		EditorGUILayout.LabelField("bottom",GUILayout.Width(45f));
		targetRelativeToParentBottom.floatValue = EditorGUILayout.FloatField (targetRelativeToParentBottom.floatValue);
		GUILayout.EndHorizontal ();

		resizeType.enumValueIndex = System.Convert.ToInt32(EditorGUILayout.EnumPopup("resize type",(UGUITools.TextInPanelResize.ResizeByHV)resizeType.enumValueIndex));

		if(((UGUITools.TextInPanelResize.ResizeByHV)resizeType.enumValueIndex) == (UGUITools.TextInPanelResize.ResizeByHV.FixH_FreeV))
		{
			parentWidth.floatValue = EditorGUILayout.FloatField("rect width",parentWidth.floatValue);
		}
		else if(((UGUITools.TextInPanelResize.ResizeByHV)resizeType.enumValueIndex) == (UGUITools.TextInPanelResize.ResizeByHV.FixV_FreeH))
		{
			parentHeight.floatValue = EditorGUILayout.FloatField("rect height",parentHeight.floatValue);
		}
		else if(((UGUITools.TextInPanelResize.ResizeByHV)resizeType.enumValueIndex) == (UGUITools.TextInPanelResize.ResizeByHV.FixH_V))
		{
			parentWidth.floatValue = EditorGUILayout.FloatField("rect width",parentWidth.floatValue);
			parentHeight.floatValue = EditorGUILayout.FloatField("rect height",parentHeight.floatValue);
		}

		if(GUILayout.Button("Resize"))
		{
			if(targetText.objectReferenceValue == null)
			{
				EditorUtility.DisplayDialog("Error","There is no target text was found!","ok");
			}
			else
			{
				gobj.ResizePanel();
			}
		}

		obj.ApplyModifiedProperties ();
	}
}
