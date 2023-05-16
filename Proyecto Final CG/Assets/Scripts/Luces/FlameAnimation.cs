using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAnimation : MonoBehaviour
{
    public int modoluminoso;
	public GameObject FlameLight;


	void Update () {
		if  (modoluminoso == 0) {
			StartCoroutine (AnimateLight ());
		}
		
	}

	IEnumerator AnimateLight () {
	 modoluminoso = Random.Range (1, 4);
		if  (modoluminoso == 1) {
			FlameLight.GetComponent<Animation> ().Play ("TorchAnimation");
		}
		if  (modoluminoso == 2) {
			FlameLight.GetComponent<Animation> ().Play ("TorchAnima2");
		}
		if  (modoluminoso == 3) {
			FlameLight.GetComponent<Animation> ().Play ("TorchAnim3");
		}
		yield return new WaitForSeconds (0.99f);
	 modoluminoso = 0;

	}
}
