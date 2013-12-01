using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {
	public float opp;
	public Texture2D Text;
	// Use this for initialization
	void Start () {
		opp=1.0f;
		StartCoroutine("Fader");
	}
	IEnumerator Fader()
	{
		Debug.Log ("Fader Started");
		while(opp>0 )
		{
			opp=opp-0.05f;
			yield return new WaitForSeconds(0.1f);
		}
	}
	void OnGUI()
	{
		GUI.color = new Color(1,1,1,opp);
		GUI.DrawTexture (new Rect(0,0,1024,1024),Text);
		GUI.color = new Color(1.0f,1.0f,1.0f,1);
	}
}
