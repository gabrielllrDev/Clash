using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

	public float elixirCost;
	public float elixirCostII;

	[Header("Posicionamento do Player")]

	bool isSelecting;
	bool isSelectingII;
	//Acesso às IDs das cartas em deckManager.deckPlayer
	public deckManager deck;
	//Objeto pai responsável pela manipulação da posição da carta
	public GameObject holoIPosOri;
	public GameObject holoIIPosOri;
	GameObject holoIPos;
	GameObject holoIIPos;
	//Holograma contendo a figura da carta a ser posicionada
	objManager holoI;
	objManager holoII;
	//Distância entre uma posição e outra em x e z
	public float Offset;
	//Limites a não serem ultrapassados nas coordenadas
	public float xLimitInf;
	public float xLimitSup;
	public float xLimitInfII;
	public float xLimitSupII;
	public float zLimitSup;
	public float zLimitInf;

	[Header("UI")]
	public Vector3[] selectPIPosition;
	public Vector3[] selectPIIPosition;

	public Transform SelectI;
	public Transform SelectII;

	int positionID;
	int positionID2;


	[Header("Tropas")]

	public GameObject tropaIOri;
	public GameObject tropaIIOri;

	GameObject tropaI;
	GameObject tropaII;

	// Use this for initialization
	void Start () {

		SelectI.localPosition = selectPIPosition [0];
		SelectII.localPosition = selectPIIPosition [0];

		positionID = 0;
		positionID2 = 0;

		isSelecting = false;
		isSelectingII = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (playPartida.partidaRolando) {

			SelectI.localPosition = selectPIPosition [positionID];
			SelectII.localPosition = selectPIIPosition [positionID2];
			controlSelector ();

			posicionamentoCarta ();

			if (holoIPos != null) {

				holoI = holoIPos.GetComponent<objManager> ();

			}

			if (holoIIPos != null) {

				holoII = holoIIPos.GetComponent<objManager> ();

			}


			if (isSelecting) {

				if (Input.GetKeyDown (KeyCode.W) && (holoIPos.transform.localPosition.z + Offset) <= zLimitSup) {

					holoIPos.transform.position = new Vector3 (holoIPos.transform.position.x, holoIPos.transform.position.y, holoIPos.transform.position.z + Offset);

				}

				if (Input.GetKeyDown (KeyCode.A) && (holoIPos.transform.localPosition.x - Offset) >= xLimitInf) {

					holoIPos.transform.position = new Vector3 (holoIPos.transform.position.x - Offset, holoIPos.transform.position.y, holoIPos.transform.position.z);

				}

				if (Input.GetKeyDown (KeyCode.S) && (holoIPos.transform.localPosition.z - Offset) >= zLimitInf) {

					holoIPos.transform.position = new Vector3 (holoIPos.transform.position.x, holoIPos.transform.position.y, holoIPos.transform.position.z - Offset);

				}

				if (Input.GetKeyDown (KeyCode.D) && (holoIPos.transform.localPosition.x + Offset) <= xLimitSup) {

					holoIPos.transform.position = new Vector3 (holoIPos.transform.position.x + Offset, holoIPos.transform.position.y, holoIPos.transform.position.z);

				}

			}

			if (isSelectingII) {

				if (Input.GetKeyDown (KeyCode.UpArrow) && (holoIIPos.transform.localPosition.z + Offset) <= zLimitSup) {

					holoIIPos.transform.position = new Vector3 (holoIIPos.transform.position.x, holoIIPos.transform.position.y, holoIIPos.transform.position.z + Offset);

				}

				if (Input.GetKeyDown (KeyCode.LeftArrow) && (holoIIPos.transform.localPosition.x - Offset) >= xLimitInfII) {

					holoIIPos.transform.position = new Vector3 (holoIIPos.transform.position.x - Offset, holoIIPos.transform.position.y, holoIIPos.transform.position.z);

				}

				if (Input.GetKeyDown (KeyCode.DownArrow) && (holoIIPos.transform.localPosition.z - Offset) >= zLimitInf) {

					holoIIPos.transform.position = new Vector3 (holoIIPos.transform.position.x, holoIIPos.transform.position.y, holoIIPos.transform.position.z - Offset);

				}

				if (Input.GetKeyDown (KeyCode.RightArrow) && (holoIIPos.transform.localPosition.x + Offset) <= xLimitSupII) {

					holoIIPos.transform.position = new Vector3 (holoIIPos.transform.position.x + Offset, holoIIPos.transform.position.y, holoIIPos.transform.position.z);

				}

			}

		}

		
	}

	void LateUpdate(){

		if (Input.GetKeyDown (KeyCode.LeftShift)) {

			if (isSelecting) {

				if (playPartida.partidaRolando) {

					holoIPos = Instantiate (holoIPosOri);
					holoIPos.transform.position = holoIPosOri.transform.position;
					holoIPos.transform.SetParent (holoIPosOri.transform.parent);
					holoIPos.SetActive (true);

				}

			} 

			else {

				if (elixirSliders.elxIValue >= elixirCost) {

					if (playPartida.partidaRolando) {

						tropaI = Instantiate (tropaIOri);
						tropaI.transform.position = holoIPos.transform.position;
						tropaI.transform.SetParent (holoIPos.transform.parent);
						visibilidadeTropaI ();
						Destroy (holoIPos);
						tropaI.SetActive (true);
						elixirSliders.elxIValue = elixirSliders.elxIValue - elixirCost;

					}

				} 

				else {

					if (playPartida.partidaRolando) {

						isSelecting = !isSelecting;

					}

				}

			}

		}

		if (Input.GetKeyDown (KeyCode.Return)) {

			if (isSelectingII) {

				if (playPartida.partidaRolando) {

					holoIIPos = Instantiate (holoIIPosOri);
					holoIIPos.transform.position = holoIIPosOri.transform.position;
					holoIIPos.transform.SetParent (holoIIPosOri.transform.parent);
					holoIIPos.SetActive (true);

				}

			} 

			else {

				if (elixirSliders.elxIIValue >= elixirCostII) {

					if (playPartida.partidaRolando) {

						tropaII = Instantiate (tropaIIOri);
						tropaII.transform.position = holoIIPos.transform.position;
						tropaII.transform.SetParent (holoIIPos.transform.parent);
						visibilidadeTropaII ();
						Destroy (holoIIPos);
						tropaII.SetActive (true);
						elixirSliders.elxIIValue = elixirSliders.elxIIValue - elixirCostII;

					}

				} 

				else {

					if (playPartida.partidaRolando) {

						isSelectingII = !isSelectingII;

					}

				}

			}

		}

	}

	void posicionamentoCarta(){

		if (Input.GetKeyDown (KeyCode.LeftShift) && playPartida.partidaRolando) {

			isSelecting = !isSelecting;

		}

		if (Input.GetKeyDown (KeyCode.Return) && playPartida.partidaRolando) {

			isSelectingII = !isSelectingII;

		}

		if (playPartida.partidaRolando) {

			visibilidadeHolo ();

		}



	}

	void visibilidadeTropaII(){

		if (tropaII != null) {

			if (deck.deckPlayerII [positionID2] == "Bruxa") {

				for (int i = 0; i < 5; i++) {

					if (i == 0) {

						tropaII.GetComponent<objManager>().obj [i].SetActive (true);

					} 

					else {

						tropaII.GetComponent<objManager>().obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerII [positionID2] == "Cavaleiro") {

				for (int i = 0; i < 5; i++) {

					if (i == 1) {

						tropaII.GetComponent<objManager>().obj [i].SetActive (true);

					} 

					else {

						tropaII.GetComponent<objManager>().obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerII [positionID2] == "Gigante" && tropaII != null) {

				for (int i = 0; i < 5; i++) {

					if (i == 2) {

						tropaII.GetComponent<objManager>().obj [i].SetActive (true);

					} 

					else {

						tropaII.GetComponent<objManager>().obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerII [positionID2] == "MiniP") {

				for (int i = 0; i < 5; i++) {

					if (i == 3) {

						tropaII.GetComponent<objManager>().obj [i].SetActive (true);

					} 

					else {

						tropaII.GetComponent<objManager>().obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerII [positionID2] == "Mosqueteira") {

				for (int i = 0; i < 5; i++) {

					if (i == 4) {

						tropaII.GetComponent<objManager>().obj [i].SetActive (true);

					} 

					else {

						tropaII.GetComponent<objManager>().obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerII [positionID2] == "Fireball") {

				for (int i = 0; i < 5; i++) {


					tropaII.GetComponent<objManager>().obj [i].SetActive (false);


				}

			}

		}

	}

	void visibilidadeTropaI(){
		
		if (tropaI != null) {

			if (deck.deckPlayerI [positionID] == "Bruxa") {

				for (int i = 0; i < 5; i++) {

					if (i == 0) {

						tropaI.GetComponent<objManager>().obj [i].SetActive (true);

					} 

					else {

						tropaI.GetComponent<objManager>().obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerI [positionID] == "Cavaleiro") {

				for (int i = 0; i < 5; i++) {

					if (i == 1) {

						tropaI.GetComponent<objManager>().obj [i].SetActive (true);

					} 

					else {

						tropaI.GetComponent<objManager>().obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerI [positionID] == "Gigante") {

				for (int i = 0; i < 5; i++) {

					if (i == 2) {

						tropaI.GetComponent<objManager>().obj [i].SetActive (true);

					} 

					else {

						tropaI.GetComponent<objManager>().obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerI [positionID] == "MiniP") {

				for (int i = 0; i < 5; i++) {

					if (i == 3) {

						tropaI.GetComponent<objManager>().obj [i].SetActive (true);

					} 

					else {

						tropaI.GetComponent<objManager>().obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerI [positionID] == "Mosqueteira") {

				for (int i = 0; i < 5; i++) {

					if (i == 4) {

						tropaI.GetComponent<objManager>().obj [i].SetActive (true);

					} 

					else {

						tropaI.GetComponent<objManager>().obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerI [positionID] == "Fireball") {

				for (int i = 0; i < 5; i++) {


					tropaI.GetComponent<objManager>().obj [i].SetActive (false);


				}

			}

		}

	}

	void visibilidadeHolo(){

		if (holoI != null) {

			if (deck.deckPlayerI [positionID] == "Bruxa") {

				elixirCost = 0.5f;

				for (int i = 0; i < 5; i++) {

					if (i == 0) {

						holoI.obj [i].SetActive (true);

					} 

					else {

						holoI.obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerI [positionID] == "Cavaleiro") {

				elixirCost = 0.3f;

				for (int i = 0; i < 5; i++) {

					if (i == 1) {

						holoI.obj [i].SetActive (true);

					} 

					else {

						holoI.obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerI [positionID] == "Gigante") {

				elixirCost = 0.5f;

				for (int i = 0; i < 5; i++) {

					if (i == 2) {

						holoI.obj [i].SetActive (true);

					} 

					else {

						holoI.obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerI [positionID] == "MiniP") {

				elixirCost = 0.4f;

				for (int i = 0; i < 5; i++) {

					if (i == 3) {

						holoI.obj [i].SetActive (true);

					} 

					else {

						holoI.obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerI [positionID] == "Mosqueteira") {

				elixirCost = 0.4f;

				for (int i = 0; i < 5; i++) {

					if (i == 4) {

						holoI.obj [i].SetActive (true);

					} 

					else {

						holoI.obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerI [positionID] == "Fireball") {

				elixirCost = 0.4f;

				for (int i = 0; i < 5; i++) {


					holoI.obj [i].SetActive (false);


				}

			}

		}

		if (holoII != null) {

			if (deck.deckPlayerII [positionID2] == "Bruxa") {

				elixirCostII = 0.5f;

				for (int i = 0; i < 5; i++) {

					if (i == 0) {

						holoII.obj [i].SetActive (true);

					} 

					else {

						holoII.obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerII [positionID2] == "Cavaleiro") {

				elixirCostII = 0.3f;

				for (int i = 0; i < 5; i++) {

					if (i == 1) {

						holoII.obj [i].SetActive (true);

					} 

					else {

						holoII.obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerII [positionID2] == "Gigante" && holoII != null) {

				elixirCostII = 0.5f;

				for (int i = 0; i < 5; i++) {

					if (i == 2) {

						holoII.obj [i].SetActive (true);

					} 

					else {

						holoII.obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerII [positionID2] == "MiniP") {

				elixirCostII = 0.4f;

				for (int i = 0; i < 5; i++) {

					if (i == 3) {

						holoII.obj [i].SetActive (true);

					} 

					else {

						holoII.obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerII [positionID2] == "Mosqueteira") {

				elixirCostII = 0.4f;

				for (int i = 0; i < 5; i++) {

					if (i == 4) {

						holoII.obj [i].SetActive (true);

					} 

					else {

						holoII.obj [i].SetActive (false);

					}

				}

			}

			if (deck.deckPlayerII [positionID2] == "Fireball") {

				elixirCostII = 0.4f;

				for (int i = 0; i < 5; i++) {


					holoII.obj [i].SetActive (false);


				}

			}

		}

	}

	void controlSelector(){

		if (!isSelecting) {

			if (Input.GetKeyDown (KeyCode.A)) {

				if (positionID != 0) {

					positionID--;

				} 

				else {

					positionID = 3;

				}

			}

			if (Input.GetKeyDown (KeyCode.D)) {

				if (positionID != 3) {

					positionID++;

				} 

				else {

					positionID = 0;

				}

			}

		}

		if (!isSelectingII) {

			if (Input.GetKeyDown (KeyCode.LeftArrow)) {

				if (positionID2 != 0) {

					positionID2--;

				} 

				else {

					positionID2 = 3;

				}

			}

			if (Input.GetKeyDown (KeyCode.RightArrow)) {

				if (positionID2 != 3) {

					positionID2++;

				} 

				else {

					positionID2 = 0;

				}

			}

		}

	}
}
