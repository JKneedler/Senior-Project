using UnityEngine;
using System.Collections;

public class CollisionCheck : MonoBehaviour {

	public bool up;
	public bool down;
	public bool right;
	public bool left;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		CharacterMovement charmove = (CharacterMovement)player.GetComponent ("CharacterMovement");
		if (up == true) {
			charmove.hitup = true;
		}
		if (down == true) {
			charmove.hitdown = true;
		}
		if (left == true) {
			charmove.hitleft = true;
		}
		if (right == true) {
			charmove.hitright = true;
		}
	}
	void OnTriggerExit2D(Collider2D coll){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		CharacterMovement charmove = (CharacterMovement)player.GetComponent ("CharacterMovement");
		if (up == true) {
			charmove.hitup = false;
		}
		if (down == true) {
			charmove.hitdown = false;
		}
		if (left == true) {
			charmove.hitleft = false;
		}
		if (right == true) {
			charmove.hitright = false;
		}
	}
}
