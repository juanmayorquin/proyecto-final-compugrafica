using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioEscena : MonoBehaviour
{
    public string scene;

    public void OnCollisionEnter(Collision collision)
    
    {

        if(collision.gameObject.tag == "cambio")
        {

            Debug.Log("TOCO");

            SceneManager.LoadScene(scene);

        }
        

            

        
    }
}
