using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
	public GameObject Player;
	private Vector3 pos = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) 
	{
		if (col.gameObject.CompareTag ("Checkpoint"))
		{
			pos = col.gameObject.transform.position;
		}

		if (col.gameObject.CompareTag ("Water"))
		{
			Invoke ("respawnplayer", 2.0f);
		}
	}

	void respawnplayer(){
		gameObject.transform.position = pos;
	}


}
