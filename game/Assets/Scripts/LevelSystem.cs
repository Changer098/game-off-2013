using UnityEngine;
using System.Collections;

public class LevelSystem : MonoBehaviour {
	public float time;
	public float lasttime;
	public static int level;
	public static int leveluptime;
	public int difficulty;
	public static bool levelup;
	public Texture2D lvlup;

	public static int speedbig;
	public static int speedsmall;
	// Use this for initialization
	void Start () {
		speedbig=300;
		speedsmall=500;
		lasttime=0;
		leveluptime=60;
		level=1;
		difficulty=1;
		StartCoroutine("keeptime");
	}
	
	IEnumerator LevelUp()
	{
		if(Time.timeScale==1)
		{
			levelup=true;
			leveluptime=leveluptime+5;
			if(generator.WaitTime>0.2f)
			{
				generator.WaitTime=generator.WaitTime-0.5f;
				speedbig=speedbig+100;
				speedsmall=speedsmall+100;
			}
			else if(generator.WaitTime==0.2f)
			{

			}
			yield return new WaitForSeconds(1.5f);
			levelup=false;
			level=level+1;
		}
	}
	IEnumerator keeptime()
	{
		Debug.Log ("Keeping Time");
		while(true)
		{
			time=Time.time;
			yield return null;
		}
	}
	void Update () {
		if(time==lasttime+leveluptime || time>lasttime+leveluptime)
		{
			lasttime=time;
			StartCoroutine ("LevelUp");
		}
		else
		{
		}
	}
	void OnGUI()
	{
		if(levelup==true)
		{
			GUI.DrawTexture(new Rect(0,-424,1024,1024),lvlup);
		}
		else
		{

		}
	}
}
