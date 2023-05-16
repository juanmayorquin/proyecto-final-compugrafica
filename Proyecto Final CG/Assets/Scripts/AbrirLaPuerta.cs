using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirLaPuerta : MonoBehaviour
{
   public float distancia;
	public GameObject ActionDisplay;
	public GameObject ActionText;
	public GameObject puertax;
	public AudioSource rechinaje;
    public GameObject cruz;

	void Update () {
	 distancia = C.DistanciadelObjetivo;
	}

	void OnMouseOver () {
		if  (distancia <= 2) 
        {
			cruz.SetActive(true);
            ActionDisplay.SetActive (true);
			ActionText.SetActive (true);
		}
		if (Input.GetButtonDown("Action")) {
			if  (distancia <= 2) 
            
            {
				
                this.GetComponent<BoxCollider>().enabled = false;
				ActionDisplay.SetActive(false);
				ActionText.SetActive(false);
				puertax.GetComponent<Animation> ().Play ("Abreduradepuerta1");
				rechinaje.Play ();
			}
		}
	}

	void OnMouseExit() {
        cruz.SetActive(false);
		ActionDisplay.SetActive (false);
		ActionText.SetActive (false);
	}
}
