using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

	public GameObject obstacle;

	// Use this for initialization
	void Start () {
		InvokeRepeating("CreateObstacle", 0f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateObstacle () {

		GameObject obj = Object.Instantiate (obstacle);
	}
}
