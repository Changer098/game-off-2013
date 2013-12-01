using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	public GameObject sphere;
	public Animator obj;
	public void Exploded()
	{
		Object.Instantiate (obj);
	}
}
