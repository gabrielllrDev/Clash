using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilScript : MonoBehaviour {

	public bool teamBlue;
	IAScript vidaInimigo;
	vidaTorre vidaTorre_;

	public float danoProjetil;

	public GameObject sangueParticula_;
	GameObject sangueParticula;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){

		if ((other.gameObject.tag == "Tropa" && !teamBlue || other.gameObject.tag == "TropaII" && teamBlue) && other.isTrigger) {

			//alvo = other.transform;

			vidaInimigo = other.GetComponent<IAScript> ();
			vidaInimigo.vida = vidaInimigo.vida - danoProjetil;

			if (vidaInimigo != null && vidaInimigo.vida <= 0) {

				sangueParticula = Instantiate (sangueParticula_);
				sangueParticula.transform.position = vidaInimigo.gameObject.transform.position;
				sangueParticula.SetActive (true);
				Destroy (vidaInimigo.gameObject);

			}

			Destroy (this.gameObject);

		}

		if (other.gameObject.tag == "Torre" && !teamBlue || other.gameObject.tag == "TorreII" && teamBlue) {

			vidaTorre_ = other.GetComponent<vidaTorre> ();
			vidaTorre_.vida = vidaTorre_.vida - danoProjetil;

			Destroy (this.gameObject);


		}

	}
}

