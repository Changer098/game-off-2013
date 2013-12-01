using UnityEngine;
using System.Collections;

public class ExtrasGUI : MonoBehaviour {

	public static int drawfps;
	void Start()
	{

	}
	void OnGUI()
	{
		if(drawfps==1)
		{
			GUI.color = new Color(1,1,1,1);
			Debug.Log ("Drawing");
			//GUI.depth = 2;
			float fps = 1 / Time.smoothDeltaTime;
			GUI.Label (new Rect(0,550,100,50), "Frames Per Second : "+fps.ToString ("#,##0.0"));
		}
		else
		{

		}
	}
}
