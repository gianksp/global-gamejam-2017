using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlanetInteraction : MonoBehaviour {

	public GameObject explosion;

	public float gazeTime = 2f;
	private float timer;

	private bool gazedAt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gazedAt) 
		{
			
			timer += Time.deltaTime;
			Debug.Log (timer);

			if (timer >= gazeTime) 
			{
				ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current),ExecuteEvents.pointerDownHandler);
				timer = 0f;

			}
		}
		
	}

	public void pointerEnter()
	{
		//Debug.Log ("pointer enter");
		gazedAt = true;
	}

	public void pointerExit()
	{
		//Debug.Log ("pointer exit");
		gazedAt = true;
	}

	public void pointerDown()
	{
		Debug.Log ("pointer down");
		//Instantiate (explosion,new Vector3 (3.85f, 0.9f, 3.51f),Quaternion.identity);
		Destroy (this.gameObject);
	}

}
