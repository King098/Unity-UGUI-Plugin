using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[AddComponentMenu("UI/Effects/Text Color Effect")]
public class TextColorEffect : BaseVertexEffect
{
    [SerializeField]
    private Color32 leftTopColor = Color.white;
    [SerializeField]
    private Color32 rightTopColor = Color.black;
    [SerializeField]
    private Color32 leftBottomColor = Color.black;
    [SerializeField]
    private Color32 rightBottomColor = Color.black;

    public override void ModifyVertices(List<UIVertex> vertexList)
    {
        if (!IsActive())
        {
            return;
        }

        for (int i = 0; i < vertexList.Count; )
        {
            ChangeColor(ref vertexList, i, leftTopColor);
            ChangeColor(ref vertexList, i + 1, rightTopColor);
            ChangeColor(ref vertexList, i + 2, rightBottomColor);
            ChangeColor(ref vertexList, i + 3, leftBottomColor);
            i += 4;
        }

    }
    private void ChangeColor(ref List<UIVertex> verList, int index, Color color)
    {
        UIVertex temp = verList[index];
        temp.color = color;
        verList[index] = temp;
    }
}