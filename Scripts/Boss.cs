using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public static Boss instance;

	[SerializeField] private float Life;
	[SerializeField]private bool At01,voltar;
	[SerializeField]private float velAt01,velVoltar;
	[SerializeField] private Transform LocalBoss, LocalAtaque;
	[SerializeField] private float tempAtaque,aux;
	[SerializeField] private GameObject deadObj;
	public SpriteRenderer bossSp;



	// Use this for initialization
	void Start () {

		instance = this;

		LocalBoss = GameObject.Find ("LocalBoss").GetComponent<Transform> ();
		LocalAtaque = GameObject.Find ("Ataque01").GetComponent<Transform> ();
		bossSp = GetComponent<SpriteRenderer> ();

		tempAtaque = aux;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (tempAtaque <= 0) {
		
			At01 = true;
			tempAtaque = aux;
		} else {
		
			tempAtaque -= Time.deltaTime;
		}
		if (Life < 500) {
		
			velAt01 = 12.5f;
		}
		if (Life <= 0) {
		

			GameObject inst = Instantiate (deadObj, transform.position, Quaternion.identity);
			GameManager.instance.BossLive = false;
			Destroy (this.gameObject);

		}

		Ataque01 ();

	}
	void OnTriggerEnter2D (Collider2D col){

		if (col.gameObject.CompareTag ("Bullet")) {
		
			Life -= Bullet.instance.Dano;
			bossSp.color = Color.red;
		}else{
			bossSp.color = Color.white;
		}
	}
	void Ataque01(){

		if (At01) {
		
			transform.Translate (velAt01 * Time.deltaTime, 0, 0);

			if (transform.position.x <= LocalAtaque.position.x) {
			
				voltar = true;
				At01 = false;

			}
		} 
		if (voltar) {

			transform.Translate (velVoltar * Time.deltaTime, 0, 0);
			if (transform.position.x >= LocalBoss.position.x) {
				voltar = false;
			}
		}
			
	}	

}
