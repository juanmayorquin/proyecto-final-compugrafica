using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBoss : MonoBehaviour
{
    
    private string PlayerTag = "Player";
    
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag(PlayerTag))
        {
            
            SceneManager.LoadScene("Boss"); 
        }
    }
}
