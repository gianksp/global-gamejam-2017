using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public GameObject ship;
	public Transform fuselage;

	public Transform[] cannons;
	public Transform launcher;

	public GameObject missile;
	public GameObject laser;

	public GameObject[] eyeLasers;

	private bool alive = false;
	private bool isFiring = false;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("FireLaser", 28f, reattack);
		InvokeRepeating ("FireMissile", 10f, reattackM);
		InvokeRepeating ("Firing", 5f, 5f);
		Invoke ("Live", 20f);
	}
	
	// Update is called once per frame
	void Update () {
		if (alive) {
			var targetRotation = Quaternion.LookRotation (ship.transform.position - transform.position);

			// Smoothly rotate towards the target point.
			transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, 0.5f* Time.deltaTime);
		}
	}

	void Live() {
		alive = true;
	}

	void Firing() {
		isFiring = !isFiring;
		try {
			for (int index = 0; eyeLasers.Length < 10; index++) {
				eyeLasers [index].SetActive (isFiring);
			}
		} catch(System.Exception ex){
			
		}
	}
		

	public float speed = 5f;
	public float reattack = 1f;
	public float reattackM = 3f;
	public float damage = 1f;

	public Transform cannon;
	public GameObject projectile;
	public GameObject missileProjectile;


	void FireLaser() {
//		if (alive) {
//			var targetRotation = Quaternion.LookRotation (fuselage.position);
//
//			for (int index = 0; index < cannons.Length; index++) {
//				Vector3 tar = ship.transform.position - transform.position;
//				//		Vector3 dir = new Vector3 (tar.x+Random.Range(-5,5)/5,tar.y+Random.Range(-5,5)/5,tar.z+Random.Range(-5,5)/5);
//
//
//				GameObject obj = (GameObject)Object.Instantiate (laser, cannons [index].position, cannons [index].rotation);
//				//Add minimum variance in aim to laser rotation 
//				Bullet bullet = obj.GetComponent<Bullet> ();
//				bullet.damage = damage;
//				Rigidbody rb = obj.GetComponent<Rigidbody> ();
//				rb.AddForce (bullet.transform.forward * 1000f);
//			}
//		}
	}

	void FireMissile() {
		if (alive) {
			for (int index = 0; index < 10; index++) {
				Vector3 randomRot = new Vector3 (Random.Range (-180, 180), Random.Range (30, 120), Random.Range (-90, 90));
				GameObject obj = (GameObject)Object.Instantiate (missile, new Vector3 (launcher.position.x + Random.Range (-65, 65), launcher.position.y + Random.Range (-10, 10), launcher.position.z), Quaternion.Euler (randomRot));
				Missile m = obj.GetComponent<Missile> ();
				m.damage = damage * 4;
				m.target = ship.transform;
			}
		}
	}
}
