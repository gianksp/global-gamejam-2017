using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public float limitZ;
	public float speedRate=0.75f;
	public float hp = 2f;
	public GameObject explosion;


	// Use this for initialization
	void Start () {
		limitZ = GameObject.FindGameObjectWithTag("Player").transform.position.z;
		speedRate = Random.Range (1, 10);
		float scale = Random.Range (1, 10);
		transform.localScale = new Vector3 (scale,scale,scale);
		transform.position = new Vector3 (Random.Range (-100, 100), Random.Range(-40,40), 520);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-Vector3.forward*speedRate);

		if (limitZ - transform.position.z >= 10) {
			Destroy (gameObject);
		}
	}


		void OnCollisionEnter(Collision collision) {
			if (collision.transform.tag == "Bullet") {
				Bullet bullet = collision.transform.gameObject.GetComponent<Bullet>();
				hp = hp - bullet.damage;
				if (hp <= 0) {
					//UIController.IncreaseScore (points);
					GameObject.Instantiate (explosion, transform.position, transform.rotation);
					Destroy (gameObject);
				}
			}
		}


}
