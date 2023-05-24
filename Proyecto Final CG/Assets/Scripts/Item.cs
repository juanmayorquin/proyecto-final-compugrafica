using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string nombre;
    [SerializeField] private GameObject bala;
    [SerializeField] private Transform fire;
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
        GameObject balaLanzada = Instantiate(bala, fire.transform.position, Quaternion.Euler(fire.transform.eulerAngles.x, fire.transform.eulerAngles.y - 90, fire.transform.eulerAngles.z));
        balaLanzada.GetComponent<Rigidbody>().AddForce(fire.forward * 20, ForceMode.Impulse);
        Destroy(balaLanzada, 2f);
    }
}