using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Estado{

	Andando,
	Perseguindo,
	Atacando,
	AtacandoTorre

}

public class IAScript : MonoBehaviour {

	public GameObject nextPoint;
	public GameObject[] point;

	public GameObject p1I;
	public GameObject p1II;
	public GameObject p2I;
	public GameObject p2II;
	public GameObject p3I;
	public GameObject p3II;

	public GameObject torrePrincessI;
	public GameObject torrePrincessII;
	public GameObject torrePrincessRedI;
	public GameObject torrePrincessRedII;

	public Transform alvo;

	Animator anim;

	public int i;

	Vector3 targetPos;

	public Estado estado;

	public IAScript vidaInimigo;
	public vidaTorre vidaTorre_;
	public bool teamBlue;
	public bool ignoreEnemys;

	public float vida;
	float valorInicialVida;
	public float dano;
	public float velocidadeAtaque;
	public float tempoRepouso;
	public float distanciaAtaque;
	public float distanciaAtivaPerseguicao;

	bool coroutineAtivada;

	public Slider barraVida;

	bool atacouTorrePrincesa;

	float distancia;

	public GameObject sangueParticula_;
	GameObject sangueParticula;

	public GameObject projetil_;
	GameObject projetil;
	public bool ataqueADistancia;

	// Use this for initialization
	void Start () {

		atacouTorrePrincesa = false;

		valorInicialVida = vida;

		coroutineAtivada = false;

		estado = Estado.Andando;

		anim = GetComponent<Animator> ();

		i = 0;

		if (this.transform.parent.localPosition.z >= 1.5) {

			point [0] = p1I;
			point [1] = p2I;
			point [2] = p3I;

			if (!teamBlue && torrePrincessI == null) {

				atacouTorrePrincesa = true;

			}

			if (teamBlue && torrePrincessRedI == null) {

				atacouTorrePrincesa = true;

			}

		} 

		else {

			point [0] = p1II;
			point [1] = p2II;
			point [2] = p3II;

			if (!teamBlue && torrePrincessII == null) {

				atacouTorrePrincesa = true;

			}

			if (teamBlue && torrePrincessRedII == null) {

				atacouTorrePrincesa = true;

			}

		}

		StartCoroutine (enableAnim ());

	}

	IEnumerator danoTorre(){

		coroutineAtivada = false;

		if (estado == Estado.AtacandoTorre) {

			yield return new WaitForSeconds (velocidadeAtaque);

			if (vidaTorre_ != null) {

				if (ataqueADistancia) {

					projetil = Instantiate (projetil_);
					projetil.transform.position = this.transform.position;
					projetil.transform.LookAt (alvo);

					projetil.GetComponentInChildren<projetilScript>().teamBlue = teamBlue;
					projetil.GetComponentInChildren<projetilScript>().danoProjetil = dano;

					projetil.SetActive (true);

				} 


				else {

					vidaTorre_.vida = vidaTorre_.vida - dano;

				}

			}
				
			yield return new WaitForSeconds (tempoRepouso);
			StartCoroutine (danoTorre ());

		}

	}

	IEnumerator danoInimigo(){

		coroutineAtivada = false;

		if (estado == Estado.Atacando) {

			yield return new WaitForSeconds (velocidadeAtaque);

			if (vidaInimigo != null) {

				if (ataqueADistancia) {

					projetil = Instantiate (projetil_);
					projetil.transform.position = this.transform.position;
					projetil.transform.LookAt (alvo);

					projetil.GetComponentInChildren<projetilScript>().teamBlue = teamBlue;
					projetil.GetComponentInChildren<projetilScript>().danoProjetil = dano;

					projetil.SetActive (true);

				} 

				else {

					vidaInimigo.vida = vidaInimigo.vida - dano;

				}

			}
				
			yield return new WaitForSeconds (tempoRepouso);
			StartCoroutine (danoInimigo ());

		}

	}

	IEnumerator enableAnim(){

		yield return new WaitForSeconds (3f);
		this.gameObject.GetComponent<Animator> ().enabled = true;

	}
	
