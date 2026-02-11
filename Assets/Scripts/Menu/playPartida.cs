using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playPartida : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	bool sensePresence;

	public Animator cutsceneAnim;

	public static bool partidaRolando;

	public GameObject menuSound;
	public GameObject partidaSound;
	public GameObject playSound_;
	GameObject playSound;

	// Use this for initialization
	void Start () {

		partidaRolando = false;

	}

	// Update is called once per frame
	void Update () {


		if (sensePresence) {

			if (Input.GetMouseButtonDown (0)) {

				menuSound.SetActive (false);

				playSound = Instantiate (playSound_);
				playSound.SetActive (true);
				StartCoroutine (somPartida ());

				cutsceneAnim.SetBool ("Play", true);
				partidaRolando = true;

			}

		}

	}

	IEnumerator somPartida(){

		yield return new WaitForSeconds (3);
		partidaSound.SetActive (true);

	}

	public void OnPointerEnter(PointerEventData eventData){

		sensePresence = true;

	}

	public void OnPointerExit(PointerEventData eventData){

		sensePresence = false;

	}
}
