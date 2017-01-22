using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject ship;
	private Vector3 refer;
	public GameObject exposion;
	public bool died = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (died == false) {
			if (ship == null || ship.active == false) {
				DieNow ();
			} else {
				refer = new Vector3 (ship.transform.position.x, ship.transform.position.y, ship.transform.position.z);
			}
		}

	}

	void DieNow (){
		died = true;
		Instantiate (exposion, refer, Quaternion.identity);
		Invoke ("Restart", 4f);
	}

	void Restart() {
		XHairController.weaponsHot = false;
		tutorialDialog.stateGame = 3;
		tutorialDialog.arrayIndex = 0;
		Invoke ("Replay", 5f);
	}

	void Replay() {
		Application.LoadLevel ("Game");
	}
}
