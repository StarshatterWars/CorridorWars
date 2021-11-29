using UnityEngine;

/// <summary>
/// Trivial script that fills the label's contents gradually, as if someone was typing.
/// </summary>

[RequireComponent(typeof(UILabel))]
public class csMissionTitle : MonoBehaviour
{
		public int charsPerSecond = 40;

		public UILabel mLabel = null;
		int mOffset = 0;
		float mNextChar = 0f;
		private Color mtColor = Color.clear;
		private string mtText = string.Empty;
		private csRangerWars grGlobals;
		// Use this for initialization
	
		void Awake ()
		{
				grGlobals = GameObject.Find ("MainGame").GetComponent<csRangerWars> ();
		}
	
		void Start ()
		{
				mLabel = GetComponent<UILabel> ();	
				mLabel.supportEncoding = false;
				//mLabel.symbolStyle = UIFont.SymbolStyle.None;
		}
	
		void Update ()
		{		
				mLabel.text = grGlobals.m_missionTitle;
				mLabel.color = grGlobals.m_missionTitleColor;
		}
	
		private void DoTextEffect (string mText, Color mColor)
		{
				mLabel.text = mText;
				mLabel.color = mColor;
				if (mLabel == null) {
						Vector2 scale = mLabel.cachedTransform.localScale;
						//mLabel.font.WrapText(mLabel.text, out mText, mLabel.lineWidth / scale.x, mLabel.lineHeight / scale.y, mLabel.maxLineCount, false, UIFont.SymbolStyle.None);
				}

				if (mOffset < mText.Length) {
						if (mNextChar <= Time.time) {
								charsPerSecond = Mathf.Max (1, charsPerSecond);

								// Periods and end-of-line characters should pause for a longer time.
								float delay = 1f / charsPerSecond;
								char c = mText [mOffset];
								if (c == '.' || c == '\n' || c == '!' || c == '?')
										delay *= 4f;

								mNextChar = Time.time + delay;
								mLabel.text = mText.Substring (0, ++mOffset);
						}
				} else
						Destroy (this);
		}
}