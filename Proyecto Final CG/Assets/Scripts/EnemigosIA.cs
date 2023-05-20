using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigosIA : MonoBehaviour
{
    // Variables

    public NavMeshAgent miAgente;
    private float timer;
    [SerializeField] public float timeGuard;
    public Transform[] wayPoint; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < timeGuard)
        {
            Guardia();
        }
        if (timer >= timeGuard)
        {
            Patrulla();
        }
    }

    void Guardia ()
    {
        timer = timer + 1 * Time.deltaTime;
    }

    void Patrulla()
    {
        miAgente.SetDestination(wayPoint[0].transform.position);
    }

    void Persecucion()
    {

    }
}
