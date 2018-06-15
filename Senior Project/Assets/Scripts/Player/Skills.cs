using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skills : MonoBehaviour {
	public GameObject activeattack1;
	public GameObject activeattack2;
	public GameObject activeattack3;
	public GameObject activeattack4;
	public Text attack1text;
	public Text attack2text;
	public Text attack3text;
	public Text attack4text;
	public GameObject activemagic1;
	public GameObject activemagic2;
	public GameObject activemagic3;
	public GameObject activemagic4;
	public Text magic1text;
	public Text magic2text;
	public Text magic3text;
	public Text magic4text;
	public GameObject selectedattack;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (activeattack1 != null) {
			Attacks att = (Attacks)activeattack1.GetComponent ("Attacks");
			attack1text.text = att.attackname;
		} else {
			attack1text.text = "";
		}
		if (activeattack2 != null) {
			Attacks att = (Attacks)activeattack2.GetComponent ("Attacks");
			attack2text.text = att.attackname;
		} else {
			attack2text.text = "";
		}
		if (activeattack3 != null) {
			Attacks att = (Attacks)activeattack3.GetComponent ("Attacks");
			attack3text.text = att.attackname;
		} else {
			attack3text.text = "";
		}
		if (activeattack4 != null) {
			Attacks att = (Attacks)activeattack4.GetComponent ("Attacks");
			attack4text.text = att.attackname;
		} else {
			attack4text.text = "";
		}

		if (activemagic1 != null) {
			Attacks att = (Attacks)activemagic1.GetComponent ("Attacks");
			magic1text.text = att.attackname;
		} else {
			magic1text.text = "";
		}
		if (activemagic2 != null) {
			Attacks att = (Attacks)activemagic2.GetComponent ("Attacks");
			magic2text.text = att.attackname;
		} else {
			magic2text.text = "";
		}
		if (activemagic3 != null) {
			Attacks att = (Attacks)activemagic3.GetComponent ("Attacks");
			magic3text.text = att.attackname;
		} else {
			magic3text.text = "";
		}
		if (activemagic4 != null) {
			Attacks att = (Attacks)activemagic4.GetComponent ("Attacks");
			magic4text.text = att.attackname;
		} else {
			magic4text.text = "";
		}
	
	}

	public void SelectSkill(GameObject skillbutton){
		SkillButton skb = (SkillButton)skillbutton.GetComponent ("SkillButton");
		if (skb.unlocked == true) {
			selectedattack = skb.attack;
		}
	}

	public void EquipSkill(int slot){
		if (selectedattack != null) {
			Attacks att = (Attacks)selectedattack.GetComponent ("Attacks");
			if (att.physical == true) {
				if (slot == 11) {
					activeattack1 = selectedattack;
				}
				if (slot == 12) {
					activeattack2 = selectedattack;
				}
				if (slot == 13) {
					activeattack3 = selectedattack;
				}
				if (slot == 14) {
					activeattack4 = selectedattack;
				}
			}
			if (att.magic == true) {
				if (slot == 21) {
					activemagic1 = selectedattack;
				}
				if (slot == 22) {
					activemagic2 = selectedattack;
				}
				if (slot == 23) {
					activemagic3 = selectedattack;
				}
				if (slot == 24) {
					activemagic4 = selectedattack;
				}
			}
		}
	}
}
