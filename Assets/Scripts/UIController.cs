using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Ship ship;

	public Slider healthBarSlider;
	public Text score;

	public static float totalPoints = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		healthBarSlider.value = (ship.energy * 100f / ship.maxEnergy)/100f;
		score.text = totalPoints.ToString();
	}

	public static void IncreaseScore(float points){
		totalPoints += points;
	}
}
