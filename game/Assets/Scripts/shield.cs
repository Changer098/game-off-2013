using UnityEngine;
using System.Collections;

public class shield : MonoBehaviour {
	public Material good;
	public Material bad;
	public Material nulltex;
	void Start()
	{
		StartCoroutine ("SlowUpdate");
	}
	IEnumerator SlowUpdate()
	{
		while(true)
		{
			if(Player_ship.shield<=2)
			{
				this.renderer.material = good;
			}
			if(Player_ship.shield==1)
			{
				this.renderer.material = bad;
			}
			if(Player_ship.shield==0 || Player_ship.shield<0)
			{
				this.renderer.material = bad;
			}
			yield return new WaitForSeconds(0.1f);
		}
	}
}
