using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	public GameObject explosion;
	public float damage =10f;
	public Transform target;
	private Rigidbody _rb;
	public float speedRotation =10f;

	// Use this for initialization
	void Start () {
//		Invoke ("Explode", 5f);
//		transform.eulerAngles = new Vector3 (Random.Range (30, 60), Random.Range (-30, 30), 0);

		_rb = gameObject.GetComponent<Rigidbody>();
//		_rb.AddForce (Vector3.forward*10f,ForceMode.Impulse);
		Invoke ("Arm", 1);
	}

	void Arm() {
		SphereCollider col = (SphereCollider)gameObject.GetComponent<SphereCollider> ();
		col.radius = 1;
	}

	// Update is called once per frame
	void Update () {

//		if (target != null) {
//			var targetRotation = Quaternion.LookRotation (target.position - transform.position);
//			transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime*speedRotation);
//			speedRotation += 0.025f;
//		}


		if (target != null && target.position.z >= transform.position.z + 3) {
			Explode ();
		}
	}

	void FixedUpdate() {
		

//		transform.LookAt (target);
//		_rb.AddForce (transform.forward);

//		if(ifTarget){
			if(target == null){
				_rb.velocity = (transform.forward * 2500 * Time.deltaTime);

			} else {

//				if(Time.time > starttime){
					Vector3 dir = target.position - transform.position;
					Quaternion rot = Quaternion.LookRotation(dir);
					transform.rotation = Quaternion.Slerp(transform.rotation, rot,2f* Time.deltaTime);
//				}

				_rb.velocity = (transform.forward * 2500 * Time.deltaTime);


			}            
//		}

	}

	void OnCollisionEnter(Collision collision) {
		Explode ();
	}
		

	void Explode() {
//		GameObject.Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
