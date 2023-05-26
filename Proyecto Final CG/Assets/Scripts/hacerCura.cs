using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacerCura : MonoBehaviour
{
  [SerializeField] public float cantidadCura;

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player") && other.GetComponent<Player>().life < 100)
    {
        other.GetComponent<Player>().Curar(cantidadCura);
        Destroy(gameObject);
    }
  }
}
