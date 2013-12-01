using UnityEngine;
using System.Collections;

public class load_gui : MonoBehaviour {
	public Texture2D Text;
	public GUISkin skin;
	void Load()
	{
		Application.LoadLevel (2);
	}
	void OnGUI()
	{
		GUI.skin = skin;
		GUI.DrawTexture (new Rect(0,-425,1024,1024),Text);
		GUI.Label (new Rect(0,565,200,200), "Loading...");
		Load ();
	}
}
