using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	void Start () {
		InvokeRepeating("CreateEnemy", 0f, 4f);
	}

	// Update is called once per frame
	void Update () {

	}

	void CreateEnemy () {

		GameObject obj = Object.Instantiate (enemy);
	}
}
