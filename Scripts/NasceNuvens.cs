using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NasceNuvens : MonoBehaviour {

	[SerializeField] private Transform P1,P2,P3;
	[SerializeField] private GameObject[] objNuvens;
	[SerializeField] private float tempCriar,tempAux;
	public int aux;

	// Use this for initialization
	void Start () {

		P1 = GameObject.Find ("P1").GetComponent<Transform> ();
		P2 = GameObject.Find ("P2").GetComponent<Transform> ();
		P3 = GameObject.Find ("P3").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (UiManager.instance.Game) {
		
			if (!GameManager.instance.podeCriaNuven) {

				Vector3 temp = P3.position;
				temp.y = Random.Range (P1.position.y, P2.position.y);
				P3.position = temp;
				// = Random.Range (P1, P2);

				if (tempCriar <= 0) {

					aux = Random.Range (0, objNuvens.Length);
					GameObject inst = Instantiate (objNuvens [aux], P3.position, Quaternion.identity);
					tempCriar = tempAux;
				} else {

					tempCriar -= Time.deltaTime;
				}
			}
		}
	}
}
