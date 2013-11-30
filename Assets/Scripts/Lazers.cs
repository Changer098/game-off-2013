using UnityEngine;
using System.Collections;

public class Lazers : MonoBehaviour {

	// Use this for initialization
	public static IEnumerator Particles() {
		GameObject.FindWithTag("l_laser").particleSystem.Play ();
		GameObject.FindWithTag("r_laser").particleSystem.Play ();
		GameObject.FindWithTag("c_laser").particleSystem.Play ();
		yield return new WaitForSeconds(Player_ship.special1*2);
		GameObject.FindWithTag("l_laser").particleSystem.Stop ();
		GameObject.FindWithTag("r_laser").particleSystem.Stop ();
		GameObject.FindWithTag("c_laser").particleSystem.Stop ();
		Player_ship.special1 = Player_ship.special1 - Player_ship.special1;
	}
}
