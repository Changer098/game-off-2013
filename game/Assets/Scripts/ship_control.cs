using UnityEngine;
using System.Collections;

public class ship_control : MonoBehaviour {
	public GameObject ship;
	public GameObject bullet;
	public GameObject missile;

	public AudioClip bullet_sfx;
	public AudioClip missile_sfx;
	// Use this for initialization
	void Start () {
		StartCoroutine ("Fire");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis ("Horizontal")!=0)
		{
			ship.rigidbody.AddForce(Vector3.left*25*Input.GetAxis ("Horizontal"));
		}
	}
	IEnumerator Fire()
	{
		while(true)
		{
			if(Input.GetAxis ("Jump")==1)
			{
				if(Player_ship.ammo>0)
				{
					audio.Play ();
					Object.Instantiate (bullet, new Vector3(ship.rigidbody.position.x,ship.rigidbody.position.y +2,ship.rigidbody.position.z-4f),Quaternion.Euler (90,0,0));
					Player_ship.Sub(3,1);
					yield return new WaitForSeconds(0.25f);
				}
				else
				{
					Debug.Log ("No Ammo!");
				}
			}
			else if(Input.GetKeyDown (KeyCode.Z))
			{
				if(Player_ship.special1>0)
				{
					StartCoroutine(Lazers.Particles());
					StartCoroutine(lazer_collider.Collide());
				}
				else
				{
					Debug.Log ("No Special Ammo 1");
				}
			}
			else if(Input.GetKeyDown (KeyCode.X))
			{
				if(Player_ship.special2>0)
				{
					audio.Play ();
					Object.Instantiate (missile, new Vector3(ship.rigidbody.position.x,ship.rigidbody.position.y +2,ship.rigidbody.position.z-4f),Quaternion.identity);
				}
				else
				{
					Debug.Log ("No Special Ammo 2");
				}
			}
			yield return null;
		}
	}
//	void OnCollisionEnter(Collision obj)
//	{
//		if(obj.gameObject.tag=="boulder")
//		{
//			Debug.Log ("collided with boulder.");
//			Player_ship.Sub (2,1);
//		}
//	}
	void OnDrawGizmos()
	{
		Gizmos.DrawSphere (new Vector3(ship.rigidbody.position.x,ship.rigidbody.position.y+1,ship.rigidbody.position.z-3f),0.5f);
	}
}
