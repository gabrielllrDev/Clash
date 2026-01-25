using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class enterDeckEdit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public Animator camAnim;
	public Animator UIAnim;

	bool isInPlace;
	bool deckEditor;

	public bool deckII;

	public selectCartas TropasMenu;
	public Transform tropasRotation;


	// Use this for initialization
	void Start () {

		isInPlace = false;
		deckEditor = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (isInPlace) {

			if (Input.GetMouseButtonDown (0)) {

				deckEditor = !deckEditor;

				if (deckEditor) {

					TropasMenu.trocaView (0);
					tropasRotation.rotation = Quaternion.Euler (-20.823f, -182.045f, 0);

				} 

				else {

					botaoCarta.selectingCarta = false;
					botaoCarta.disableNonSelectedAnimations = true;

					StartCoroutine (botaoCarta.desativaBooleana ());

				}

			}

		}
			

		if (deckII) {

			camAnim.SetBool ("deckEditorII", deckEditor);
			UIAnim.SetBool ("deckEditorII", deckEditor);

		} 

		else {

			camAnim.SetBool ("deckEditor", deckEditor);
			UIAnim.SetBool ("deckEditor", deckEditor);

		}
		
	}

	public void OnPointerEnter(PointerEventData eventData){

		isInPlace = true;

	}

	public void OnPointerExit(PointerEventData eventData){

		isInPlace = false;

	}
}
