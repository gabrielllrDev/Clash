using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class botaoCarta : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	bool isInPlace;

	public int cartaCorrespondente;
	public selectCartas scriptSelecao;

	public static bool selectingCarta;
	public Animator anim;
	public statusCarta statusDaCarta;

	public static statusCarta statusDaCartaNS; //NS = Não selecionada

	public static bool disableNonSelectedAnimations;

	public static int posicaoCartaTroca;
	public static int posicaoCartaSelecionadaTroca;

	// Use this for initialization
	void Start () {

		selectingCarta = false;
		disableNonSelectedAnimations = false;

		posicaoCartaTroca = 1;
		posicaoCartaSelecionadaTroca = 1;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (disableNonSelectedAnimations) {

			anim.SetBool ("selectingCarta", false);


		}

		if (isInPlace) {

			if (Input.GetMouseButtonDown (0)) {

				scriptSelecao.trocaView (cartaCorrespondente);

				//if (!statusDaCarta.isSelected && !selectingCarta) {

				//	selectingCarta = true;
				//	posicaoCartaTroca = statusDaCarta.positionNumber;
				//	anim.SetBool ("selectingCarta", true);

				//	statusDaCartaNS = statusDaCarta;
				//}

				if (!statusDaCarta.isSelected && selectingCarta) {

					if (statusDaCarta.positionNumber == posicaoCartaTroca) {

						disableNonSelectedAnimations = true;

						StartCoroutine (desativaBooleana ());
						StartCoroutine (desativaAnimacaoCartaSelecionada ());

					} 

					else {

						disableNonSelectedAnimations = true;
						StartCoroutine (desativaEAtivaBooleana ());

					}

				}

				if (statusDaCarta.isSelected && selectingCarta) {

					selectingCarta = false;
					disableNonSelectedAnimations = true;

					statusDaCarta.realizaTroca = true;
					statusDaCartaNS.realizaTroca = true;

					posicaoCartaSelecionadaTroca = statusDaCarta.positionNumber;

					StartCoroutine (desativaBooleana ());

				}



			}

		}
		
	}

	void LateUpdate(){

		if (isInPlace) {

			if (Input.GetMouseButtonDown (0)) {

				scriptSelecao.trocaView (cartaCorrespondente);

				if (!statusDaCarta.isSelected && !selectingCarta) {

					selectingCarta = true;
					posicaoCartaTroca = statusDaCarta.positionNumber;
					anim.SetBool ("selectingCarta", true);

					statusDaCartaNS = statusDaCarta;
				}

			}

		}

	}
		

	IEnumerator desativaAnimacaoCartaSelecionada(){

		yield return new WaitForSeconds (0.0001f);
		selectingCarta = false;

	}

	public static IEnumerator desativaBooleana(){

		yield return new WaitForSeconds (0.0001f);
		disableNonSelectedAnimations = false;

	}

	IEnumerator desativaEAtivaBooleana(){

		yield return new WaitForSeconds (0.0001f);
		disableNonSelectedAnimations = false;
		posicaoCartaTroca = statusDaCarta.positionNumber;
		statusDaCartaNS = statusDaCarta;
		anim.SetBool ("selectingCarta", true);

	}

	public void OnPointerEnter(PointerEventData eventData){

		isInPlace = true;

	}

	public void OnPointerExit(PointerEventData eventData){

		isInPlace = false;

	}
}
