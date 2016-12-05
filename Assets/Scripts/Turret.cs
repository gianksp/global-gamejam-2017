using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public GameObject ship;
	public float speed = 5f;
	public float reattack = 1f;
	public float damage = 1f;

	public Transform cannon;
	public GameObject projectile;

	// Use this for initialization
	void Start () {
		ship = GameObject.FindGameObjectWithTag ("Ship");
		InvokeRepeating ("Fire", 1, reattack);
	}

	// Update is called once per frame
	void Update () {
	
		var targetRotation = Quaternion.LookRotation(ship.transform.position - transform.position);

		// Smoothly rotate towards the target point.
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

	}

	void Fire() {
		GameObject obj = (GameObject)Object.Instantiate (projectile,cannon.position,ship.transform.rotation);
		Bullet bullet = obj.GetComponent<Bullet>();
		bullet.damage = damage;
		Rigidbody rb = obj.GetComponent<Rigidbody>();
		rb.AddForce (cannon.transform.forward * 1000f);
	}
}
