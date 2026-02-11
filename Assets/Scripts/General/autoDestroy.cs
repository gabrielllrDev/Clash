using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine (autoDestruir ());
		
	}

	IEnumerator autoDestruir (){

		yield return new WaitForSeconds (7);
		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
