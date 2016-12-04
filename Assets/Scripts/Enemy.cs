using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Rigidbody _rb;

	public float limitZ;
	public float speedRate=0.75f;

	// Use this for initialization
	void Start () {
		limitZ = GameObject.FindGameObjectWithTag("Player").transform.position.z;
		transform.localScale = new Vector3 (Random.Range (1, 15), Random.Range (1,30), Random.Range (1,4));
		transform.position = new Vector3 (Random.Range (-100, 100), 0, 255);
		_rb = gameObject.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(-Vector3.forward*speedRate);
		if (limitZ - transform.position.z >= 10) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Bullet") {
			Destroy (gameObject);
		}
	}
}
