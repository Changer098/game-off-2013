using UnityEngine;
using System.Collections;

public class missile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.rigidbody.AddForce (Vector3.back*2000);
		Player_ship.special2=Player_ship.special2-1;
	}
	void OnCollisionEnter()
	{
		Destroy(gameObject);
	}
	void OnCollisionExit()
	{
		Destroy (gameObject);
	}
}
