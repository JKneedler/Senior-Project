using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour {
	public float maxhealth;
	public float curhealth;
	public int speed;
	public string enemyname;
	public GameObject attack1;
	public GameObject attack2;
	public GameObject attack3;
	public GameObject battlecontroller;
	public GameObject activeattack;
	public GameObject player;
	public bool dead;
	public bool active = true;
	public int expgain;

	// Use this for initialization
	void Start () {
		battlecontroller = GameObject.FindGameObjectWithTag ("Battle");
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (curhealth <= 0) {
			dead = true;
		}
		if(curhealth > 0){
			dead = false;
		}
	
	}

	public void ChooseAttack(){
		int randnum = Random.Range (1, 3);
		if (randnum == 1) {
			activeattack = attack1;
		}
		if (randnum == 2) {
			activeattack = attack2;
		}
		if (randnum == 3) {
			activeattack = attack3;
		}
	}

	public void DoDamage(){
		PLayerBattle pbattle = (PLayerBattle)player.GetComponent ("PLayerBattle");
		Attacks att = (Attacks)activeattack.GetComponent ("Attacks");
		pbattle.TakeDamage (att.enemydamage);
	}

	public void TakeDamage(float damage){
		curhealth -= damage;
	}
}
