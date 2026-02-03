using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EstadoTorre{

	Idle,
	Atacando

}

public class towerIA : MonoBehaviour {

	public bool isKing;
	public bool teamBlue;
	public GameObject princessTowerI;
	public GameObject princessTowerII;
	public GameObject projetil_;
	GameObject projetil;
	public EstadoTorre estado;
	public Transform alvo;
	public IAScript vidaInimigo;
	Animator anim;
	public float velocidadeAtaque;
	public float tempoRepouso;
	public float dano;

	public Transform canhaoPosition;

	bool ativouCoroutine;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();

		ativouCoroutine = false;
		
	}

	IEnumerator danoInimigo(){

		if (estado == EstadoTorre.Atacando) {

			yield return new WaitForSeconds (velocidadeAtaque);

			if (vidaInimigo != null) {

				projetil = Instantiate (projetil_);

				if (isKing) {

					projetil.transform.position = canhaoPosition.position;

				} 

				else {

					projetil.transform.position = this.transform.position;

				}
			
				projetil.transform.LookAt (alvo);

				projetil.GetComponentInChildren<projetilScript> ().teamBlue = teamBlue;
				projetil.GetComponentInChildren<projetilScript> ().danoProjetil = dano;

				projetil.SetActive (true);

			}

			yield return new WaitForSeconds (tempoRepouso);
			StartCoroutine (danoInimigo ());

		}
	}
	
	// Update is called once per frame
	void Update () {

		switch (estado) {

		case EstadoTorre.Idle:

			ativouCoroutine = false;

			if (!isKing) {

				anim.SetBool ("Atacando", false);

			}

			break;

		case EstadoTorre.Atacando:

			if (!isKing) {

				anim.SetBool ("Atacando", true);

			}

			if (alvo == null) {
				
				estado = EstadoTorre.Idle;

			}

			break;


		}
		
	}

	//void OnTriggerStay(Collider other){

	//	if (estado == EstadoTorre.Idle) {

	//		if (other.gameObject.tag == "Tropa" && !teamBlue || other.gameObject.tag == "TropaII" && teamBlue) {

	//			if (isKing && (princessTowerI == null || princessTowerII == null)) {

	//				alvo = other.transform;
	//				vidaInimigo = other.GetComponent<IAScript> ();

	//				estado = EstadoTorre.Atacando;
	//				StartCoroutine (danoInimigo ());

	//			}

	//		}

	//	}

	//}

	void OnTriggerStay(Collider other){

		switch (estado) {

		case EstadoTorre.Idle:
			
			if (other.gameObject.tag == "Tropa" && !teamBlue || other.gameObject.tag == "TropaII" && teamBlue) {

				alvo = other.transform;
				vidaInimigo = other.GetComponent<IAScript> ();

				if (!isKing || isKing && (princessTowerI == null || princessTowerII == null)) {

					estado = EstadoTorre.Atacando;

					if (!ativouCoroutine) {

						ativouCoroutine = true;
						StartCoroutine (danoInimigo ());

					}

				}

			}

			break;

		}

	}
}
