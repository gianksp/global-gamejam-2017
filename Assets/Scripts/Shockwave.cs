using UnityEngine;
using System.Collections;

public class Shockwave : MonoBehaviour {

//	private Rigidbody _rb;

	public float limitZ;
	public float speedRate=0.75f;

	public float hp = 5f;
	public float points = 5f;

	public GameObject explosion;
	private float scale = 1;

	// Use this for initialization
	void Start () {
		Invoke ("Die", Random.Range(4,6));
		speedRate = Random.Range (1, 4);
		limitZ = GameObject.FindGameObjectWithTag("Player").transform.position.z;
		transform.position = new Vector3 (Random.Range (-20, 20), Random.Range(-5,5), Random.Range(100,300));
		transform.Rotate (new Vector3 (Random.Range (0, 360), Random.Range (0, 360), Random.Range (0, 360)));
//		_rb = gameObject.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		scale += 0.1f;
		transform.localScale = new Vector3(transform.localScale.x+scale,0.01f,transform.localScale.x+scale);
//		transform.Translate(-Vector3.forward*speedRate);
//		if (limitZ - transform.position.z >= 10) {
//			Destroy (gameObject);
//		}
	}

	void OnCollisionEnter(Collision collision) {

		GameObject.Instantiate (explosion, collision.transform.position, collision.transform.rotation);
		Debug.Log (collision.transform.tag+" destroyed");
		Destroy (collision.gameObject);
//		if (collision.transform.tag == "Bullet") {
//			Bullet bullet = collision.transform.gameObject.GetComponent<Bullet>();
//			hp = hp - bullet.damage;
//			if (hp <= 0) {
//				UIController.IncreaseScore (points);
//				GameObject.Instantiate (explosion, transform.position, transform.rotation);
//				Destroy (gameObject);
//			}
//		}
	}

	void Die() {
		Destroy (gameObject);
	}
}
