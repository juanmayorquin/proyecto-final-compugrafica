using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string nombre;
    public bool selected;
    public void Interactuar()
    {
        switch(nombre)
        {
            case "linterna":
                GetComponentInChildren<Light>().enabled = !GetComponentInChildren<Light>().enabled;
                break;
            case "gun":
                Disparar();
                break;
        }
    }

    void Disparar()
    {

    }
}
