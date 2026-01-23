using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectCartas : MonoBehaviour {

	public GameObject[] cartas;

	//0 -> Rei
	//1 -> Cavaleiro
	//2 -> Bruxa
	//3 -> Fireball
	//4 -> Gigante
	//5 -> Mini Pekka
	//6 -> Mosqueteira

	public void trocaView(int cartaSelecionada){

		for(int i = 0; i < cartas.Length; i++){

			cartas [i].SetActive (i == cartaSelecionada);

		}

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
