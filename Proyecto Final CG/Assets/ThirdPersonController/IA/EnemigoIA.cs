using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoIA : MonoBehaviour
{
    //Variables
    public Animator anim;
    private Vector3 distPlayer;
    private Vector3 playerTrans;

    private CharacterController m_CharacterController;
    private float m_GravityForce = 9.807f;
    private Vector3 m_MoveDirection;
    public float speed = 1.0f;
    private Quaternion m_lookAtRotation;

    private float timer;
    public float timeGuard = 5.0f;

    private Vector3 difPos;
    public Transform []wayPoint;
    public float rotSpeed = 45.0f;
    private int nextWayPoint = 0;

    public NavMeshPath pathNav;

    void Start()
    {
        m_CharacterController = this.GetComponent<CharacterController>();
        pathNav = new NavMeshPath();
    }

    void Update()
    {
        if (m_CharacterController.isGrounded)
        {
            //Estados
            playerTrans = GameObject.FindGameObjectWithTag("Player").transform.position;
            distPlayer = playerTrans - this.transform.position;
            if (Mathf.Abs(distPlayer.x) < 15.0f && Mathf.Abs(distPlayer.z) < 15.0f)
            {
                Persecucion();
            }
            else
            {
                anim.SetBool("Persigue", false);
                if (timer < timeGuard)
                {
                    Guardia();
                }
                else if (timer >= timeGuard)
                {
                    Patrulla();
                }
            }
        }
        // Calculo y aplico gravedad al movimiento
        m_MoveDirection.y -= m_GravityForce * Time.deltaTime;
        // Envio informacion de movimiento al character controller
        m_CharacterController.Move(m_MoveDirection * Time.fixedDeltaTime);
        // Aplico rotacion en el eje y
        m_lookAtRotation.x = 0.0f;
        m_lookAtRotation.z = 0.0f;
        if (transform.rotation != m_lookAtRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookAtRotation, rotSpeed * Time.deltaTime);
        }
    }

    void Guardia()
    {
        rotSpeed = 5;
        timer = timer + 1 * Time.deltaTime;
        anim.SetBool("Patrulla", false);
        m_MoveDirection = Vector3.zero;
        m_lookAtRotation = Quaternion.LookRotation(wayPoint[nextWayPoint].position - transform.position);
    }

    void Patrulla()
    {
        rotSpeed = 60;
        anim.SetBool("Patrulla", true);
        speed = 1.0f;

        //Calculamos el camino
        NavMesh.CalculatePath(transform.position, wayPoint[nextWayPoint].position, NavMesh.AllAreas, pathNav);
        for (int i = 0; i < pathNav.corners.Length - 1; i++)
        {
            Debug.DrawLine(pathNav.corners[i], pathNav.corners[i + 1], Color.green);
            if (i == 0)
            {   //Meta
                difPos = wayPoint[nextWayPoint].position - this.transform.position;
                //Me detengo
                if (Mathf.Abs(difPos.x) < 0.1f && Mathf.Abs(difPos.z) < 0.1f)
                {
                    timer = 0;
                    if (nextWayPoint < (wayPoint.Length - 1))
                    {
                        nextWayPoint++;
                    }
                    else if (nextWayPoint == (wayPoint.Length - 1))
                    {
                        nextWayPoint = 0;
                    }
                }
                //Rotacion
                m_lookAtRotation = Quaternion.LookRotation(wayPoint[nextWayPoint].position - transform.position);
            }
            else
            {   //Camino
                difPos = pathNav.corners[1] - this.transform.position;
                //Rotacion
                m_lookAtRotation = Quaternion.LookRotation(pathNav.corners[1] - transform.position);
            }
        }
        //Mover hacia el waypoint
        m_MoveDirection = difPos.normalized * speed;

    }

    void Persecucion()
    {
        rotSpeed = 90;
        anim.SetBool("Persigue", true);
        
        //Movimiento
        NavMesh.CalculatePath(transform.position, playerTrans, NavMesh.AllAreas, pathNav);
        for (int i = 0; i < pathNav.corners.Length - 1; i++)
        {
            Debug.DrawLine(pathNav.corners[i], pathNav.corners[i + 1], Color.red);
            if (i == 0)
            {   //Meta
                difPos = playerTrans - this.transform.position;
                //Rotacion
                m_lookAtRotation = Quaternion.LookRotation(playerTrans - transform.position);
            }
            else
            {
                difPos = pathNav.corners[1] - this.transform.position;
                m_lookAtRotation = Quaternion.LookRotation(pathNav.corners[1] - transform.position);
            }
        }
        m_MoveDirection = difPos.normalized * speed;

        if (Mathf.Abs(distPlayer.x) < 3.0f && Mathf.Abs(distPlayer.z) < 3.0f)
        {
            speed = 1.5f;
            anim.SetBool("Persigue", false);

            float e = (Mathf.Abs(Input.GetAxis("P1LeftStickX")) + Mathf.Abs(Input.GetAxis("P1LeftStickY")));
            if (e < 0.1f)
            {
                anim.SetBool("Patrulla", false);
            }
            else
            {
                anim.SetBool("Patrulla", true);
            }
        }
        else
        {
            speed = 3.0f;
        }
     
    }

}
