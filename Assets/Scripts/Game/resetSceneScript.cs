using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.SceneManagement;

public class resetSceneScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler  {

	bool isPressed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (isPressed && Input.GetMouseButtonDown (0)) {

			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		}


	}

	public void OnPointerEnter(PointerEventData eventData){

		isPressed = true;


	}

	public void OnPointerExit(PointerEventData eventData){

		isPressed = false;


	}
}