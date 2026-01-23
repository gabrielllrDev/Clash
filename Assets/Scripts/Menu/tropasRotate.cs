using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class tropasRotate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public Transform tropas;
	public bool rotacionaEsquerda;

	public float moveSpeed = 50f;

	float i;

	bool sensePresence;

	public Vector3 originalScale;
	Vector3 presenceScale;

	// Use this for initialization
	void Start () {

		i = 0f;
		sensePresence = false;

		originalScale = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		presenceScale = new Vector3 (transform.localScale.x + 0.5f, transform.localScale.y + 0.5f, transform.localScale.z + 0.5f);

	}
	
	// Update is called once per frame
	void Update () {

		i =  Mathf.Clamp (i, 0, 1);
		transform.localScale = Vector3.Lerp (originalScale, presenceScale, i);

		if (sensePresence) {

			i = i + Time.deltaTime * 15;

			if (!rotacionaEsquerda) {

				tropas.Rotate (0, -moveSpeed * Time.deltaTime, 0);
			} 

			else {

				tropas.Rotate (0, moveSpeed * Time.deltaTime, 0);

			}


		} 

		else {

			i = i - Time.deltaTime * 15;

		}
		
	}

	public void OnPointerEnter(PointerEventData eventData){

		sensePresence = true;

	}

	public void OnPointerExit(PointerEventData eventData){

		sensePresence = false;

	}
}
