using UnityEngine;
using System.Collections;

public class game_gui : MonoBehaviour {
	public static int gui;
	public GUISkin skin;
	void Start()
	{
		gui=0;
	}
	void OnGUI()
	{
		if(gui==0)
		{
			GUI.skin = skin;
			GUI.Label(new Rect(10,10,100,50),"Kills: "+Player_ship.kills);
			GUI.Label (new Rect(60,10,100,50),"Bullets left: "+Player_ship.ammo);
			GUI.Label (new Rect(160,10,100,50),"Level: "+LevelSystem.level);
			GUI.Label (new Rect(900,10,100,50),"$: "+Player_ship.coins);
			GUI.Label (new Rect(400,10,100,50),"Score: "+score.finalscore);
			if(Player_ship.shield>=2)
			{
				GUI.color = Color.green;
				GUI.Label (new Rect(10,35,150,50),"Shields are Good!");
			}
			if(Player_ship.shield==1)
			{
				GUI.color=Color.red;
				GUI.Label (new Rect(10,35,150,50),"Shields are Bad!");
			}
			if(Player_ship.special1>0)
			{
				GUI.color=Color.green;
				GUI.Label (new Rect(10,60,200,50),"Special Weapon 1 Loaded.");
			}
			if(Player_ship.special1==0)
			{
				GUI.color=Color.red;
				GUI.Label (new Rect(10,60,200,50),"Special Weapon 1 is empty.");
			}
			if(Player_ship.special2>0)
			{
				GUI.color=Color.green;
				GUI.Label (new Rect(10,85,200,50),"Special Weapon 2 Loaded.");
			}
			if(Player_ship.special2==0)
			{
				GUI.color=Color.red;
				GUI.Label (new Rect(10,85,200,50),"Special Weapon 2 is empty.");
			}
		}
		if(gui==1)
		{
			Time.timeScale=0;
			GUI.Label (new Rect(400,200,200,50),"You Died...but you lasted "+score.finaltime);
			GUI.Label (new Rect(400,250,200,50),"Your Score: "+score.finalscore);
			GUI.Label (new Rect(400,300,200,50),"Retry?");
			if(GUI.Button (new Rect(400,350,100,50),"Yes"))
			{
				score.finalscore=0;
				Application.LoadLevel (1);
			}
			if(GUI.Button (new Rect(500,350,100,50),"No"))
			{
				Application.LoadLevel (3);
			}
		}
	}
}
