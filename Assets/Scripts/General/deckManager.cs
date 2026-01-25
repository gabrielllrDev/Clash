using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class deckManager : MonoBehaviour {

	public string[] deckPlayerI;
	public string[] deckPlayerII;

	public statusCarta[] cartasPI;
	public statusCarta[] cartasPII;

	public string playerIName;
	public string playerIIName;

	public Text namePIUI;
	public Text namePIIUI;

	public void defineDecks(){

		for (int i = 0; i < 6; i++) {

			if (cartasPI [i].isSelected) {

				deckPlayerI [cartasPI [i].positionNumber - 1] = cartasPI [i].nomeCarta;
			} 

			if (cartasPII [i].isSelected) {

				deckPlayerII [cartasPII [i].positionNumber - 1] = cartasPII [i].nomeCarta;
			} 

		}

	}

	// Use this for initialization
	void Start () {

		playerIName = "Player 1";
		playerIIName = "Player 2";
		
	}
	
	// Update is called once per frame
	void Update () {

		defineDecks ();

		if (namePIUI.text != "") {

			playerIName = namePIUI.text;

		} 

		else {

			playerIName = "Player 1";

		}

		if (namePIIUI.text != "") {

			playerIIName = namePIIUI.text;

		} 

		else {

			playerIIName = "Player 2";
		}
		
	}
}
