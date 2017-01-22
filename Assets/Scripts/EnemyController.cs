using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject enemy;


	private bool initiated = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (tutorialDialog.stateGame > 0 && !initiated) {
			initiated = true;
			InvokeRepeating("CreateEnemy", 0f, 4f);
		}
	}

	void CreateEnemy () {

		GameObject obj = Object.Instantiate (enemy);
	}
}
