using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Ship ship;

	public Slider healthBarSlider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		healthBarSlider.value = (ship.energy * 100f / ship.maxEnergy)/100f;
	}
}
