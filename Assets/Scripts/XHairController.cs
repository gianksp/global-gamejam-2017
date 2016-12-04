using UnityEngine;
using System.Collections;

public class XHairController : MonoBehaviour {

	public Ship ship;
	public Transform destination;
	public float speed=4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		transform.position =   Vector3.Lerp(transform.position, destination.position, Time.deltaTime*speed*2f);
		transform.rotation =   Quaternion.Lerp (transform.rotation, destination.rotation, Time.deltaTime*speed);
	}
}
