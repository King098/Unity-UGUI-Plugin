using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UGUITools
{
	public class PolygonImage : Image {
		PolygonCollider2D polygoncollider;

		protected override void Awake()
		{
			polygoncollider = GetComponent<PolygonCollider2D>();
		}
		override public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			return ContainsPoint(polygoncollider.points,sp);
		}
		bool ContainsPoint ( Vector2[]polyPoints, Vector2 p) { 
			var j = polyPoints.Length-1; 
			var inside = false; 
			for (int i = 0; i < polyPoints.Length; j = i++) { 
				polyPoints[i].x+=transform.position.x;
				polyPoints[i].y+=transform.position.y;
				if ( ((polyPoints[i].y <= p.y && p.y < polyPoints[j].y) || (polyPoints[j].y <= p.y && p.y < polyPoints[i].y)) && 
				    (p.x < (polyPoints[j].x - polyPoints[i].x) * (p.y - polyPoints[i].y) / (polyPoints[j].y - polyPoints[i].y) + polyPoints[i].x)) 
					inside = !inside; 
			} 
			return inside; 
		}

//		bool ContainsPoint(Vector2[] polyPoints,Vector2 p)
//		{
//			//统计射线和多边形交叉次数
//			int cn = 0;
//			
//			//遍历多边形顶点数组中的每条边
//			for(int i=0; i<polyPoints.Length-1; i++) 
//			{
//				//正常情况下这一步骤可以忽略这里是为了统一坐标系
//				polyPoints [i].x += transform.GetComponent<RectTransform> ().position.x;
//				polyPoints [i].y += transform.GetComponent<RectTransform> ().position.y;
//				
//				//从当前位置发射向上向下两条射线
//				if(((polyPoints [i].y <= p.y) && (polyPoints [i + 1].y > p.y)) 
//				   || ((polyPoints [i].y > p.y) && (polyPoints [i + 1].y <= p.y)))
//				{
//					//compute the actual edge-ray intersect x-coordinate
//					float vt = (float)(p.y - polyPoints [i].y) / (polyPoints [i + 1].y - polyPoints [i].y);
//					
//					//p.x < intersect
//					if(p.x < polyPoints [i].x + vt * (polyPoints [i + 1].x - polyPoints [i].x))
//						++cn;
//				}
//			}
//			
//			//实际测试发现cn为0的情况即为宣雨松算法中存在的问题
//			//所以在这里进行屏蔽直接返回false这样就可以让透明区域不再响应
//			if(cn == 0)
//				return false;
//			
//			//返回true表示在多边形外部否则表示在多边形内部
//			return cn % 2 == 0;
//		}
	}
}