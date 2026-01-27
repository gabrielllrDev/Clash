using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playPartida : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	bool sensePresence;

	public Animator cutsceneAnim;

	public static bool partidaRolando;
	// Use this for initialization
	void Start () {

		partidaRolando = false;

	}

	// Update is called once per frame
	void Update () {


		if (sensePresence) {

			if (Input.GetMouseButtonDown (0)) {

				cutsceneAnim.SetBool ("Play", true);
				partidaRolando = true;

			}

		}

	}

	public void OnPointerEnter(PointerEventData eventData){

		sensePresence = true;

	}

	public void OnPointerExit(PointerEventData eventData){

		sensePresence = false;

	}
}
