using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class SwitchScene : MonoBehaviour {
	public GameObject enemyobject1;
	public GameObject enemyobject2;
	public GameObject enemyobject3;
	public GameObject nullenemy;
	public GameObject nondestroy;
	public GameObject player;

	// Use this for initialization
	void Start () {
		nondestroy = GameObject.FindGameObjectWithTag ("Walk To Battle");
		player = GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Animationgo(int enemy1, int enemy2, int enemy3){
		DontDestroyVars vars = (DontDestroyVars)nondestroy.GetComponent ("DontDestroyVars");
		Skills sk = (Skills)player.GetComponent ("Skills");
		if (sk.activeattack1 != null) {
			vars.attack1 = sk.activeattack1;
		} else {
			vars.attack1 = sk.activeattack1;
		}
		if (sk.activeattack2 != null) {
			vars.attack2 = sk.activeattack2;
		} else {
			vars.attack2 = sk.activeattack1;
		}
		if (sk.activeattack3 != null) {
			vars.attack3 = sk.activeattack3;
		} else {
			vars.attack3 = sk.activeattack1;
		}
		if (sk.activeattack4 != null) {
			vars.attack4 = sk.activeattack4;
		} else {
			vars.attack4 = sk.activeattack1;
		}
		if (sk.activemagic1 != null) {
			vars.magic1 = sk.activemagic1;
		} else {
			vars.magic1 = sk.activemagic1;
		}
		if (sk.activemagic2 != null) {
			vars.magic2 = sk.activemagic2;
		} else {
			vars.magic2 = sk.activemagic1;
		}
		if (sk.activemagic3 != null) {
			vars.magic3 = sk.activemagic3;
		} else {
			vars.magic3 = sk.activemagic1;
		}
		if (sk.activemagic4 != null) {
			vars.magic4 = sk.activemagic4;
		} else {
			vars.magic4 = sk.activemagic1;
		}
		if (enemy1 == 1) {
			vars.enem1 = enemyobject1;
		}
		if (enemy1 == 2) {
			vars.enem1 = enemyobject2;
		}
		if (enemy1 == 3) {
			vars.enem1 = enemyobject3;
		}
		if (enemy1 == 4) {
			vars.enem1 = nullenemy;
		}
		if (enemy2 == 1) {
			vars.enem2 = enemyobject1;
		}
		if (enemy2 == 2) {
			vars.enem2 = enemyobject2;
		}
		if (enemy2 == 3) {
			vars.enem2 = enemyobject3;
		}
		if (enemy2 == 4) {
			vars.enem2 = nullenemy;
		}
		if (enemy3 == 1) {
			vars.enem3 = enemyobject1;
		}
		if (enemy3 == 2) {
			vars.enem3 = enemyobject2;
		}
		if (enemy3 == 3) {
			vars.enem3 = enemyobject3;
		}
		if (enemy3 == 4) {
			vars.enem3 = nullenemy;
		}
		StartCoroutine (Waittime ());
	}

	IEnumerator Waittime(){
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene ("Battle");
	}
}
