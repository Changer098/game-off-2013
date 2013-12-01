using UnityEngine;
using System.Collections;

public class mm_gui : MonoBehaviour {
	bool gui;
	int gui_id=0;
	bool debug;
	public bool transition=false;
	public bool transition2=false;
	public int t1c=0;
	public int t1=-1450;
	int t1_btn1=300;
	int t1_btn2=420;
	public int t2c=0;
	public int t2=0;
	public string check;
	public int t2_btn1=330;
	public int t2_btn2=485;
	public int screen_width;
	public int screen_height;
	public Texture2D star_trails;
	public Texture2D changer098;
	public GUISkin skin;
	Vector2 scrollposition;
	void Start () {
		screen_width=Screen.width;
		screen_height=Screen.height;
		Debug.Log ("Current height is: "+Screen.currentResolution.height);
		Debug.Log ("Current width is: "+Screen.currentResolution.width);
		gui=true;
	}
	IEnumerator TransitionUp()
	{
		//Debug.Log ("Transition started!");
		if(t1==-850)
		{
			transition=false;
			Debug.Log ("Transition Done!");
		}
		else if(t1<-850)
		{
			transition=true;
			t1=t1+2;
			t1_btn1=t1_btn1+2;
			t1_btn2=t1_btn2+2;
			yield return new WaitForEndOfFrame();
		}
	}
	IEnumerator TransitionRight()
	{
		//Debug.Log ("Transition started!");
		if(t2==-895 || t2<-895)
		{
			transition2=false;
			t2c=0;
			Debug.Log ("Transition Done!");
		}
		else if(t2<1)
		{
			transition2=true;
			t2=t2-4;
			t2_btn1=t2_btn1-4;
			t2_btn2=t2_btn2-4;
			yield return new WaitForEndOfFrame();
		}
		else{
			Debug.LogError ("Conditions not met.");
			transition2=false;
		}
	}
	void Check(int obj)
	{
		if(obj==1)
		{
			if(t1c==0)
			{
				transition=true;
				t1c=1;
				return;
			}
			if(t1c==1)
			{
				return;
			}
		}
		else if(obj==2)
		{
			if(t2_btn1==330 || t2_btn1!=-630)
			{
				transition2=true;
				t2c=1;
				Debug.Log ("t2c now equals one.");
				check="go";
			}
			else if(t2_btn1==-630)
			{
				transition2=false;
				t2c=0;
				Debug.Log ("Transition should be over.");
				check="no";
			}
		}
		else
		{
			return;
		}
	}
	void OnGUI()
	{
		GUI.skin = skin;
		if(gui=true && gui_id==0)
		{
			GUI.DrawTexture (new Rect(0,-1450,2048,2048), star_trails);
			if (GUI.Button (new Rect (330,300,300,100), "Play Game")) {
				Debug.Log ("Clicked Play");
				gui_id=1;
			}
			else if (GUI.Button (new Rect (330,420,145,100), "Settings")) {
				Debug.Log ("Clicked Settings");
				gui_id=2;
			}
			else if (GUI.Button (new Rect (485,420,145,100), "About")) {
				Debug.Log ("Clicked About");
				gui_id=3;
			}
		}
		else if(gui=true && gui_id==1)
		{
			Check(1);
			if(transition==true)
			{
				StartCoroutine("TransitionUp");
				GUI.DrawTexture (new Rect(0,t1,2048,2048), star_trails);	//t_1 equals transition value
				GUI.Button (new Rect (330,t1_btn1,300,100), "Play Game");
				GUI.Button (new Rect (330,t1_btn2,145,100), "Settings");
				GUI.Button (new Rect (485,t1_btn2,145,100), "About");
			}
			else if(transition==false)
			{
				GUI.DrawTexture (new Rect(0,-850,2048,2048), star_trails);
				scrollposition = GUI.BeginScrollView (new Rect(300,100,400,275),scrollposition,new Rect(0,0,380,250));
				GUI.Label (new Rect(150,0,270,35), "Your Objective");
				GUI.Label (new Rect(0,20,400,75), "You must collect as many coins as possible. To do this, you will need to upgrade weapons and boost shields in order to survive the asteriod field.");
				GUI.Label (new Rect(145,70,200,35), "How to navigate");
				GUI.Label (new Rect(0,85,400,75), "Use A to make the ship move to the left, or use the left arrow key. Use D, or the right arrow key, to make the ship move to the right. Use the space bar to fire bullets. Use Z to fire Special Weapon 1. Use X to fire Special Weapon 2.");
				GUI.Label (new Rect(139,145,200,35), "The Asteroid Field");
				GUI.Label (new Rect(0,160,400,75), "The Asteroid Field is ever-growing in size and accelerates faster as your ship travels through. This field has no known end, and it is your mission to find the origin of the rocks.");
				GUI.EndScrollView();
				if(GUI.Button (new Rect (330,400,300,100), "Play"))
				{
					Application.LoadLevel (1);
				}
			}
		}
		else if(gui=true && gui_id==2)
		{
			Check (2);
			if(check=="go")
			{
				StartCoroutine("TransitionRight");
				if(transition2==true)
				{
					GUI.DrawTexture (new Rect(t2,-1450,2048,2048), star_trails);
					GUI.Button (new Rect (t2_btn1,300,300,100), "Play Game");
					GUI.Button (new Rect (t2_btn1,420,145,100), "Settings");
					GUI.Button (new Rect (t2_btn2,420,145,100), "About");
				}
				else if(transition2==false)
				{
					GUI.DrawTexture (new Rect(-895,-1450,2048,2048), star_trails);
					StopCoroutine("TransitionRight");
					if(GUI.Button (new Rect(10,10,100, 50), "Back"))
					{
						gui_id=0;
						t2_btn1=330;
						t2_btn2=485;
						t2=0;
					}
					else if(GUI.Button (new Rect(330,150,300,100), "Video Settings"))
					{
						gui_id=4;
					}
					//else if(GUI.Button (new Rect(330,260,300,100), "Audio Settings"))
					//{
					//	gui_id=5;
					//}
				}
			}
			else if(check=="no")
			{
				StopCoroutine("TransitionRight");
				GUI.DrawTexture (new Rect(-960,-1450,2048,2048), star_trails);
				if(GUI.Button (new Rect(10,10,100, 50), "Back"))
				{
					gui_id=0;
					t2_btn1=330;
					t2_btn2=485;
					t2=0;
				}
			}
		}
		else if(gui=true && gui_id==3)
		{
			Check (2);
			if(check=="go")
			{
				StartCoroutine("TransitionRight");
				if(transition2==true)
				{
					GUI.DrawTexture (new Rect(t2,-1450,2048,2048), star_trails);
					GUI.Button (new Rect (t2_btn1,300,300,100), "Play Game");
					GUI.Button (new Rect (t2_btn1,420,145,100), "Settings");
					GUI.Button (new Rect (t2_btn2,420,145,100), "About");
				}
				else if(transition2==false)
				{
					GUI.DrawTexture (new Rect(-895,-1450,2048,2048), star_trails);
					if(GUI.Button (new Rect(10,10,100, 50), "Back"))
					{
						gui_id=0;
						t2_btn1=330;
						t2_btn2=485;
						t2=0;
					}
					GUI.Box (new Rect(180,100,600,300),"About Box");
					GUI.Label (new Rect(180,125,600,300), "This game was made for Github's Game Off 2013. It's Based upon Unity Free 4.3 and was modeled in Google Sketchup and textured with Adobe Photoshop. The main menu music was created by youtube.com/hullomynameisalex OR soundcloud.com/alxdmusic. ");
					GUI.DrawTexture (new Rect(350,200,256,256),changer098);
				}
			}
			else if(check=="no")
			{
				GUI.DrawTexture (new Rect(-960,-1450,2048,2048), star_trails);
				if(GUI.Button (new Rect(10,10,100, 50), "Back"))
				{
					gui_id=0;
					t2_btn1=330;
					t2_btn2=485;
					t2=0;
				}
				GUI.Box (new Rect(180,100,600,300),"About Box");
				GUI.Label (new Rect(180,125,600,300), "This game was made for Github's Game Off 2013. It's Based upon Unity Free 4.3 and was modeled in Google Sketchup and textured with Adobe Photoshop. The main menu music was created by youtube.com/hullomynameisalex OR soundcloud.com/alxdmusic. ");
			}
		}
		else if(gui=true && gui_id==4)
		{
			GUI.DrawTexture (new Rect(-895,-1450,2048,2048), star_trails);
			if(GUI.Button (new Rect(10,10,100, 50), "Back"))
			{
				gui_id=2;
			}
			else if(GUI.Button (new Rect(330,150,300,100), "Quality"))
			{
				gui_id=401;
			}
			//else if(GUI.Button (new Rect(330,260,300,100), "Extras"))
			//{
			//	//Frames Per Second, etc.
			//	gui_id=402;
			//}
		}
		else if(gui=true && gui_id==5)
		{
			GUI.DrawTexture (new Rect(-895,-1450,2048,2048), star_trails);
			if(GUI.Button (new Rect(10,10,100, 50), "Back"))
			{
				gui_id=2;
			}
			else if(GUI.Button (new Rect(350,150,300,100), "Volume"))
			{
				gui_id=501;
			}
			else if(GUI.Button (new Rect(350,260,300,100), "Configuration"))
			{
				gui_id=502;
				//UnityEngine.AudioSettings.speakerMode = AudioSpeakerMode.Quad;
			}
		}
		else if(gui=true && gui_id==401)
		{
			GUI.DrawTexture (new Rect(-895,-1450,2048,2048), star_trails);
			if(GUI.Button (new Rect(10,10,100, 50), "Back"))
			{
				gui_id=4;
			}
			else if(GUI.Button (new Rect(330,50,300,75), "Fastest"))
			{
				QualitySettings.SetQualityLevel (0);
				Debug.Log (QualitySettings.GetQualityLevel());
			}
			else if(GUI.Button (new Rect(330,135,300,75), "Fast"))
			{
				QualitySettings.SetQualityLevel (1);
				Debug.Log (QualitySettings.GetQualityLevel());
			}
			else if(GUI.Button (new Rect(330,220,300,75), "Simple"))
			{
				QualitySettings.SetQualityLevel (2);
				Debug.Log (QualitySettings.GetQualityLevel());
			}
			else if(GUI.Button (new Rect(330,305,300,75), "Good"))
			{
				QualitySettings.SetQualityLevel(3);
				Debug.Log (QualitySettings.GetQualityLevel());
			}
			else if(GUI.Button (new Rect(330,390,300,75), "Beautiful"))
			{
				QualitySettings.SetQualityLevel(4);
				Debug.Log (QualitySettings.GetQualityLevel());
			}
			else if(GUI.Button (new Rect(330,475,300,75), "Fantastic"))
			{
				QualitySettings.SetQualityLevel (5);
				Debug.Log (QualitySettings.GetQualityLevel());
			}
		}
		else if(gui=true && gui_id==402)
		{
			GUI.DrawTexture (new Rect(-895,-1450,2048,2048), star_trails);
			if(GUI.Button (new Rect(10,10,100, 50), "Back"))
			{
				gui_id=4;
			}
			else if(GUI.Button (new Rect(330,150,300,75), "Draw Frames Per Second"))
			{
				if(ExtrasGUI.drawfps==0)
				{
					ExtrasGUI.drawfps=1;
				}
				else if(ExtrasGUI.drawfps==1)
				{
					ExtrasGUI.drawfps=0;
				}
			}
		}
		else if(gui=true && gui_id==501)
		{
			GUI.DrawTexture (new Rect(-895,-1450,2048,2048), star_trails);
			if(GUI.Button (new Rect(10,10,100, 50), "Back"))
			{
				gui_id=5;
			}
		}
		else if(gui=true && gui_id==502)
		{
			GUI.DrawTexture (new Rect(-895,-1450,2048,2048), star_trails);
			if(GUI.Button (new Rect(10,10,100, 50), "Back"))
			{
				gui_id=5;
			}
		}
	}
}
