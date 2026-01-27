using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class elixirSliders : MonoBehaviour {

	public Slider sliderI;
	public Slider sliderII;

	public static float elxIValue;
	public static float elxIIValue;

	public float chargeSpeed = 5f;

	// Use this for initialization
	void Start () {

		elxIValue = 1;
		elxIIValue = 1;
		
	}
	
	// Update is called once per frame
	void Update () {

		elxIValue = Mathf.Clamp (elxIValue, 0, 1);
		elxIIValue = Mathf.Clamp (elxIIValue, 0, 1);

		sliderI.value = elxIValue;
		sliderII.value = elxIIValue;

		elxIValue = elxIValue + Time.deltaTime * chargeSpeed;
		elxIIValue = elxIIValue + Time.deltaTime * chargeSpeed;
		
	}
}
