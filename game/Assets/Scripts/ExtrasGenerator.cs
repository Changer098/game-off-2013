using UnityEngine;
using System.Collections;

public class ExtrasGenerator : MonoBehaviour {

	public Vector3 position;
	public Vector3 position2;
	public Vector3 position3;
	public GameObject AddAmmo;
	public GameObject AddShield;
	public GameObject AddSpecial1;
	public GameObject AddSpecial2;
	public GameObject coin;
	//Generator specific
	private int lst_nmb;
	private int gen;
	void Start()
	{
		StartCoroutine("Generate");
	}
	IEnumerator Generate()
	{
		while(true)
		{
			if(LevelSystem.levelup==true)
			{
				int nmb;
				randomnumber ();
				nmb=gen;
				switch(nmb)
				{
				case 1:
					Object.Instantiate (AddAmmo,position,Quaternion.identity);
					break;
				case 2:
					Object.Instantiate (AddShield,position,Quaternion.identity);
					break;
				case 3:
					Object.Instantiate (AddSpecial1,position,Quaternion.identity);
					break;
				case 4:
					Object.Instantiate (AddSpecial2,position,Quaternion.identity);
					break;
				case 5:
					Object.Instantiate (coin,position2,Quaternion.Euler (new Vector3(0,90,0)));
					break;
				case 6:
					Object.Instantiate (coin,position3,Quaternion.Euler (new Vector3(0,90,0)));
					break;
				}
				yield return new WaitForSeconds(2);
			}
			else
			{

			}
			yield return null;
		}
	}
	void randomnumber()
	{
		gen = Random.Range (0,7);
		Debug.Log (gen);
		if(gen==lst_nmb)
		{
			randomnumber ();
		}
		else
		{
			return;
		}
	}
}
