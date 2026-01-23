using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class botaoCarta : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	bool isInPlace;

	public int cartaCorrespondente;
	public selectCartas scriptSelecao;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (isInPlace) {

			if (Input.GetMouseButtonDown (0)) {

				scriptSelecao.trocaView (cartaCorrespondente);

			}

		}
		
	}

	public void OnPointerEnter(PointerEventData eventData){

		isInPlace = true;

	}

	public void OnPointerExit(PointerEventData eventData){

		isInPlace = false;

	}
}
