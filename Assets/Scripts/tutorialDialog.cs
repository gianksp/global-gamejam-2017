using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialDialog : MonoBehaviour {

	public Transform head;

	public static int stateGame = 0; //0 into, 1 combat, 2 boss, 3 lost, 4 won

	public static string dialog1 = "Tika:\n\nWelcome to the panda corps pilot Lt. Pando";
	public static string dialog2 = "Tika:\n\nSpace Debris in this region is exploding";
	public static string dialog3 = "Tika:\n\nThe SHOCKWAVES and destroying Planets in its path";
	public static string dialog4 = "Tika:\n\nYou have been chosen to eliminate the threat!";
	public static string dialog5 = "Tika:\n\nThe VF-RX Ship can be piloted using BRAINWAVES";
	public static string dialog6 = "Tika:\n\nTargets will be shot on sight!";
	public static string dialog7 = "Tika:\n\nNOD to acknowledge your mission and start!";

	public static string combat1 = "Pando:\n\nAcknowlege! engaging mission.\nYippee Ki Yay...";

	public static string boss1 = "DaDeestroier:\n\nYou will all perish!";

	public static string won1 = "Tika:\n\nYou have won";

	public static string lost1 = "Tika:\n\nOwned! Stop flying like a Rookie!";

	private string[] dialogArray = new string[] { dialog1, dialog2, dialog3, dialog4, dialog5, dialog6, dialog7 };

	private string[] combatArray = new string[] { combat1 };


	public RawImage op;
	public RawImage pan;
	public RawImage bosx;

	private float min = 0;
	private float max=0;

	float timer;
	public static int arrayIndex = 1;
	Text text;


	// Use this for initialization
	void Start () {
		op.gameObject.SetActive(true);
		text = GetComponent<Text> ();
		text.text = dialogArray [0];
		InvokeRepeating ("CleanMinMax", 0f,3f);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 5f && arrayIndex < dialogArray.Length) {
			op.gameObject.SetActive(true);
			pan.gameObject.SetActive(false);
			bosx.gameObject.SetActive(false);
			text.text = dialogArray [arrayIndex];
			arrayIndex++;
			timer = 0;

		}

		if (stateGame == 1) {
			op.gameObject.SetActive(false);
			pan.gameObject.SetActive(true);
			bosx.gameObject.SetActive(false);
			text.text = combatArray [0];
			timer = 0;
		}

		if (stateGame == 2) {
			op.gameObject.SetActive(false);
			pan.gameObject.SetActive(false);
			bosx.gameObject.SetActive(true);
			text.text = boss1;
			timer = 0;
		}

		if (stateGame == 3) {
			op.gameObject.SetActive(true);
			pan.gameObject.SetActive(false);
			bosx.gameObject.SetActive(false);
			text.text = lost1;
			timer = 0;
		}

		if (stateGame == 4) {
			op.gameObject.SetActive(true);
			pan.gameObject.SetActive(false);
			bosx.gameObject.SetActive(false);
			text.text = won1;
			timer = 0;
		}

		if (head != null && stateGame == 0) {
			Vector3 angle = head.rotation.eulerAngles;
			float ang = 360-angle.x;
			Debug.Log (angle.x.ToString ());
			if (ang >20 && ang <330) {
//				if (ang > max) {
//					max = ang;
//				}
//				if (ang < min) {
//					min = ang;
//				}

//				if (max - min > 40 && arrayIndex == dialogArray.Length-1) {
					Debug.Log ("Nod");
					StartGame ();
//				}
//				Debug.Log (ang.ToString ());
			}
		}



//		Debug.Log ("min: " + min.ToString () + " max: " + max.ToString ());
//		Debug.Log((head.rotation.eulerAngles.x*Mathf.Rad2Deg).ToString());

	}

	void CleanMinMax() {
		min = 0;
		max = 0;
	}

	void StartGame() {
		stateGame = 1;
		XHairController.weaponsHot = true;
	}
}
