using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveEmitter : MonoBehaviour {

	public float rotMin = -90;
	public float rotMax = 90;

	public float scaleMin;
	public float scaleMax;

	//color

	public float timeMin;
	public float timeMax;

	private float timer;
	public float interval = 5;

	public GameObject prefab;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if (timer >= interval) {
			deploy ();
			timer = 0;
		}

		
	}

	public void deploy()
	{

		//interval
		timer = Random.Range(3f,10f);
		//rotation
		float rotZ = Random.Range (rotMin, rotMax);


		//scale
		float scaleRate = Random.Range(scaleMin,scaleMax);

		//timer
		float interval = Random.Range(timeMin,timeMax);

		prefab.GetComponent<Shockwave>().scaleRate = scaleRate;

		Quaternion rotation = Quaternion.Euler(0, 0, rotZ);

		Instantiate(prefab,new Vector3(-2.011646f,-0.8410382f,21.08f),rotation);

	}
}
