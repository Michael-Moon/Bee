using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abelha_Segue : MonoBehaviour {

	[SerializeField] private float velInimigoX,velInimigoY,velInimigoZ,te;
	[SerializeField] private GameObject deadObj;
	bool segue;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {


		teste ();
		if (segue) {

			transform.Translate (velInimigoX * Time.deltaTime, 0, velInimigoZ * Time.deltaTime);
		}

	}
	void teste(){

		if (te > 0) {
			if (velInimigoY >= 0 && velInimigoY <= te) {

				velInimigoY += Time.deltaTime;
			}
			if (velInimigoY > te) {

				velInimigoY = -te;
			}
			if (velInimigoY >= -te && velInimigoY < 0) {

				velInimigoY += Time.deltaTime;
			}
		}

	}

	void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.CompareTag("Player")){

			segue = true;
		}
	}
	void OnCollisionEnter2D(Collision2D col){
	
		if (col.gameObject.CompareTag ("Player")) {
		
			GameObject inst = Instantiate (deadObj, transform.position, Quaternion.identity);
			GameManager.instance.score += 10;
			Destroy (this.gameObject);
		}
		if (col.gameObject.CompareTag ("Bullet")) {

			GameObject inst = Instantiate (deadObj, transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
}
