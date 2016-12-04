using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public float limitZ;
	public float speedRate=0.75f;

	// Use this for initialization
	void Start () {
		limitZ = GameObject.FindGameObjectWithTag("Player").transform.position.z;
		transform.localScale = new Vector3 (Random.Range (1, 15), Random.Range (1,30), Random.Range (1,4));
		transform.position = new Vector3 (Random.Range (-100, 100), 0, 255);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-Vector3.forward*speedRate);

		if (limitZ - transform.position.z >= 10) {
			Destroy (gameObject);
		}
	}
}
