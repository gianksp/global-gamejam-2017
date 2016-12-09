using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public Transform marker;
	public Transform[] cannons;
	public GameObject bullet;
	public GameObject target;
	public float radarRange = 300f;

	public AudioClip laserSound;
	public AudioSource audio;

	//Attack stats
	public float damage = 1f;
	public float reattack = 0.5f;
	public float maxPower = 50f;
	public float power = 50f;

	//Defensive stats
	public float maxShield = 50f;
	public float shield = 50f;

	//Energy stats
	public float maxEnergy = 100f;
	public float energy = 100f;
	public float energyRegen = 5f;

	private Rigidbody _rb;

	public GameObject explosion;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody>();
		audio = GetComponent<AudioSource> ();
		InvokeRepeating("RegenEnergy",1f,1f);
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 destin = marker.position - transform.position;
		_rb.AddForce(destin *15,ForceMode.Acceleration);
		float angleY = Mathf.LerpAngle(transform.eulerAngles.y, marker.position.x*2f, Time.time);
		float angleX = Mathf.LerpAngle(transform.eulerAngles.x, -marker.position.y*3f, Time.time);
		transform.eulerAngles = new Vector3 (angleX, angleY, -4 * _rb.velocity.x);
	}

	void RegenEnergy() {
		energy += energyRegen;
	}

	void FixedUpdate() {
	
		RaycastHit hit;
		target = null;
		if (Physics.Raycast (transform.position, cannons[0].forward, out hit)) {
			if (hit.distance <= radarRange && hit.transform.gameObject.tag == "Enemy") {
				target = hit.transform.gameObject;
			}
		}

	}

	void OnCollisionEnter(Collision collision) {
//		Instantiate (explosion, collision.transform.position, Quaternion.identity);
		energy -= 20f;
	}
}
