using UnityEngine;
using System.Collections;

public class Extras : MonoBehaviour {
	public int id;
	// Use this for initialization
	void Start () {
		this.rigidbody.AddForce (Vector3.forward*300);
	}
	void OnCollisionEnter(Collision obj)
	{
		if(obj.gameObject.tag=="Player" || obj.gameObject.tag=="bullet" || obj.gameObject.tag=="missile")
		{
			Debug.Log ("Collided with player.");
			switch(id)
			{//ammo,shields,s1,s2
			case 1: 
				Player_ship.Add (3,20);
				Destroy (gameObject);
				break;
			case 2: 
				Player_ship.Add (2,1);
				Destroy (gameObject);
				break;
			case 3: 
				Player_ship.Add (4,1);
				Destroy (gameObject);
				break;
			case 4: 
				Player_ship.Add (5,1);
				Destroy (gameObject);
				break;
			case 5:
				Player_ship.Add (6,1);
				Destroy (gameObject);
				break;
			}
		}
		else
		{
			Debug.Log ("Collided");
		}
	}
	void OnCollisionExit()
	{
		Destroy (gameObject);
	}
}
