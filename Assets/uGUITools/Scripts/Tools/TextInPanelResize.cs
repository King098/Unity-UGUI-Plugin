using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UGUITools
{
	public class TextInPanelResize : MonoBehaviour {
		public enum ResizeByHV
		{
			/// <summary>
			/// 固定水平，自由垂直
			/// </summary>
			FixH_FreeV = 0,
			/// <summary>
			/// 固定垂直，自由水平
			/// </summary>
			FixV_FreeH = 1,
			/// <summary>
			/// 固定水平垂直比例
			/// </summary>
			FixH_V = 2,
		}

		public float fontWidthTemp;
		public float fontHeightTemp;
		public Text text;
		public float left;
		public float top;
		public float right;
		public float bottom;
		public ResizeByHV resizeType;
		public float H;
		public float V;

		[HideInInspector]
		public RectTransform frame;
		private float charWidht;
		private float charHeight;

		void Awake()
		{
			frame = this.GetComponent<RectTransform> ();
		}

		/// <summary>
		/// 直接设置文字并且自适应
		/// </summary>
		/// <param name="t">传入的文字</param>
		public void ShowText(string t)
		{
			SetPanelSize (t);
		}

		/// <summary>
		/// 根据传入的文字自适应
		/// </summary>
		/// <param name="s">传入的文字</param>
		public void SetPanelSize(string s)
		{
			frame.sizeDelta = CaculatePanelSize (s);
		}

		/// <summary>
		/// 根据目标文字大小自适应外框
		/// </summary>
		public void ResizePanel()
		{
			SetPanelSize (text.text);
		}
		
		Vector2 CaculatePanelSize(string s)
		{
			Vector2 size = Vector2.zero;
			text.text = s;
			charWidht = text.preferredWidth / s.Length + fontWidthTemp;
			charHeight = text.fontSize + fontHeightTemp;
			if(resizeType == ResizeByHV.FixH_FreeV)
			{
				size.x = H;
				//计算一行有多少个字
				int perRowCharNum = (int)((H - left - right)/charWidht);
				//计算现有字数可以生成多少行
				int Colums = (s.Length / perRowCharNum )+(s.Length % perRowCharNum != 0 ? 1 : 0);
				//计算当前总行数的尺寸
				V = Colums * charHeight + top + bottom;
				size.y = V;
			}
			else if(resizeType == ResizeByHV.FixV_FreeH)
			{
				size.y = V;
				//计算一列有多少个字
				int perColumCharNum = (int)((V - top - bottom) / charHeight);
				//计算现有字数可以生成多少列
				int Rows = (s.Length / perColumCharNum) + (s.Length % perColumCharNum != 0 ? 1 : 0);
				//计算当前总列数的尺寸
				H = Rows * charWidht + left + right;
				size.x = H;
			}
			else if(resizeType == ResizeByHV.FixH_V)
			{
				//计算当前宽高比例
				float li = (H - left - right) / (V - top - bottom);
				//计算当前文字实际面积
				float boxArea = charWidht * s.Length * charHeight;
				
				size = CaculateRelativeTextSize(li,boxArea) + new Vector2(left+right,top+bottom);
			}
			return size;
		}

		/// <summary>
		/// 根据比例计算Text宽高
		/// </summary>
		Vector2 CaculateRelativeTextSize(float li,float area)
		{
			Vector2 size = Vector2.zero;
			float heigt_2 = area / li;
			float charHeight_2 = charHeight * charHeight;
			float temp = Mathf.Sqrt (heigt_2 / charHeight_2);
			//计算行数
			int rows = (int)temp + (heigt_2 % charHeight_2 == 0 ? 0 : 1);
			//计算Text高度
			size.y = rows * charHeight;
			//计算Text宽度
			size.x = size.y * li;
			return size;
		}
	}
}