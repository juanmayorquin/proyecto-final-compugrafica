using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioEscena : MonoBehaviour
{
    public string scene;

    public void cambio()
    {
        SceneManager.LoadScene(scene);
    }

            
}
