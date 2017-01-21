using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

	public GameObject[] obstacle;

	// Use this for initialization
	void Start () {
		InvokeRepeating("CreateObstacle", 0f, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateObstacle () {
		GameObject obs = (GameObject)obstacle.GetValue (Random.Range(0,obstacle.Length - 1));
		GameObject obj = Object.Instantiate (obs);
	}
}
