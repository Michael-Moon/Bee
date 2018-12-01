using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deadAll : MonoBehaviour {


	[SerializeField] private float tempo;
		
	// Update is called once per frame
	void Update () {

		if (tempo <= 0) {
		
			Destroy (this.gameObject);
		} else {
		
			tempo -= Time.deltaTime;
		}
	}
}
