using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

	public static UiManager instance;

	public RawImage ImgRaw;
	public float vel;
	public Text txtScore;
	public  Button btnPlay,btnRetry;
	public bool Game;
	public Animator painelMenu,painelEnd;

	// Use this for initialization
	void Start () {

		instance = this;
		txtScore = GameObject.Find ("txtScore").GetComponent<Text> ();
		btnPlay = GameObject.Find ("btnPlay").GetComponent<Button> ();
		painelMenu = GameObject.Find ("pMenu").GetComponent<Animator> ();
		painelEnd = GameObject.Find ("pEnd").GetComponent<Animator> ();
		btnRetry = GameObject.Find ("btnRetry").GetComponent<Button> ();




		btnPlay.onClick.AddListener (StartGame);
		btnRetry.onClick.AddListener (Retry);
	}
	
	// Update is called once per frame
	void Update () {

		txtScore.text = GameManager.instance.score.ToString ();

		Rect temp = new Rect (ImgRaw.uvRect);
		temp.x += vel * Time.deltaTime;
		ImgRaw.uvRect = temp;

		if (!GameManager.instance.Playlive || !GameManager.instance.BossLive) {
		
			Game = false;
			painelEnd.Play ("painelEndAnim");
		}
	}
	void StartGame(){
	
		Game = true;
		painelMenu.Play ("painelMenuAnim");
	}
	void Retry(){
	
		SceneManager.LoadScene (0);
	}
}
