using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigosIIA : MonoBehaviour
{
    // Variables

    public NavMeshAgent miAgente;
    private float timer;
    [SerializeField] public float timeGuard;
    public Transform[] wayPoint; 
    private int nextWaypoint;
    private Vector3 distPlayer;
    private Vector3 playerTrans;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform.position;
        distPlayer = playerTrans - this.transform.position;

        if(Mathf.Abs(distPlayer.x)<12.0f && Mathf.Abs(distPlayer.z)<12.0f)
        {
            Persecucion();
        }
        else
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

    }

    void Guardia ()
    {
        timer = timer + 1 * Time.deltaTime;
    }

    void Patrulla()
    {
        miAgente.speed = 3.0f;
        miAgente.stoppingDistance = 0;

        miAgente.SetDestination(wayPoint[nextWaypoint].transform.position);
        Vector3 difPos = wayPoint[nextWaypoint].transform.position - this.transform.position;
        if (Mathf.Abs (difPos.x) < 0.1f && Mathf.Abs(difPos.z) < 0.1f)
        {
            timer = 0;
            if(nextWaypoint < wayPoint.Length - 1)
            {
                nextWaypoint++;
            }
            else if (nextWaypoint == wayPoint.Length - 1)
            {
                nextWaypoint = 0;
            }
        }

    }

    void Persecucion()
    {
        miAgente.speed = 6.0f;
        miAgente.stoppingDistance = 1;
        miAgente.SetDestination(playerTrans);

        if(Mathf.Abs(distPlayer.x) < 6.0f && Mathf.Abs(distPlayer.z) < 6.0f)
        {
            miAgente.speed = 4.0f;


            if (Mathf.Abs(distPlayer.x) < 0.9f && Mathf.Abs(distPlayer.z) < 0.9f)
            {

            }
            else
            {

            }
        }
    }
}
