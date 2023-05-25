using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TutorialIA : MonoBehaviour
{
    //Variables
    private NavMeshAgent miAgente;
    private Animator anim;
    private float timer;
    public float timeGuard = 5.0f;
    public Transform[] wayPoint;
    private int nextWaypoint;
    private Vector3 distPlayer;
    private Vector3 playerTrans;

    void Start()
    {
        miAgente = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform.position;
        distPlayer = playerTrans - this.transform.position;
        if (Mathf.Abs(distPlayer.x) < 10 && Mathf.Abs(distPlayer.z) < 10)
        {
            Persecucion();
        }
        else
        {
            if (timer < timeGuard)
            {
                Guardia();
            }
            if (timer >= timeGuard)
            {
                Patrulla();
            }
        }
    }

    void Guardia()
    {
        timer = timer + 1 * Time.deltaTime;
        anim.SetBool("Patrulla", false);
    }

    void Patrulla()
    {
        anim.SetBool("Patrulla", true);
        miAgente.SetDestination(wayPoint[nextWaypoint].transform.position);
        Vector3 difPos = wayPoint[nextWaypoint].transform.position - this.transform.position;
        if (Mathf.Abs(difPos.x) < 0.1f && Mathf.Abs(difPos.z) < 0.1f)
        {
            timer = 0;
            if (nextWaypoint < wayPoint.Length -1)
            {
                nextWaypoint++;
            }
            else if (nextWaypoint == wayPoint.Length -1)
            {
                nextWaypoint = 0;
            }
        }
       
    }

    void Persecucion()
    {
        miAgente.SetDestination(playerTrans);
    }

}
