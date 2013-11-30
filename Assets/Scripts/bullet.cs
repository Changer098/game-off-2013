using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	public float wake;
	public float dead;
	public float time;
	// Use this for initialization
	void Start()
	{
		this.rigidbody.AddForce (Vector3.back*10000);
		wake=Time.fixedDeltaTime;
		dead=wake+5;
		StartCoroutine ("Kill");
	}
	void OnCollisionEnter(Collision obj)
	{
		if(obj.gameObject.tag=="boulder")
		{
			Destroy (gameObject);
		}
		else
		{
			Destroy (gameObject);
		}
	}
	IEnumerator Kill()
	{

		yield return new WaitForSeconds(1);
		Destroy (gameObject);
	}
}
