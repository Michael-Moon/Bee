using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public static Bullet instance;

	public float Dano;
	[SerializeField] private float velBullet;
	[SerializeField] private float LifeBullet;
	[SerializeField] private GameObject fireBull;

	void Start(){
	
		instance = this;
	}
	// Update is called once per frame
	void Update () {

		transform.Translate (new Vector3 (velBullet * Time.deltaTime, 0 , 0));

		if (LifeBullet <= 0) {
		
			Destroy (this.gameObject);
		} else {
		
			LifeBullet -= Time.deltaTime;
		}
	}
	void OnTriggerEnter2D(Collider2D col){
	
		if(col.gameObject.CompareTag("Enemy")){


			Destroy (this.gameObject);
		}

		if (col.gameObject.CompareTag ("Obj")) {

			GameObject inst = Instantiate (fireBull, transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}

	}
	void OnCollisionEnter2D(Collision2D col){
	

		if (col.gameObject.CompareTag ("bomb")) {

			GameObject inst = Instantiate (fireBull, transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}
	}

}
