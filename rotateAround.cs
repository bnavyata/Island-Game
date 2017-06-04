using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAround : MonoBehaviour {
	public float orbitDistance = 5.0f;
	public float orbitDegreesPerSec = 90.0f;
	public GameObject target;

	void Orbit(){
		if(target){
			transform.position = target.transform.position + (transform.position - target.transform.position).normalized *orbitDistance;
			transform.RotateAround(target.transform.position, Vector3.up, orbitDegreesPerSec * Time.deltaTime);
		}
	}

	void LateUpdate(){
		Orbit ();
	}
}
