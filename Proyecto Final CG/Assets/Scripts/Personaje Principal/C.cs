using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour
{
   public static float DistanciadelObjetivo;
   public float aporeobjetivo;


	void Update () {
		RaycastHit Hit;
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out Hit)) {
			aporeobjetivo = Hit.distance;
			DistanciadelObjetivo = aporeobjetivo;
		}
	}
}
