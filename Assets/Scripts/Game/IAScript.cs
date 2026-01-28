using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAScript : MonoBehaviour {

	public GameObject nextPoint;
	public GameObject[] point;

	public GameObject p1I;
	public GameObject p1II;
	public GameObject p2I;
	public GameObject p2II;
	public GameObject p3I;
	public GameObject p3II;

	int i;

	Vector3 targetPos;

	// Use this for initialization
	void Start () {

		i = 0;

		if (this.transform.parent.localPosition.z >= 1.5) {

			point [0] = p1I;
			point [1] = p2I;
			point [2] = p3I;

		} 

		else {

			point [0] = p1II;
			point [1] = p2II;
			point [2] = p3II;

		}

		StartCoroutine (enableAnim ());

	}

	IEnumerator enableAnim(){

		yield return new WaitForSeconds (3f);
		this.gameObject.GetComponent<Animator> ().enabled = true;

	}
	
	// Update is called once per frame
	void Update () {

		nextPoint = point [i];

		targetPos = nextPoint.transform.position;
		targetPos.y = transform.position.y;

		transform.LookAt (targetPos);
		
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "IAPoint") {

			if (i < 2) {

				i++;

			}

		}

	}
}