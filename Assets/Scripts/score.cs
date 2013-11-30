using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {
	public static int finalscore;
	public static string finaltime;
	public int time;
	public int kills;
	public int coins;
	float time1;
	// Use this for initialization
	void Awake () {
		finalscore=0;
	}
	
	// Update is called once per frame
	void Update () {
		time1 = Time.time;
		time = Mathf.FloorToInt(time1);
		kills = Mathf.FloorToInt(Player_ship.kills);
		coins = Mathf.FloorToInt(Player_ship.coins);
		finalscore = time + kills + coins*100;
		if(Player_ship.isDead==true)
		{
			CalculateTime ();
		}
	}
	void CalculateTime()
	{
		if(time<60)
		{
			finaltime=time.ToString () + " seconds";
		}
		else
		{
			int min;
			float min1;
			int seconds;
			min1=time/60;
			min=Mathf.FloorToInt (min1);
			seconds=time % 60;

			string mint = min.ToString();
			string sect = seconds.ToString();
			finaltime = mint + ":" + sect;
		}
	}
}
