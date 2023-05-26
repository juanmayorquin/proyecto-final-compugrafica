using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camara : MonoBehaviour
{
    [SerializeField] private float sensiMouse1, sensiMouse3;
    [SerializeField] private Transform cuerpoJugador, pp, tp;

    private float rotY, rotX;
    public Transform target;
    public float distanceTarget = 3.0f;
    Vector3 curRotation;
    Vector3 smoothVelocity = Vector3.zero;

    [SerializeField]
    private float smoothTime = 0.2f;//Suavizar camara

    [SerializeField]
    private Vector2 MaxMinRotation = new Vector2(-20, 40);


    float rotaX = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name.Equals("Menu") || SceneManager.GetActiveScene().name.Equals("GameOver")){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchFirstPersonCam()
    {
        transform.position = pp.position;

        float mouseX = Input.GetAxis("Mouse X") * sensiMouse1 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensiMouse1 * Time.deltaTime;

        rotaX -= mouseY; //Inverted Axis

        rotaX = Mathf.Clamp(rotaX, -80f, 80f);//Restriccion de rotacion de la camara entre 90 y -90

        transform.localRotation = Quaternion.Euler(rotaX, cuerpoJugador.eulerAngles.y, 0f);
        cuerpoJugador.Rotate(Vector3.up * mouseX);
    }

    public void SwitchThirdPersonCam()
    {
        transform.position = tp.position;
        float mouseX = Input.GetAxis("Mouse X") * sensiMouse3;
        float mouseY = Input.GetAxis("Mouse Y") * sensiMouse3;

        rotX -= mouseY;
        rotY += mouseX;

        rotX = Mathf.Clamp(rotX, MaxMinRotation.x, MaxMinRotation.y);
        Vector3 nextRotation = new Vector3(rotX, rotY);

        curRotation = Vector3.SmoothDamp(curRotation, nextRotation, ref smoothVelocity, smoothTime);
        transform.localEulerAngles = curRotation;

        transform.position = target.position - transform.forward * distanceTarget;
    }
}
