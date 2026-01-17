using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingBlink : MonoBehaviour {

	public SkinnedMeshRenderer blendShapes;
	bool trocaMov;
	public float moveSpeed = 5f;
	float valorAbertura;
	int Pisca = 2;
	bool enableAnim;

	float delayPiscada;

	// Use this for initialization
	void Start () {

		trocaMov = true;
		valorAbertura = 0;

		StartCoroutine (ativaPiscada ());
		
	}

	IEnumerator ativaPiscada(){

		enableAnim = true;
		delayPiscada = Random.Range (0.1f, 5f);
		yield return new WaitForSeconds (delayPiscada);
		StartCoroutine (ativaPiscada ());

	}

	void animacaoPiscar(){

		if (trocaMov) {

			valorAbertura = valorAbertura + Time.deltaTime * moveSpeed;

			if (valorAbertura >= 100) {

				trocaMov = !trocaMov;

			}

		} 

		else {

			valorAbertura = valorAbertura - Time.deltaTime * moveSpeed;

			if (valorAbertura <= 0) {

				trocaMov = !trocaMov;
				enableAnim = false;

			}

		}

	}
	
	// Update is called once per frame
	void Update () {

		blendShapes.SetBlendShapeWeight (Pisca, valorAbertura);

		if (enableAnim) {

			animacaoPiscar ();

		}


		
	}
}
