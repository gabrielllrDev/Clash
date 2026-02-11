using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debbugManager : MonoBehaviour {

	public bool speed;
	public float timeScale;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (speed) {

			Time.timeScale = timeScale;

		} 

		else {

			Time.timeScale = 1;

		}
		
	}
}
