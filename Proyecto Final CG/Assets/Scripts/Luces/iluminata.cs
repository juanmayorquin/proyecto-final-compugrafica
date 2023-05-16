using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iluminata : MonoBehaviour
{
    public int modoluminoso;
	public GameObject lamparoso;


	void Update () {
		if  (modoluminoso == 0) {
			StartCoroutine (AnimateLight ());
		}
		
	}

	IEnumerator AnimateLight () {
	 modoluminoso = Random.Range (1, 4);
		if  (modoluminoso == 1) {
			lamparoso.GetComponent<Animation> ().Play ("ilu");
		}
		if  (modoluminoso == 2) {
			lamparoso.GetComponent<Animation> ().Play ("iluminatax");
		}
		if  (modoluminoso == 3) {
			lamparoso.GetComponent<Animation> ().Play ("ilum");
		}
		yield return new WaitForSeconds (0.99f);
	 modoluminoso = 0;
}
}
