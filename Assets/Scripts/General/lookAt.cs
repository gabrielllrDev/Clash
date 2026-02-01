using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour {

	public Vector3 offset;
	public Transform cam;

	Vector3 direcaoOlhar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		direcaoOlhar = cam.position + offset;

		transform.LookAt (direcaoOlhar);
		
	}
}
