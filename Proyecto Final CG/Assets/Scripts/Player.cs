using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private int ammo;
    [SerializeField] private float speed, runningSpeed, gravity;
    [SerializeField] private Camara cam;
    [SerializeField] private GameObject visual, flashlight, gun;
    [SerializeField] private List<Item> inventory = new List<Item>();
    [SerializeField] private Item itemSeleccionado;

    Animator animator;
    float rotationSpeed;

    public float life;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = visual.GetComponent<Animator>();
        Cursor.visible = true;
        SwitchThirdPersonCam();

        inventory[0].selected = true;

    }

    private void Update()
    {       
        foreach(Item item in inventory)
        {
            if(item.selected)
            {
                itemSeleccionado = item;
            }
        }

        if(Input.GetKey(KeyCode.Mouse1))
        {
            Aim();
        }
        else
        {
            SwitchThirdPersonCam();
            MoverThirdPerson();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inventory[0].selected = true;
            inventory[1].selected = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inventory[0].selected = false;
            inventory[1].selected = true;
        }
    }

    void MoverThirdPerson()
    {
        float movementSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = runningSpeed;
        }
        else
        {
            movementSpeed = speed;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        Vector3 direccion = new Vector3(horizontal, 0, vertical).normalized;

        if (direccion.magnitude > 0)
        {
            float targetAngle = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;


            if (movementSpeed == speed)
            {
                animator.SetBool("walk", true);
                animator.SetBool("run", false);
            }

            if (movementSpeed == runningSpeed)
            {
                animator.SetBool("walk", false);
                animator.SetBool("run", true);
            }

            //transform.rotation = Quaternion.Euler(0, angle, 0);
            characterController.Move(moveDir.normalized * movementSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
        }
    }

    void MoverFristPerson()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0f);
        Vector3 direccion = ((transform.forward * vertical) + (transform.right * horizontal)).normalized;

        if(direccion.magnitude > 0)
        {
            animator.SetBool("walk", true);
            animator.SetBool("run", false);
        }
        else
        {
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
        }

        characterController.Move(direccion * speed * 0.2f * Time.deltaTime);
    }

    void Aim()
    {
        SwitchFirstPersonCam();
        MoverFristPerson();
        foreach (Item item in inventory)
        {
            item.gameObject.SetActive(item.selected);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            InteractuarConItem(itemSeleccionado);
        }
    }

    void SwitchFirstPersonCam()
    {
        cam.SwitchFirstPersonCam();
    }

    void SwitchThirdPersonCam()
    {
        cam.SwitchThirdPersonCam();
        gun.SetActive(false);
        flashlight.SetActive(false);
    }

    void Die()
    {
        SwitchThirdPersonCam();
        animator.SetBool("walk", false);
        animator.SetBool("run", false);
        animator.SetBool("die", true);
        speed = 0;
        runningSpeed = 0;
    }

    void InteractuarConItem(Item itemAUtilizar)
    {
        itemAUtilizar.Interactuar();
    }

    public void TakeDamage(float damage)
    {
        if (life - damage <= 0)
        {
            life = 0;
            Die();
        }
        else
        {
            life -= damage;
        }
    }

    public void Curar(float cura)
    {
        if(life + cura > 100)
        {
            life = 100;
        }
        else
        {
            life += cura;
        }
    }
}
