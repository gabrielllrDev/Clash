using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statusPartida : MonoBehaviour {

	public GameObject cenaPartida;

	public static bool kingBlueDown;
	public static bool kingRedDown;

	public Text minuto;
	public Text segundos;
	bool morteSubita;

	int minutoInt;
	int segundosInt;

	public static int pontosI;
	public static int pontosII;

	public Text pontosIText;
	public Text pontosIIText;

	public Text namePIUI;
	public Text namePIIUI;

	public Text p1GameName;
	public Text p1GameNameShadow;
	public Text p2GameName;
	public Text p2GameNameShadow;

	public GameObject p1WinScene;
	public GameObject p2WinScene;

	// Use this for initialization
	void Start () {

		kingBlueDown = false;
		kingRedDown = false;

		morteSubita = false;

		minutoInt = 3;
		segundosInt = 0;

		pontosI = 0;
		pontosII = 0;

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

		p1GameName.text = namePIUI.text;
		p1GameNameShadow.text = namePIUI.text;
		p2GameName.text = namePIIUI.text;
		p2GameNameShadow.text = namePIIUI.text;

		minuto.text = minutoInt.ToString ();

		pontosIText.text = pontosI.ToString ();
		pontosIIText.text = pontosII.ToString ();

		if (segundosInt < 10) {

			segundos.text = "0" + segundosInt.ToString ();

		} 

		else {

			segundos.text = segundosInt.ToString ();

		}

		if (minutoInt == 0 && segundosInt == 0) {

			if (pontosI == pontosII) {

				if (!morteSubita) {

					minutoInt = 2;
					//morteSubita = true;

				} 

				else {

					//empate

				}

			} 

			else {

				if (pontosI > pontosII) {

					p1WinScene.SetActive (true);
					cenaPartida.SetActive (false);

				} 

				else {

					p2WinScene.SetActive (true);
					cenaPartida.SetActive (false);

				}

			}

		}

		if (kingBlueDown) {

			pontosII = 3;
			minutoInt = 0;
			segundosInt = 0;

		}

		if (kingRedDown) {

			pontosI = 3;
			minutoInt = 0;
			segundosInt = 0;

		}
		
	}
}
