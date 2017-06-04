using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour {
	public Material mat;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset1 = new Vector2 (Mathf.Cos(Time.time*0.23f), Mathf.Sin(Time.time* 0.15f));
		Vector2 offset2 = new Vector2 (Mathf.Cos(Time.time*0.2f), -Mathf.Sin(Time.time*0.04f));
		mat.SetTextureOffset ("_MainTex", offset1);
		mat.SetTextureOffset ("_SecondaryTex", offset2);
			
	}
}
