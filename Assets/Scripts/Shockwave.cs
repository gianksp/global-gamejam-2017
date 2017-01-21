using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour {

	public float timer;
	public float scaleRate = 0.01f;
	public float limit = 5f;




	// Use this for initialization
	void Start () {
		//transform.position = new Vector3 (Random.Range (-10, 10), Random.Range(-10,10), 0);


		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer <= limit) 
		{
			transform.localScale += new Vector3(scaleRate*timer,0 , scaleRate*timer);
		}
		else
		{
			Destroy (this.gameObject);
		}

		
	}

	public void OnCollisionEnter(Collision col)
	{
		Debug.Log ("super nova hit");
		Destroy (col.transform.gameObject);

	}
}
