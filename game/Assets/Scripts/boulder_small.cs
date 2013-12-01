using UnityEngine;
using System.Collections;

public class boulder_small : MonoBehaviour {
	public int spawnspeed;
	void Start()
	{
		spawnspeed=LevelSystem.speedsmall;
		this.rigidbody.AddForce (Vector3.forward*spawnspeed);
		StartCoroutine ("Kill");
	}
	void OnCollisionEnter(Collision obj)
	{
		if(obj.gameObject.tag=="bullet")
		{
			Death (1);
		}
		else if(obj.gameObject.tag=="Player")
		{
			Death (2);
		}
		else
		{
			Death (0);
		}
	}
	void Death(int x)
	{
		if(x==1)
		{
			Player_ship.Add (1,1);
			Destroy (gameObject);
		}
		else if(x==2)
		{
			Player_ship.Sub (2,1);
			Destroy (gameObject);
		}
		else if(x==0)
		{
			Player_ship.Add(1,1);
			Destroy (gameObject);
		}
	}
	IEnumerator Kill()
	{
		
		yield return new WaitForSeconds(20);
		Destroy (gameObject);
	}
}
