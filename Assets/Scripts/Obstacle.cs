using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public float limitZ;
	public float speedRate=0.75f;
	public bool randomRotate = true;

	public Vector3 rotationTar;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
		limitZ = GameObject.FindGameObjectWithTag("Player").transform.position.z;
		speedRate = Random.Range (1, 10);
		float scale = Random.Range (1, 10);
		transform.localScale = new Vector3 (scale,scale,scale);
		transform.position = new Vector3 (Random.Range (-100, 100), Random.Range(-80,80), 520);

		if (randomRotate == true) {
			rotationTar = new Vector3 (Random.Range (0, 50), Random.Range (0, 50), Random.Range (0, 50));
		}

//		Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
//		rb.AddTorque (rotationTar);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-Vector3.forward*speedRate);

		if (limitZ - transform.position.z >= 10) {
			Destroy (gameObject);
		}

//		if (randomRotate == true) {
//			transform.Rotate (rotationTar*Time.deltaTime);
//		}
	}



	void OnCollisionEnter(Collision collision) {
		GameObject.Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
	}

}
