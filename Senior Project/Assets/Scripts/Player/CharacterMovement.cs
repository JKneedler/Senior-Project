 using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public Sprite down;
	public Sprite up;
	public Sprite left;
	public Sprite right;
	public Sprite upleftfoot;
	public Sprite uprightfoot;
	public Sprite downleftfoot;
	public Sprite downrightfoot;
	public Sprite rightleftfoot;
	public Sprite rightrightfoot;
	public Sprite leftleftfoot;
	public Sprite leftrightfoot;
	public SpriteRenderer charactersprite;
	public float speed;
	public string direction;
	public bool moving;
	public Vector3 originalposition;
	public Vector3 endposition;
	public float stepdistance;
	public string lastused;
	public bool leftfoot;
	public bool hitup;
	public bool hitdown;
	public bool hitright;
	public bool hitleft;
	public GameObject animationobj;
	public GameObject dontdestroyvars;
	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		dontdestroyvars = GameObject.FindGameObjectWithTag ("Walk To Battle");
		DontDestroyVars ddv = (DontDestroyVars)dontdestroyvars.GetComponent ("DontDestroyVars");
		player.transform.position = ddv.playerlocation;

	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		StartBattleScene battle = (StartBattleScene)animationobj.GetComponent ("StartBattleScene");
		originalposition = transform.position;
		if (Input.GetKey ("w")) {
			if (battle.move == true) {
				if (moving == false) {
					if (hitup == false) {
						battle.BattleChance ();
						if (battle.move == true) {
							direction = "up";
							charactersprite.sprite = up;
							endposition = originalposition + Vector3.up * .5f;
							leftfoot = !leftfoot;
							moving = true;
						}
					}
				}
			}
		}
		if (Input.GetKey ("s")) {
			if (battle.move == true) {
				if (moving == false) {
					if (hitdown == false) {
						battle.BattleChance ();
						if (battle.move == true) {
							direction = "down";
							charactersprite.sprite = down;
							endposition = originalposition + Vector3.down * .5f;
							leftfoot = !leftfoot;
							moving = true;
						}
					}
				}
			}
		}
		if (Input.GetKey ("d")) {
			if (battle.move == true) {
				if (moving == false) {
					if (hitright == false) {
						battle.BattleChance ();
						if (battle.move == true) {
							direction = "right";
							charactersprite.sprite = right;
							endposition = originalposition + Vector3.right * .5f;
							leftfoot = !leftfoot;
							moving = true;
						}
					}
				}
			}
		}
		if (Input.GetKey ("a")) {
			if (battle.move == true) {
				if (moving == false) {
					if (hitleft == false) {
						battle.BattleChance ();
						if (battle.move == true) {
							direction = "left";
							charactersprite.sprite = left;
							endposition = originalposition + Vector3.left * .5f;
							leftfoot = !leftfoot;
							moving = true;
						}
					}
				}
			}
		}
	}
	void Move(){
		if (direction == "up") {
			if (moving == true) {
				transform.position = Vector2.MoveTowards (transform.position, endposition, speed * Time.deltaTime);
				stepdistance = Vector2.Distance (transform.position, endposition);
				if (stepdistance <= .3f) {
					if (leftfoot == true) {
						charactersprite.sprite = upleftfoot;
					} else {
						charactersprite.sprite = uprightfoot;
					}
				}
			}
			if (moving == true && transform.position == endposition) {
				moving = false;
				charactersprite.sprite = up;
			}
		}
		if (direction == "down") {
			if (moving == true) {
				transform.position = Vector2.MoveTowards (transform.position, endposition, speed * Time.deltaTime);
				stepdistance = Vector2.Distance (transform.position, endposition);
				if (stepdistance <= .3f) {
					if (leftfoot == true) {
						charactersprite.sprite = downleftfoot;
					} else {
						charactersprite.sprite = downrightfoot;
					}
				}
			}
			if (moving == true && transform.position == endposition) {
				moving = false;
				charactersprite.sprite = down;
			}
		}
		if (direction == "right") {
			if (moving == true) {
				transform.position = Vector2.MoveTowards (transform.position, endposition, speed * Time.deltaTime);
				stepdistance = Vector2.Distance (transform.position, endposition);
				if (stepdistance <= .3f) {
					if (leftfoot == true) {
						charactersprite.sprite = rightleftfoot;
					} else {
						charactersprite.sprite = rightrightfoot;
					}
				}
			}
			if (moving == true && transform.position == endposition) {
				moving = false;
				charactersprite.sprite = right;
			}
		}
		if (direction == "left") {
			if (moving == true) {
				transform.position = Vector2.MoveTowards (transform.position, endposition, speed * Time.deltaTime);
				stepdistance = Vector2.Distance (transform.position, endposition);
				if (stepdistance <= .3f) {
					if (leftfoot == true) {
						charactersprite.sprite = leftleftfoot;
					} else {
						charactersprite.sprite = leftrightfoot;
					}
				}
			}
			if (moving == true && transform.position == endposition) {
				moving = false;
				charactersprite.sprite = left;
			}
		}
	}
}
