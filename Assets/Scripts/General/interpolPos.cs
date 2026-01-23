using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interpolPos : MonoBehaviour {

	public Vector3 originalPos;
	public Vector3 finalPos;

	public float moveSpeed = 5f;
	bool goToFinal;

	float i;

	// Use this for initialization
	void Start () {

		i = 0f;
		goToFinal = false;
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position = Vector3.Lerp (originalPos, finalPos, i);
		i = Mathf.Clamp (i, 0, 1);

		if (goToFinal && i < 1) {

			i = i + Time.deltaTime * moveSpeed;

		}

		if (!goToFinal && i > 0) {

			i = i - Time.deltaTime * moveSpeed;

		}
		
	}
}
