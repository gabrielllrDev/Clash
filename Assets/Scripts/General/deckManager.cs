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

	public Canvas canvas;
	public Camera menuCam;
	public Camera gameCam;

	[Header("Game")]

	public Text p1GameName;
	public Text p2GameName;

	public Texture[] texturesCartas; //1 Bruxa, 2 Cavaleiro, 3 Fireball, 4 Gigante, 5 Mini P, 6 Mosqueteira
	public RawImage[] deckGameI;
	public RawImage[] deckGameII;

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

	void defineDecksPartida(){

		for (int i = 0; i < 4; i++) {

			if (deckPlayerI [i] == "Bruxa") {

				deckGameI [i].texture = texturesCartas [0];

			}

			if (deckPlayerI [i] == "Cavaleiro") {

				deckGameI [i].texture = texturesCartas [1];

			}

			if (deckPlayerI [i] == "Fireball") {

				deckGameI [i].texture = texturesCartas [2];

			}

			if (deckPlayerI [i] == "Gigante") {

				deckGameI [i].texture = texturesCartas [3];

			}

			if (deckPlayerI [i] == "MiniP") {

				deckGameI [i].texture = texturesCartas [4];

			}

			if (deckPlayerI [i] == "Mosqueteira") {

				deckGameI [i].texture = texturesCartas [5];

			}

			if (deckPlayerII [i] == "Bruxa") {

				deckGameII [i].texture = texturesCartas [0];

			}

			if (deckPlayerII [i] == "Cavaleiro") {

				deckGameII [i].texture = texturesCartas [1];

			}

			if (deckPlayerII [i] == "Fireball") {

				deckGameII [i].texture = texturesCartas [2];

			}

			if (deckPlayerII [i] == "Gigante") {

				deckGameII [i].texture = texturesCartas [3];

			}

			if (deckPlayerII [i] == "MiniP") {

				deckGameII [i].texture = texturesCartas [4];

			}

			if (deckPlayerII [i] == "Mosqueteira") {

				deckGameII [i].texture = texturesCartas [5];

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

		defineDecksPartida ();

		p1GameName.text = playerIName;
		p2GameName.text = playerIIName;

		if (menuCam.isActiveAndEnabled) {

			canvas.worldCamera = menuCam;

		} 

		else {

			canvas.worldCamera = gameCam;

		}

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
