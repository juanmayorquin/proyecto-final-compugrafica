using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public bool atak;
    public Player player;
    public float damage;
    public float vida;

    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        Target = GameObject.Find("Player");
    }



    public void Comportamiento_Enemy()
    {

        if (Vector3.Distance(transform.position, Target.transform.position) > 10)
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    ani.SetBool("walk", true);



                    break;


            }
        }
        else
        {
            if (Vector3.Distance(transform.position, Target.transform.position) > 2 && !atak)
            {


                var lookPos = Target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                ani.SetBool("walk", false);

                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                ani.SetBool("attack", false);
            }
            else
            {
                ani.SetBool("walk", false);
                ani.SetBool("run", false);

                ani.SetBool("attack", true);
                atak = true;

            }
        }
    }

    public void finalAni()
    {
        ani.SetBool("attack", false);
        atak = false;

    }

    public void pegar()
    {
        player.TakeDamage(damage);
    }
    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemy();
    }

    void Die()
    {
        ani.SetBool("walk", false);
        ani.SetBool("run", false);
        ani.SetBool("die", true);
        Destroy(gameObject,3f);
    }

    public void TakeDamage(float damage)
    {

        if (vida - damage <= 0)
        {
            vida = 0;
            Die();
        }
        else
        {
            vida -= damage;
        }

    }


}
