using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusCarta : MonoBehaviour {

	public bool isSelected;

	public Vector3[] selectedPos;
	public Vector3[] nonSelectedPos;

	public int positionNumber;

	Animator anim;

	public bool realizaTroca;

	float i;
	float trocaSpeed = 5f;


	// Use this for initialization
	void Start () {

		i = 0;

		realizaTroca = false;

		anim = GetComponent<Animator> ();

		if (isSelected) {

			this.transform.localPosition = new Vector3 (selectedPos [positionNumber - 1].x, selectedPos [positionNumber - 1].y, selectedPos [positionNumber - 1].z);

		} 

		else {

			this.transform.localPosition = new Vector3(nonSelectedPos [positionNumber - 1].x, nonSelectedPos [positionNumber - 1].y, nonSelectedPos [positionNumber - 1].z);

		}
		
	}
	
	// Update is called once per frame
	void Update () {

		if (isSelected) {

			this.transform.localPosition = Vector3.Lerp (selectedPos [positionNumber - 1], nonSelectedPos [botaoCarta.posicaoCartaTroca - 1], i);

		} 

		else {

			this.transform.localPosition = Vector3.Lerp (nonSelectedPos [positionNumber - 1], selectedPos [botaoCarta.posicaoCartaSelecionadaTroca - 1], i);

		}
			
		i = Mathf.Clamp (i, 0, 1);

		if (isSelected) {

			anim.SetBool ("selectingCarta", botaoCarta.selectingCarta);

		}

		if (realizaTroca) {

			trocaPosicoes ();

		} 

		else {

			//i = 0;

		}
		
	}

	void trocaPosicoes(){

		if (i < 1) {

			i = i + Time.deltaTime * trocaSpeed;

		} 

		else {

			if (isSelected) {


				isSelected = false;
				i = 0;
				positionNumber = botaoCarta.posicaoCartaTroca;

			} 

			else {

				isSelected = true;
				i = 0;
				positionNumber = botaoCarta.posicaoCartaSelecionadaTroca;

			}

			realizaTroca = false;

		}

	}


}
