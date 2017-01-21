using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class XHairController : MonoBehaviour {

	public Ship ship;
	public Transform destination;
	public float speed=4f;
	public bool allowTargeting = false;

	public Color colorTarget = Color.red;
	public Color currentColor;
	public Color colorOrg;
	public Renderer rend;
	public Camera[] cams;

	public static List<GameObject> targets = new List<GameObject>();
	public Texture lockImage;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		colorOrg = rend.material.color;
		currentColor = colorOrg;
	}

	void Update() {

		transform.position =   Vector3.Lerp(transform.position, destination.position, Time.deltaTime*speed*2f);
		transform.rotation =   Quaternion.Lerp (transform.rotation, destination.rotation, Time.deltaTime*speed);

		if (allowTargeting) {
			Vector3 dir = transform.position - Camera.main.transform.position;

			RaycastHit hit;
			ship.target = null;
			if (Physics.Raycast (transform.position, dir, out hit)) {
				if (hit.distance <= ship.radarRange) {

					if (hit.transform.gameObject.CompareTag ("Enemy") || hit.transform.gameObject.CompareTag ("Missile")) {
						ship.target = hit.transform.gameObject;
						AddTarget (hit.transform.gameObject);
					}
				}
			}
		}

		if (ship.target != null) {
			rend.material.color = Color.Lerp(currentColor, colorTarget, 0.5f);
		} else {
			rend.material.color = Color.Lerp(currentColor, colorOrg, 1.5f);
		}
	}

	public static void AddTarget(GameObject obj) {
		if (!targets.Contains (obj)) {
			targets.Add (obj);
		}	
	}

	public static void RemoveTarget(GameObject obj) {
		targets.Remove (obj);
	}

//	void OnGUI() {
//		
//		if (ship.target != null) {
//			foreach(GameObject tar in targets) {
//				foreach(Camera cam in cams) {
//				Vector3 position = Camera.main.WorldToScreenPoint(tar.transform.position);
//					GUI.DrawTexture(new Rect(position.x, Screen.height-(position.y), 50,50), lockImage);
//				}
//
//			}
//		}
//	}
}
