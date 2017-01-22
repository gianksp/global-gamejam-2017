using UnityEngine;
using System.Collections;

public class Shockwave : MonoBehaviour {

//	private Rigidbody _rb;

	public float limitZ;
	public float speedRate=0.75f;

	public float hp = 5f;
	public float points = 5f;

	public GameObject explosion;
	public float scale = 1f;

	// Use this for initialization
	void Start () {
		GameObject.Instantiate (explosion, transform.position, transform.rotation);
		Invoke ("Die", Random.Range(4,6));
		speedRate = Random.Range (1, 4);
		limitZ = GameObject.FindGameObjectWithTag("Player").transform.position.z;
		transform.position = new Vector3 (Random.Range (-30, 30), Random.Range(-15,15), Random.Range(100,300));
		transform.Rotate (new Vector3 (Random.Range (-15, 15), 0, Random.Range (-180, 180)));
//		_rb = gameObject.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		scale += 0.1f;
		transform.localScale = new Vector3(transform.localScale.x+scale,0.01f,transform.localScale.x+scale);
//		transform.Translate(-Vector3.forward*speedRate);
		if (scale >= 11f) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision collision) {

		if (collision.transform.tag == "Obstacle") {
//			Debug.Log (collision.transform.tag + " destroyed");
			if (XHairController.weaponsHot == true) {
				GameObject.Instantiate (explosion, collision.transform.position, collision.transform.rotation);
				Destroy (collision.gameObject);
			}
		}
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
