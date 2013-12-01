using UnityEngine;
using System.Collections;

public class generator : MonoBehaviour {

	public Vector3 position_base;					//Case 1
	public Vector3 position_left1;					//Case 2
	public Vector3 position_right1;					//Case 3
	public Vector3 position_left2;					//Case 4
	public Vector3 position_right2;					//Case 5
	public Vector3 position_left3;					//Case 6
	public Vector3 position_right3;					//Case 7

	public GameObject rock;
	public GameObject rocksm;
	public int lst_nmb;
	private int gen;
	public static float WaitTime;
	void Start () {
		WaitTime=1;
		StartCoroutine("Generate");
		Debug.Log ("Quality Level is:"+QualitySettings.GetQualityLevel());
	}
	IEnumerator Generate()
	{
		Debug.Log ("Generate started");
		{
			while(true)
			{
				int nmb;
				randomnumber ();
				nmb=gen;
				switch(nmb)
				{
				case 1:
					Object.Instantiate (rock, position_base, Quaternion.identity);
					lst_nmb=1;
					break;
				case 2:
					Object.Instantiate (rock, position_left1, Quaternion.identity);
					lst_nmb=2;
					break;
				case 3:
					Object.Instantiate (rock, position_right1, Quaternion.identity);
					lst_nmb=3;
					break;
				case 4:
					Object.Instantiate (rock, position_left2, Quaternion.identity);
					lst_nmb=4;
					break;
				case 5: 
					Object.Instantiate (rock, position_right2, Quaternion.identity);
					lst_nmb=5;
					break;
				case 6: 
					Object.Instantiate (rocksm, position_left3, Quaternion.Euler(new Vector3(0,90,0)));
					lst_nmb=6;
					break;
				case 7: 
					Object.Instantiate (rocksm, position_right3, Quaternion.identity);
					lst_nmb=7;
					break;
				}
				yield return new WaitForSeconds(WaitTime);
			}
		}
	}
	void randomnumber()
	{
		gen = Random.Range (0,8);
		Debug.Log (gen);
		if(gen==lst_nmb)
		{
			Debug.Log ("Try again.");
			randomnumber ();
		}
		else
		{
			return;
		}
	}
	void OnDrawGizmos()
	{
		Gizmos.DrawSphere (position_base,1);
		Gizmos.DrawSphere (position_left1,1);
		Gizmos.DrawSphere (position_right1,1);
		Gizmos.DrawSphere (position_left2,1);
		Gizmos.DrawSphere (position_right2,1);
		Gizmos.DrawSphere (position_left3,1);
		Gizmos.DrawSphere (position_right3,1);
	
	}
}
