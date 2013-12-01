using UnityEngine;
using System.Collections;

public class lazer_collider : MonoBehaviour {
	public int id;
	public static IEnumerator Collide()
	{
		GameObject.Find("Collider-laser").collider.enabled=true;
		yield return new WaitForSeconds(Player_ship.special1*2);
		GameObject.Find("Collider-laser").collider.enabled=false;
	}
}
