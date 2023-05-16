using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calleluminosa : MonoBehaviour
{
  public int modoluminoso;
  public GameObject fosforico;


	void Update () {
		if  (modoluminoso == 0) {
			StartCoroutine (AnimateLight ());
		}
		
	}

	IEnumerator AnimateLight () {
	 modoluminoso = Random.Range (1, 4);
		if  (modoluminoso == 1) {
			fosforico.GetComponent<Animation> ().Play ("dd");
		}
		if  (modoluminoso == 2) {
			fosforico.GetComponent<Animation> ().Play ("distiny");
		}
		if  (modoluminoso == 3) {
			fosforico.GetComponent<Animation> ().Play ("destelle");
		}
		yield return new WaitForSeconds (0.99f);
	 modoluminoso = 0;
}
}
