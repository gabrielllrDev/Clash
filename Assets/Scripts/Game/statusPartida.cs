using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statusPartida : MonoBehaviour {

	public Text minuto;
	public Text segundos;

	int minutoInt;
	int segundosInt;

	// Use this for initialization
	void Start () {

		minutoInt = 3;
		segundosInt = 0;

		StartCoroutine (iniciaContagem ());

	}

	IEnumerator iniciaContagem(){

		yield return new WaitForSeconds (1);

		if (segundosInt == 0) {

			segundosInt = 59;
			minutoInt--;

		} 

		else {

			segundosInt--;

		}

		StartCoroutine (iniciaContagem ());

	}
	
	// Update is called once per frame
	void Update () {

		minuto.text = minutoInt.ToString ();

		if (segundosInt < 10) {

			segundos.text = "0" + segundosInt.ToString ();

		} 

		else {

			segundos.text = segundosInt.ToString ();

		}
		
	}
}
