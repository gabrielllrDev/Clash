using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

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

				holoIPos = Instantiate (holoIPosOri);
				holoIPos.transform.position = holoIPosOri.transform.position;
				holoIPos.transform.SetParent (holoIPosOri.transform.parent);
				holoIPos.SetActive (true);

			} 

			else {

				Destroy (holoIPos);

			}

		}

		if (Input.GetKeyDown (KeyCode.Return)) {

			if (isSelectingII) {

				holoIIPos = Instantiate (holoIIPosOri);
				holoIIPos.transform.position = holoIIPosOri.transform.position;
				holoIIPos.transform.SetParent (holoIIPosOri.transform.parent);
				holoIIPos.SetActive (true);

			} 

			else {

				Destroy (holoIIPos);

			}

		}

	}

	void posicionamentoCarta(){

		if (Input.GetKeyDown (KeyCode.LeftShift)) {

			isSelecting = !isSelecting;

		}

		if (Input.GetKeyDown (KeyCode.Return)) {

			isSelectingII = !isSelectingII;

		}

		visibilidadeHolo ();



	}

	void visibilidadeHolo(){

		if (holoI != null) {

			if (deck.deckPlayerI [positionID] == "Bruxa") {

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

				for (int i = 0; i < 5; i++) {


					holoI.obj [i].SetActive (false);


				}

			}

		}

		if (holoII != null) {

			if (deck.deckPlayerII [positionID2] == "Bruxa") {

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
