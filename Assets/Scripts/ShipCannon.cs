using UnityEngine;
using System.Collections;

public class ShipCannon : MonoBehaviour {

	public GameObject effect;
	public ShipController shipController;

	private float flashDuration = 0.085f;
	private bool _isRotating = false;

	// Use this for initialization
	void Start () {
		effect.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {


		if (shipController.isFiring && !_isRotating) {
			transform.eulerAngles = new Vector3 (0, 0, Random.Range (0, 360));
			int scale = Random.Range (2, 5);
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
		effect.SetActive(true);
		yield return new WaitForSeconds(flashDuration);
		effect.SetActive(false);
		yield return new WaitForSeconds(shipController.ship.reattack-flashDuration);



		_isRotating = false;
	}
}
