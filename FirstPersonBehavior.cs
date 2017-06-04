using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonBehavior : MonoBehaviour {

	public Texture2D crosshairTexture;
	public float reticuleSizeDivisor = 6.0f;
	private Rect crosshairPosition;
	public GameObject StepsContainer;
	public GameObject EggContainer;

	void Awake()
	{
		StepsContainer.gameObject.SetActive (false);
		EggContainer.gameObject.SetActive (false);

	}
	// Use this for initialization
	void Start () {
		crosshairPosition = new Rect((Screen.width - crosshairTexture.width / reticuleSizeDivisor)/2.0f, 
			(Screen.height - crosshairTexture.height / reticuleSizeDivisor) / 2.0f, 
			crosshairTexture.width/reticuleSizeDivisor, crosshairTexture.height/reticuleSizeDivisor);
	}

	void OnGUI() {
		GUI.DrawTexture (crosshairPosition, crosshairTexture);
	}
	
	// Update is called once per frame
	void Update () {
		//code to detect where player is looking and clicking
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Input.GetMouseButtonDown (0)) {
			if (Physics.Raycast (ray, out hit)) {
				Debug.DrawLine (ray.origin, hit.point);
				if (hit.collider.tag.Equals ("Steps")) {
					hit.collider.gameObject.GetComponent<RaiseStep> ().MovePlatform();
				}

				if (hit.collider.tag.Equals ("Eggs")) {
					hit.collider.gameObject.GetComponent<eggMovement> ().enabled = false;
				}

			}
		}
		if(Input.GetKeyDown(KeyCode.X)){
			Debug.Log ("x pressed");
			StepsContainer.gameObject.SetActive (true);
		}
		if(Input.GetKeyDown(KeyCode.Y)){
			Debug.Log ("y pressed");
			EggContainer.gameObject.SetActive (true);
		}
	}

	//code to detect power up
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("PowerUp"))
		{
			Destroy (other.gameObject);
			StepsContainer.gameObject.SetActive (true);
			Debug.Log ("picked up power up1");
		}
		if (other.gameObject.CompareTag ("PowerUp2"))
		{
			Destroy (other.gameObject);
			EggContainer.gameObject.SetActive (true);
			Debug.Log ("picked up power up2");
		}
	}

}
