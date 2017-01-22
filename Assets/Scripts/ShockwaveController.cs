using UnityEngine;
using System.Collections;

public class ShockwaveController : MonoBehaviour {

	public GameObject shockwave;

	// Use this for initialization
	void Start () {
		InvokeRepeating("CreateShockwave", 0f, 4f);
	}

	// Update is called once per frame
	void Update () {

	}

	void CreateShockwave () {

		GameObject obj = Object.Instantiate (shockwave);
		obj.transform.Rotate (new Vector3 (Random.Range (0, 360), Random.Range (0, 360), Random.Range (0, 360)));
		obj.transform.position = new Vector3 (Random.Range (-20, 20), Random.Range(-15,15), Random.Range(0,500));
	}
}
