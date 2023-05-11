using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed, runningSpeed, gravity;
    [SerializeField] private Transform cam;
    [SerializeField] private GameObject visual;
    [SerializeField] private CinemachineVirtualCamera firstPersonCam;
    [SerializeField] private CinemachineFreeLook thirdPersonCam;
    bool aiming = false;
    Animator animator;
    float rotationSpeed;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = visual.GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        SwitchThirdPersonCam();
    }

    private void Update()
    {
        
        if(Input.GetKey(KeyCode.Mouse1))
        {
            Aim();
        }
        else
        {
            CamSwitcher.SwitchCamera(thirdPersonCam);
            MoverThirdPerson();
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
            float targetAngle = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

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

            transform.rotation = Quaternion.Euler(0, angle, 0);
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

        transform.rotation = Quaternion.Euler(0, firstPersonCam.transform.eulerAngles.y, 0f);
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
        cam.transform.rotation = Quaternion.Euler(0f, gameObject.transform.rotation.y, 0f);
        MoverFristPerson();
        aiming = true;
    }

    void SwitchFirstPersonCam()
    {
        firstPersonCam.Priority = 10;
        thirdPersonCam.Priority = 0;
    }

    void SwitchThirdPersonCam()
    {
        thirdPersonCam.Priority = 10;
        firstPersonCam.Priority = 0;
    }
}
