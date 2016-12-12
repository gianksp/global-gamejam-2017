using UnityEngine;
using System.Collections;

public class Turbine : MonoBehaviour {

	private bool _isRotating = false;
	public GameObject effect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!_isRotating) {
			transform.eulerAngles = new Vector3 (0, 0, Random.Range (0, 360));
			int scale = Random.Range (2, 4);
			transform.localScale = new Vector3 (scale / 2, scale / 2, scale / 2);
			StartCoroutine("rotate");
		}

	}

	IEnumerator rotate ()
	{
		_isRotating = true;
		//		foreach (Transform cannon in ship.cannons) {
		//			GameObject obj = (GameObject)Object.Instantiate (ship.bullet,cannon.position,ship.transform.rotation);
		//			Bullet bullet = obj.GetComponent<Bullet>();
		//			bullet.damage = ship.damage;
		//			Rigidbody rb = obj.GetComponent<Rigidbody>();
		//
		//			if (ship.target != null) {
		//				bullet.transform.LookAt (ship.target.transform.position);
		//			} else {
		//				bullet.transform.rotation = cannon.transform.rotation;
		//			}
		//
		//			rb.AddForce (bullet.transform.forward * 1000f);
		//			ship.audio.PlayOneShot (ship.laserSound);
		//			yield return new WaitForSeconds(ship.reattack/ship.cannons.Length);
		//		}
		//
//		effect.SetActive(true);
		yield return new WaitForSeconds(0.1f);
//		effect.SetActive(false);
		_isRotating = false;
	}
}
