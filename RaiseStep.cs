using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseStep : MonoBehaviour {
	private Vector3 finalPosUp;
	private Vector3 finalPosDown;
	private bool isStepMoving;

	// Use this for initialization
	void Start () {		
		isStepMoving = false;
		finalPosUp = new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z);
		finalPosDown = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {			
	}

	public void MovePlatform() {
		StartCoroutine (movePlatform());
	}

	IEnumerator movePlatform(){
		if (isStepMoving != true) {
			isStepMoving = true;
			float timeToReach = 0.1f;
			float t =0.0f;
			while(true){
				t += Time.deltaTime*timeToReach;
				gameObject.transform.position = Vector3.Lerp (transform.position, finalPosUp, t );
				yield return new WaitForSeconds(0.01f);
				if (gameObject.transform.position == finalPosUp) {					
					break;
				}
			}
			yield return new WaitForSeconds (3.0f);
			t = 0f;
			while(true){
				t += Time.deltaTime*timeToReach;
				gameObject.transform.position = Vector3.Lerp (transform.position, finalPosDown, t );
				yield return new WaitForSeconds(0.01f);
				if (gameObject.transform.position == finalPosDown) {					
					isStepMoving = false;					
					yield break;
				}
			}
		}
	}


}