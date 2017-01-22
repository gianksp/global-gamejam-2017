using UnityEngine;
using System.Collections;

public class IntroController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Play", 20f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Play() {
		Application.LoadLevel ("Game");
	}
}
