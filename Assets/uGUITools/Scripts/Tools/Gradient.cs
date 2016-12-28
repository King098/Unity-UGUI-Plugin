using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UGUITools
{
	[AddComponentMenu("UI/Effects/Gradient")]
	public class Gradient : BaseVertexEffect {
		[SerializeField]
		private Color32 topColor = Color.white;
		[SerializeField]
		private Color32 bottomColor = Color.black;
		
		public override void ModifyVertices(List<UIVertex> vertexList) {
			if (!IsActive()) {
				return;
			}
			
			int count = vertexList.Count;
			if(count>0){
				float bottomY = vertexList[0].position.y;
				float topY = vertexList[0].position.y;
				
				for (int i = 1; i < count; i++) {
					float y = vertexList[i].position.y;
					if (y > topY) {
						topY = y;
					}
					else if (y < bottomY) {
						bottomY = y;
					}
				}

				#if !UNITY_5_3
				float uiElementHeight = topY - bottomY;
				
				for (int i = 0; i < count; i++) {
					UIVertex uiVertex = vertexList[i];
					uiVertex.color = Color32.Lerp(bottomColor, topColor, (uiVertex.position.y - bottomY) / uiElementHeight);
					vertexList[i] = uiVertex;
				}
				#elif UNITY_5_3
				List<Color32> colors = new List<Color32> ();
				float uiElementHeight = topY - bottomY;
				for (int i = 0; i < count; i++) {
					colors.Add (Color32.Lerp (bottomColor, topColor, (vertexList [i].y - bottomY) / uiElementHeight));
				}
				mesh.SetColors (colors);
				#endif
			}
		}
	}
}