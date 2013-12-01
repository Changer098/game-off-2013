using UnityEngine;
using System.Collections;

public class individualcolliders : MonoBehaviour {

	void OnTriggerEnter(Collider obj)
	{
		if(obj.gameObject.tag=="boulder")
		{
			Debug.Log ("collided with boulder.");
			Player_ship.Sub (2,1);
			Destroy (obj.gameObject);
		}
		if(obj.gameObject.tag=="addammo")
		{
			Player_ship.Add(3,1);
			Destroy(obj.gameObject);
		}
		if(obj.gameObject.tag=="addshield")
		{
			Player_ship.Add(2,1);
			Destroy(obj.gameObject);
		}
		if(obj.gameObject.tag=="addspecial1")
		{
			Player_ship.Add(4,1);
			Destroy(obj.gameObject);
		}
		if(obj.gameObject.tag=="addspecial2")
		{
			Player_ship.Add(5,1);
			Destroy(obj.gameObject);
		}
		if(obj.gameObject.tag=="coin")
		{
			Player_ship.Add(6,1);
			Destroy(obj.gameObject);
		}
	}
}
