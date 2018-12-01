using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool podeCriaNuven;
	public Transform[] localNasceInmigo;
	public float tempCriaInimigo;
	public int score;
	[SerializeField] private GameObject[] prefabEnemy;
	[SerializeField] private GameObject[] prefabEnemy02;
	[SerializeField] private GameObject prefabTempestade;
	[SerializeField] private float tempWave02=35;
	public bool Waves01,Fase02,CriouTempestade;
	int aux;
	public float auxTemp,auxTemp02;
	public bool nascerBoss;
	public bool Playlive = true;
	public bool BossLive=true;
	// Use this for initialization
	void Start () {

		instance = this;
		auxTemp = tempCriaInimigo;
	}
	
	// Update is called once per frame
	void Update () {

		if (UiManager.instance.Game) {
		

			if (aux < 5 && !Waves01 && !Fase02) {

				if (tempCriaInimigo <= 0) {

					GameObject inst = Instantiate (prefabEnemy[aux],localNasceInmigo[aux].position, Quaternion.identity);
					aux+=1;
					tempCriaInimigo = auxTemp;
				} else {

					tempCriaInimigo -= Time.deltaTime;
				}
				if (aux == 5) {

					Waves01 = true;
					aux = 0;
					tempCriaInimigo = 10;
				}
			}
			//segunda wave de inimigos
			if (Waves01 && !Fase02) {

				aux = Random.Range (0, 2);
				if (tempCriaInimigo <= 0) {

					GameObject inst = Instantiate (prefabEnemy02 [aux], localNasceInmigo [Random.Range(0,3)].position, Quaternion.identity);
					tempCriaInimigo = auxTemp02;

				} else {
					tempCriaInimigo -= Time.deltaTime;
				}
				tempWave02 -= Time.deltaTime;
				if (tempWave02 <= 0) {

					Fase02 = true;
					tempCriaInimigo = 75;
				}
			}
			//Criando tempestade
			if(Fase02 && !nascerBoss){
				tempCriaInimigo -= Time.deltaTime;
				podeCriaNuven = true;
				if (!CriouTempestade) {

					GameObject inst = Instantiate (prefabTempestade, localNasceInmigo [5].position, Quaternion.identity);
					CriouTempestade = true;
				}
				if (tempCriaInimigo <= 0) {

					nascerBoss = true;
				}
			}

		}
	}
}
