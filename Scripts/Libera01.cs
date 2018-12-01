using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Libera01 : MonoBehaviour {

	public static Libera01 instance;
	public bool move;

	void Start(){
	
		instance = this;
	}
	void OnTriggerEnter2D(Collider2D col){
	
		if (col.gameObject.CompareTag ("Player")) {
		
			move = true;
		}
	}
}
