using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartBattleScene : MonoBehaviour {
	public int maxnum;
	public int minnum;
	public int randnum;
	public GameObject switchobject;
	public bool move = true;
	public int enemy1 = 0;
	public int enemy2 = 0;
	public int enemy3 = 0;
	public Animator anim;
	public int jumphash = Animator.StringToHash("Enter Battle");
	public GameObject dontdestroyvar;
	public GameObject player;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		dontdestroyvar = GameObject.FindGameObjectWithTag ("Walk To Battle");
		player = GameObject.FindGameObjectWithTag ("Player");
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void BattleChance(){
		randnum = Random.Range (minnum, maxnum);
		if (randnum <= 7) {
			move = false;
			DontDestroyVars ddv = (DontDestroyVars)dontdestroyvar.GetComponent ("DontDestroyVars");
			LevelingSkills lvl = (LevelingSkills)player.GetComponent("LevelingSkills");
			lvl.Save ();
			ddv.playerlocation = player.transform.position;
			int randnum1 = Random.Range (0, 10);
			int randnum2 = Random.Range (0, 10);
			int randnum3 = Random.Range (0, 10);
			if (randnum1 <= 2) {
				enemy1 = 1;
			}
			if (randnum1 == 3 || randnum1 == 4) {
				enemy1 = 2;
			}
			if (randnum1 == 5) {
				enemy1 = 3;
			}
			if (randnum1 >= 6) {
				enemy1 = 4;
			}
			if (randnum2 <= 2) {
				enemy2 = 1;
			}
			if (randnum2 == 3 || randnum2 == 4) {
				enemy2 = 2;
			}
			if (randnum2 == 5) {
				enemy2 = 3;
			}
			if (randnum2 >= 6) {
				enemy2 = 4;
			}
			if (randnum3 <= 2) {
				enemy3 = 1;
			}
			if (randnum3 == 3 || randnum3 == 4) {
				enemy3 = 2;
			}
			if (randnum3 == 5) {
				enemy3 = 3;
			}
			if (randnum3 >= 6) {
				enemy3 = 4;
			}
			if (enemy1 == 4 && enemy2 == 4 && enemy3 == 4) {
				enemy1 = 1;
			}
			SwitchScene change = (SwitchScene)switchobject.GetComponent ("SwitchScene");
			anim.SetTrigger (jumphash);
			change.Animationgo (enemy1, enemy2, enemy3);
		}
	}
}
