using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Destroy (gameObject, 4.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
