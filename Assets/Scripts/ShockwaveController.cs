using UnityEngine;
using System.Collections;

public class ShockwaveController : MonoBehaviour {

	public GameObject shockwave;

	// Use this for initialization
	void Start () {
		InvokeRepeating("CreateShockwave", 8f, 5f);
	}

	// Update is called once per frame
	void Update () {

	}

	void CreateShockwave () {

		GameObject obj = Object.Instantiate (shockwave);
	}
}
