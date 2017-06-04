using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggMovement : MonoBehaviour {
	private float currentPosition;
	private float minVal;
	private float maxVal;
	private int direction = 1;

	// Use this for initialization
	void Start () {
		minVal = Random.Range (-2.0f, -4.0f);
		maxVal = Random.Range (3.0f, 4.0f);
	}

	public void StopMoveEgg(){
		StopCoroutine ("startEggMove");
	}
	// Update is called once per frame
	void Update () {
		StartCoroutine ("startEggMove");
	}

	IEnumerator startEggMove(){
		currentPosition += Random.Range(1.5f,3.5f)*Time.deltaTime * direction;
		if (currentPosition >= maxVal) {
			direction *= -1;
			currentPosition = maxVal;
		}
		if (currentPosition <= minVal) {
			direction *= -1;
			currentPosition = minVal;
		}
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x, currentPosition, gameObject.transform.position.z);
		yield return null;
	}
}