	// Update is called once per frame
	void Update () {

		if (alvo != null) {

			distancia = Vector3.Distance (transform.position, alvo.position);

			//Debug.Log (distancia);

		}

		barraVida.value = vida / valorInicialVida;

		switch (estado) {

		case Estado.Andando:

			anim.SetBool ("Atacando", false);

			if (i < 4) {

				nextPoint = point [i];

			} 

			else {

				nextPoint = point [3];

			}

			if ((i == 3 && !atacouTorrePrincesa || i == 4 && atacouTorrePrincesa) && vidaTorre_ != null && anim.enabled == true && !ataqueADistancia) {

				estado = Estado.AtacandoTorre;
				atacouTorrePrincesa = true;

				if (!coroutineAtivada) {

					StartCoroutine (danoTorre ());
					coroutineAtivada = true;

				}

			}

			break;

		case Estado.Atacando:

			anim.SetBool ("Atacando", true);

			if (alvo != null) {

				nextPoint = alvo.gameObject;

			} 

			else {

				estado = Estado.Andando;

			}


			if (distancia > (distanciaAtaque + 3.2f) && anim.enabled == true) {

				estado = Estado.Perseguindo;

			}

			if (vidaInimigo != null && vidaInimigo.vida <= 0) {

				sangueParticula = Instantiate (sangueParticula_);
				sangueParticula.transform.position = alvo.position;
				sangueParticula.SetActive (true);
				Destroy (alvo.gameObject);
				estado = Estado.Andando;

			}


			break;

		case Estado.Perseguindo:

			anim.SetBool ("Atacando", false);

			if (alvo != null) {

				nextPoint = alvo.gameObject;

			}

			if (distancia <= distanciaAtaque && anim.enabled == true) {

				estado = Estado.Atacando;

				if (!coroutineAtivada) {

					StartCoroutine (danoInimigo ());
					coroutineAtivada = true;

				}

			}

			if (alvo == null) {

				estado = Estado.Andando;

			}

			break;

		case Estado.AtacandoTorre:

			anim.SetBool ("Atacando", true);

			if (vidaTorre_ == null || vidaTorre_.vida <= 0) {

			estado = Estado.Andando;

			}

			break;

		}

		if (nextPoint != null) {

			targetPos = nextPoint.transform.position;
			targetPos.y = transform.position.y;
			transform.LookAt (targetPos);

		}
		
	}


	void OnTriggerStay(Collider other){

		if (estado == Estado.Andando && alvo != null) {

			distancia = Vector3.Distance (transform.position, alvo.position);

			if (distancia <= distanciaAtivaPerseguicao && (i != 1 || i == 1 && vidaInimigo.i == 1) && anim.enabled == true && (other.gameObject.tag == "Tropa" && !teamBlue || other.gameObject.tag == "TropaII" && teamBlue) && !ignoreEnemys) {

				estado = Estado.Perseguindo;

			}

		}

	}
		

	void OnTriggerEnter(Collider other){

		switch (estado) {

		case Estado.Andando:
			if (other.gameObject.tag == "IAPoint" && estado == Estado.Andando) {

				//if (i < 4) {

					i++;

				//}

			}

			if ((other.gameObject.tag == "Tropa" && !teamBlue || other.gameObject.tag == "TropaII" && teamBlue) && !ignoreEnemys) {

				alvo = other.transform;
				//estado = Estado.Perseguindo;

				vidaInimigo = other.GetComponent<IAScript> ();

			}

			if (other.gameObject.tag == "Torre" && !teamBlue || other.gameObject.tag == "TorreII" && teamBlue) {

				alvo = other.transform;
				vidaTorre_ = other.GetComponent<vidaTorre> ();

				if (ataqueADistancia && anim.enabled == true) {

					estado = Estado.AtacandoTorre;
					StartCoroutine (danoTorre ());

				}

			}

			break;

		case Estado.Atacando:
			break;

		case Estado.Perseguindo:

			if (teamBlue && other.gameObject.tag == "BaseAzul" || !teamBlue && other.gameObject.tag == "BaseRed") {

				i = 0;

			}

			break;

		}

	}
}