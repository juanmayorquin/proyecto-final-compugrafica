using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityStandardAssets.Characters.FirstPerson;

public class uno : MonoBehaviour
{
  //public GameObject yogador;
  public GameObject pantallanegra;
  public GameObject TextBox;

	void Start () {
		//yogador.GetComponent<FirstPersonController>().enabled = false;
		StartCoroutine(ScenePlayer());
	}

	IEnumerator ScenePlayer() {
		yield return new WaitForSeconds(1.5f);
		pantallanegra.SetActive(false);
		TextBox.GetComponent<Text>().text = "Necesito Encontrar a Joe!";
		yield return new WaitForSeconds(2);
		TextBox.GetComponent<Text>().text = "";
		//yogador.GetComponent<FirstPersonController>().enabled = true;

	}
}