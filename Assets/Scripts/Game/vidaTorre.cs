using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaTorre : MonoBehaviour {

	public float vida;
	float valorInicialVida;
	public Slider barraVida;

	public bool teamBlue;
	public bool isKing;

	// Use this for initialization
	void Start () {

		valorInicialVida = vida;
		
	}
	
	// Update is called once per frame
	void Update () {

		barraVida.value = vida / valorInicialVida;

		if (vida <= 0) {

			if (teamBlue) {

				if (isKing) {

					statusPartida.kingBlueDown = true;

				} 

				else {

					statusPartida.pontosII++;

				}

			} 

			else {

				if (isKing) {

					statusPartida.kingRedDown = true;

				} 

				else {

					statusPartida.pontosI++;

				}

			}

			Destroy (this.gameObject);

		}
		
	}
}
