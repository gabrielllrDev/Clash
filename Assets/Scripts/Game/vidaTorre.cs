using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaTorre : MonoBehaviour {

	public float vida;
	float valorInicialVida;
	public Slider barraVida;

	// Use this for initialization
	void Start () {

		valorInicialVida = vida;
		
	}
	
	// Update is called once per frame
	void Update () {

		barraVida.value = vida / valorInicialVida;


		if (vida <= 0) {

			Destroy (this.gameObject);

		}
		
	}
}
