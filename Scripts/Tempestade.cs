using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tempestade : MonoBehaviour {

	[SerializeField] private float vel;
		
	// Update is called once per frame
	void Update () {

		transform.Translate (vel * Time.deltaTime,0,0);
	}

	void OnTriggerEnter2D (Collider2D col){
	
		if (col.gameObject.CompareTag ("Player")) {
		
			Player_Nave.instance.dead = true;
		}
	}
}
