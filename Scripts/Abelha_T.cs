using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abelha_T : MonoBehaviour {



	[SerializeField] private float velInimigoX,velInimigoY,velInimigoZ,te;
	[SerializeField] private float vel;
	[SerializeField] private GameObject deadObj;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {


		if (Libera01.instance.move) {
		
			transform.Translate (velInimigoX * Time.deltaTime, velInimigoY * Time.deltaTime, velInimigoZ * Time.deltaTime);
		}




	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.CompareTag ("Bullet")) {

			GameObject inst = Instantiate (deadObj, transform.position, Quaternion.identity);
			GameManager.instance.score += 10;
			Destroy (this.gameObject);
		}
		if (col.gameObject.CompareTag ("Player")) {

			GameObject inst = Instantiate (deadObj, transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
}
