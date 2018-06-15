using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PLayerBattle : MonoBehaviour {
	public GameObject reqvars;
	public int speed;
	public float maxhealth;
	public float curhealth;
	public Slider healthslider;
	public float maxmana;
	public float curmana;
	public Slider manaslider;
	public float maxstamina;
	public float curstamina;
	public Slider staminaslider;
	public float weapondamage;

	// Use this for initialization
	void Awake () {
		reqvars = GameObject.FindGameObjectWithTag ("Walk To Battle");
		DontDestroyVars vars = (DontDestroyVars)reqvars.GetComponent("DontDestroyVars");
		speed = vars.speed;
	}
	
	// Update is called once per frame
	void Update () {
		healthslider.value = (curhealth / maxhealth);
		manaslider.value = (curmana / maxmana);
		staminaslider.value = (curstamina / maxstamina);
	}

	public void DoDamage(GameObject target, GameObject attack){
		EnemyAI enem1 = (EnemyAI)target.GetComponent ("EnemyAI");
		Attacks att = (Attacks)attack.GetComponent ("Attacks");
		float damage = att.damage * weapondamage;
		enem1.TakeDamage (damage);
		curstamina -= att.staminacost;
		curmana -= att.manacost;
	}

	public void TakeDamage(float damage){
		curhealth -= damage;
	}
}
