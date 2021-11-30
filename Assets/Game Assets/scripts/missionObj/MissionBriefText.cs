using UnityEngine;

/// Trivial script that fills the label's contents gradually, as if someone was typing.
/// </summary>

[RequireComponent(typeof(UILabel))]
public class MissionBriefText : MonoBehaviour
{
		public int charsPerSecond = 40;

		private UILabel mLabel = null;
		int mOffset = 0;
		float mNextChar = 0f;
		private MainMenu grGlobals;
	
		// Use this for initializatio
		void Awake ()
		{
				grGlobals = GameObject.Find ("MenuManager").GetComponent<MainMenu> ();
		}
	
		void Start ()
		{
				mLabel = GetComponent<UILabel> ();	
				mLabel.supportEncoding = false;
				//mLabel.symbolStyle = UIFont.SymbolStyle.None;
		}
	
		void Update ()
		{
				if (grGlobals.m_playerLoggedIn) {			
						DoTextEffect (grGlobals.m_mBriefText, grGlobals.m_mBriefTextColor);
				}
				//else if(!grGlobals.m_isConnectedtoInternet)
				//{
				//	DoTextEffect("No Network Connection", Color.yellow);
				//}
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