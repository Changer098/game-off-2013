using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public int pause=0;
	public int gui=0;
	void Start()
	{
		Time.timeScale = 1;
	}
	void Update () {
		if(Input.GetKeyDown (KeyCode.Tab))
		{
			pause=1;
		}
		else if(pause==0)
		{
			Time.timeScale=1;
		}
	}
	IEnumerator check()
	{
		while(pause==1)
		{
			if(Input.GetKeyDown (KeyCode.Tab))
			{
				pause=0;
			}
			else
			{

			}
			yield return null;
		}
	}
	void OnGUI ()
	{
		StartCoroutine("check");
		if(gui==0)
		{
			if(pause==1)
			{
				Time.timeScale=0;
				if(GUI.Button (new Rect(400,250,150,75),"Return to Game"))
				{
					Time.timeScale=1;
					pause=0;
				}
				else if(GUI.Button (new Rect(400,335,150,75),"Quit Game"))
				{
					gui=1;
				}
			}
			else{

			}
		}
		else if(gui==1)
		{
			GUI.Box (new Rect(400,200,150,200),"");
			GUI.Label (new Rect(435,200,150,50),"Are you sure?");
			if(GUI.Button (new Rect(400,270,75,75),"Yes"))
			{
				Application.LoadLevel (3);
			}
			else if(GUI.Button (new Rect(480,270,75,75),"No"))
			{
				gui=0;
			}
		}
	}
}
