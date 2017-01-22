using UnityEngine;
using System.Collections;

public class Eye : MonoBehaviour {

	private Rigidbody _rb;

	public float hp = 10f;

	public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.transform.tag == "Bullet") {
			hp -= 1;
			if (hp <= 0) {
				GameObject.Instantiate (explosion, transform.position, transform.rotation);
				gameObject.SetActive (false);
			} else {
			
			}
//			Bullet bullet = collision.transform.gameObject.GetComponent<Bullet>();
//			hp = hp - bullet.damage;
//			if (hp <= 0) {
//				UIController.IncreaseScore (points);
//				GameObject.Instantiate (explosion, transform.position, transform.rotation);
//				Destroy (gameObject);
//			}
		}

		Debug.Log ("Hit eye "+hp.ToString());
	}
}
