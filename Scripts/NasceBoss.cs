using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NasceBoss : MonoBehaviour {

	[SerializeField]private GameObject Boss;
	private int i = 0;

	// Update is called once per frame
	void Update () {

		if (GameManager.instance.nascerBoss && i ==0) {
		
			GameObject inst = Instantiate (Boss, transform.position, Quaternion.identity);

			i = 1;
		}
	}
}
