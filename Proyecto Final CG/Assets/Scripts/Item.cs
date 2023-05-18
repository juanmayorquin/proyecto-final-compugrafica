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
    public void Interactuar(int ammo)
    {
        switch(nombre)
        {
            case "linterna":
                GetComponentInChildren<Light>().enabled = !GetComponentInChildren<Light>().enabled;
                break;
            case "gun":
                Disparar(ammo);
                break;
        }
    }

    void Disparar(int ammo)
    {
        Instantiate(bala, fire.transform.position, Quaternion.Euler(bala.transform.eulerAngles.x, bala.transform.eulerAngles.y - 90, bala.transform.eulerAngles.z));
        //bala.GetComponent<Rigidbody>().AddForce(bala.transform.right * 10);
    }
}