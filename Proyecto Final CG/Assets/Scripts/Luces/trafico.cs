using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafico : MonoBehaviour
{
    public int modoluminoso;
	public GameObject trafix;


	void Update () {
		if  (modoluminoso == 0) {
			StartCoroutine (AnimateLight ());
		}
		
	}

	IEnumerator AnimateLight () {
	 modoluminoso = Random.Range (1, 4);
		if  (modoluminoso == 1) {
			trafix.GetComponent<Animation> ().Play ("semaforo");
		}
		if  (modoluminoso == 2) {
			trafix.GetComponent<Animation> ().Play ("sema");
		}
		if  (modoluminoso == 3) {
			trafix.GetComponent<Animation> ().Play ("foro");
		}
		yield return new WaitForSeconds (0.99f);
	 modoluminoso = 0;
}
}
