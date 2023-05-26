using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class policiapolicia : MonoBehaviour
{
   public void EscenaJuego()
   {
     SceneManager.LoadScene("CinematicaInicial");
   }

   public void PlayAgain()
   {
     SceneManager.LoadScene("Juego");
   }


   public void Salir()
   {
    Application.Quit();
   }
}
