using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CogerlaPistola : MonoBehaviour
{
   public float distancia;
	public GameObject ActionDisplay;
	public GameObject ActionText;
	public GameObject fakepistola;
	public GameObject RealPistola;
    public GameObject cruz;

	void Update () {
	 distancia = C.DistanciadelObjetivo;
	}

	void OnMouseOver () {
		if  (distancia <= 2) 
        {
			cruz.SetActive(true);
			ActionText.GetComponent<Text>().text="Recoge la Pistola, Será Util.";
            ActionDisplay.SetActive (true);
			ActionText.SetActive (true);
		}
		if (Input.GetButtonDown("Action")) {
			if  (distancia <= 2) 
            
            {
				
                this.GetComponent<BoxCollider>().enabled = false;
				ActionDisplay.SetActive(false);
				ActionText.SetActive(false);
				fakepistola.SetActive(false);
				RealPistola.SetActive(true);
				cruz.SetActive(false);
			}
		}
	}

	void OnMouseExit() {
        cruz.SetActive(false);
		ActionDisplay.SetActive (false);
		ActionText.SetActive (false);
	}
}
