using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mouseClickAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public Vector3 originalScale;
	Vector3 presenceScale;
	Vector3 clickScale;

	public float presenseSpeed = 5f;
	public float clickSpeed = 0.3f;

	public float presenceOffset = 1;
	public float clickOffset = 1;

	bool sensePresence;
	bool clicked;

	float iPresense;
	float iClick;

	bool changeMove;

	// Use this for initialization
	void Start () {

		iPresense = 0f;
		iClick = 0f;

		sensePresence = false;
		clicked = false;
		changeMove = false;

		originalScale = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		presenceScale = new Vector3 (transform.localScale.x + presenceOffset, transform.localScale.y + presenceOffset, transform.localScale.z + presenceOffset);
		clickScale = new Vector3 (transform.localScale.x - clickOffset, transform.localScale.y - clickOffset, transform.localScale.z - clickOffset);
		
	}
	
	// Update is called once per frame
	void Update () {
	
		iPresense = Mathf.Clamp (iPresense, 0, 1);
		iClick = Mathf.Clamp (iClick, 0, 1);

		if (sensePresence && !clicked) {

			iPresense = iPresense + Time.deltaTime * presenseSpeed;
			transform.localScale = Vector3.Lerp (originalScale, presenceScale, iPresense);

			if (Input.GetMouseButtonDown (0)) {

				clicked = true;

			}

		} 

		if (!sensePresence && !clicked) {

			iPresense = iPresense - Time.deltaTime * presenseSpeed;
			transform.localScale = Vector3.Lerp (originalScale, presenceScale, iPresense);

		}

		if (clicked) {

			if (iClick < 1 && changeMove == false) {

				iClick = iClick + Time.deltaTime * clickSpeed;
				transform.localScale = Vector3.Lerp (presenceScale, clickScale, iClick);

			} else {

				changeMove = true;

				iClick = iClick - Time.deltaTime * clickSpeed;
				transform.localScale = Vector3.Lerp (presenceScale, clickScale, iClick);

				if (iClick <= 0) {

					clicked = false;

				}

			}


		} 

		else {

			changeMove = false;

		}

	}

	public void OnPointerEnter(PointerEventData eventData){

		sensePresence = true;

	}

	public void OnPointerExit(PointerEventData eventData){

		sensePresence = false;

	}
}
