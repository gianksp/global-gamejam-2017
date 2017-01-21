using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	public GameObject ground;
	public float speed = 0.5f;
	private bool walking = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (walking) 
		{
			transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
		}



		Ray ray = Camera.main.ViewportPointToRay(new Vector3(speed,speed,0));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) 
		{
			if (hit.collider.name.Contains ("plane")) {
				walking = false;
			} else 
			{
				walking = true;
			}
		}
	}
}
