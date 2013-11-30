using UnityEngine;
using System.Collections;

public class Player_ship : MonoBehaviour {
	public static float kills;				//Case 1
	public static float shield;				//Case 2
	public static float ammo;				//Case 3
	public static float special1;			//Case 4
	public static float special2;			//Case 5
	public static float coins;				//Case 6
	public static bool isDead;
	public float s_kills;
	public float s_shield;
	public float s_ammo;
	public float s_special1;
	public float s_special2;
	public float s_coins;
	// Use this for initialization
	void Start () {
		kills=0;
		shield=2;
		ammo=20;
		special1=0;
		special2=0;
		coins=0;
	}
	
	// Update is called once per frame
	void Update () {
		s_kills=kills;
		s_shield=shield;
		s_ammo=ammo;
		s_special1=special1;
		s_special2=special2;
		s_coins=coins;
		if(shield==0)
		{
			Kill ();
		}
		else{

		}
	}
	public static void Add(int x, float y)
	{
		switch(x)
		{
		case 1:
			kills=kills+y;
			break;
		case 2:
			shield=shield+y;
			break;
		case 3:
			ammo=ammo+y;
			break;
		case 4:
			special1=special1+y;
			break;
		case 5: 
			special2=special2+y;
			break;
		case 6: 
			coins=coins+y;
			break;
		}
	}
	public static void Sub(int x, int y)
	{
		switch(x)
		{
		case 1:
			kills=kills-y;
			break;
		case 2:
			shield=shield-y;
			break;
		case 3:
			ammo=ammo-y;
			break;
		case 4:
			special1=special1-y;
			break;
		case 5: 
			special2=special2-y;
			break;
		case 6: 
			coins=coins-y;
			break;
		}
	}
	public static void Kill()
	{
		Time.timeScale=0.1f;
		isDead=true;
		game_gui.gui=1;
	}
}
