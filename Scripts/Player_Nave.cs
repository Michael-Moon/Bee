using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Nave : MonoBehaviour {

	public static Player_Nave instance;


	[SerializeField] private Rigidbody2D NaveRB;
	[SerializeField] private float VelNave;
	[SerializeField] private Transform BulletFireTranform;
	[SerializeField] private GameObject objBullet;
	[SerializeField] private GameObject objExplo;
	[SerializeField] private float CadenceFire;
	[SerializeField] private float AuxCadence;
	[SerializeField] private Animator FireGunAnim;
	[SerializeField] private AudioSource somFx;
	[SerializeField] private AudioSource som;
	public bool dead;

	void Awake(){
	
		instance = this;
	}

	// Use this for initialization
	void Start () {

		NaveRB = GetComponent<Rigidbody2D> ();
		BulletFireTranform = GameObject.Find ("Fire").GetComponent<Transform> ();
		FireGunAnim = GameObject.Find ("fireGun").GetComponent<Animator> ();

		somFx = GetComponent<AudioSource> ();
		som.mute = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (UiManager.instance.Game) {
		
			som.mute = false;
			//Move Player Nave
			MovimentoNave ();
			//Fire 
			if (CadenceFire <= 0) {

				FireBulletNormal ();
			} else {

				CadenceFire -= Time.deltaTime;
				FireGunAnim.SetBool ("fire", false);
				FireGunAnim.SetBool ("stop", true);
			}

			if (dead == true) {

				GameManager.instance.Playlive = false;
				GameObject inst = Instantiate (objExplo, transform.position, Quaternion.identity);
				UiManager.instance.Game = false;
				Destroy (this.gameObject);

			}
		}


	}
	void MovimentoNave(){
	
		float verti = Input.GetAxis ("Vertical") * VelNave;
		float hori = Input.GetAxis ("Horizontal") * VelNave;

		transform.Translate (hori, verti, 0);
	}
	void FireBulletNormal(){
	
		if (Input.GetKey(KeyCode.K)) {
		
			FireGunAnim.SetBool ("fire", true);
			FireGunAnim.SetBool ("stop", false);
			GameObject inst = Instantiate (objBullet, BulletFireTranform.position, Quaternion.identity);
			somFx.Play ();

			CadenceFire = AuxCadence;
		} 
	}
	void OnTriggerEnter2D(Collider2D col){
	
		if (col.gameObject.CompareTag ("Enemy")) {
			dead = true;

		}
	}
	void OnCollisionEnter2D (Collision2D col){
	
		if (col.gameObject.CompareTag ("A.segue")) {

			dead = true;

		}
	}
}
