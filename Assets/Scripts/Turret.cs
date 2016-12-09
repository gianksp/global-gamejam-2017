using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public GameObject ship;
	public float speed = 5f;
	public float reattack = 1f;
	public float damage = 1f;

	public Transform cannon;
	public GameObject projectile;
	public GameObject missileProjectile;

	// Use this for initialization
	void Start () {
		ship = GameObject.FindGameObjectWithTag ("Ship");
		InvokeRepeating ("FireLaser", 1, reattack);
		InvokeRepeating ("FireMissile", 2, reattack*3);
	}

	// Update is called once per frame
	void Update () {
	
		var targetRotation = Quaternion.LookRotation(ship.transform.position - transform.position);

		// Smoothly rotate towards the target point.
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

	}

	void FireLaser() {
		GameObject obj = (GameObject)Object.Instantiate (projectile,cannon.position,ship.transform.rotation);
		Bullet bullet = obj.GetComponent<Bullet>();
		bullet.damage = damage;
		Rigidbody rb = obj.GetComponent<Rigidbody>();
		rb.AddForce (cannon.transform.forward * 1000f);
	}

	void FireMissile() {
	
		for (int index = 0; index < 5; index++) {
			Vector3 randomRot = new Vector3 (Random.Range(-180,0),Random.Range (45, 90), 0);
			GameObject obj = (GameObject)Object.Instantiate (missileProjectile, new Vector3 (cannon.position.x+Random.Range(-15,15), cannon.position.y + Random.Range(-3,3), cannon.position.z-4f), Quaternion.Euler (randomRot));
			Missile missile = obj.GetComponent<Missile> ();
			missile.damage = damage * 4;
			missile.target = ship.transform;
		}
	}
}
