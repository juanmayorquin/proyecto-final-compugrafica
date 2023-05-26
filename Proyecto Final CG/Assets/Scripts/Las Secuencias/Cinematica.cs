using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cinematica : MonoBehaviour
{
    public GameObject TextBox;
    public string frase;

	void Start () {
		TextBox.GetComponent<Text>().text = "";
		StartCoroutine(ScenePlayer());
        frase = "Joe y Leonard se acaban de comprometer y decieden celebrarlo con un viaje!";
	}

	IEnumerator ScenePlayer() {
		yield return new WaitForSeconds(3f);
		
		 foreach(char character in frase)
        {
            TextBox.GetComponent<Text>().text = TextBox.GetComponent<Text>().text + character;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2f);
       
        TextBox.GetComponent<Text>().text = "";

	}
    
}
