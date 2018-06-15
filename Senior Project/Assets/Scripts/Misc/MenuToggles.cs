using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuToggles : MonoBehaviour {
	public GameObject inventory;
	public GameObject skills;
	public GameObject stats;
	public GameObject quit;
	public bool inventoryon;
	public bool skillson;
	public bool statson;
	public bool quiton;
	public Text lightarmortext;
	public Text heavyarmortext;
	public Text bladestext;
	public Text archerytext;
	public Text sneaktext;
	public Text alchemytext;
	public Text smithingtext;
	public Text elementaltext;
	public Text supporttext;
	public Text summontext;
	public Text availablestatpts;
	public Text Level;
	public GameObject player;
	public GameObject lightarmortab;
	public GameObject heavyarmortab;
	public GameObject bladestab;
	public GameObject archerytab;
	public GameObject sneaktab;
	public GameObject alchemytab;
	public GameObject smithingtab;
	public GameObject elementaltab;
	public GameObject supporttab;
	public GameObject summontab;
	public GameObject activeskillinfo;
	public GameObject passiveskillinfo;
	public Text nameactiveskill;
	public Text morractiveskill;
	public Text damageactiveskill;
	public Text costactiveskill;
	public Text accuracyactiveskill;
	public Text targetsactiveskill;
	public Text stunactiveskill;
	public Text magicdmgactiveskill;

	// Use this for initialization
	void Start () {
		inventory.SetActive (true);
		skills.SetActive (false);
		stats.SetActive (false);
		quit.SetActive (false);
		activeskillinfo.SetActive (false);
		inventoryon = true;
		player = GameObject.FindGameObjectWithTag ("Player");
		lightarmortab.SetActive (true);
		heavyarmortab.SetActive (false);
		bladestab.SetActive (false);
		archerytab.SetActive (false);
		sneaktab.SetActive (false);
		alchemytab.SetActive (false);
		smithingtab.SetActive (false);
		elementaltab.SetActive (false);
		supporttab.SetActive (false);
		summontab.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		LevelingSkills lvl = (LevelingSkills)player.GetComponent ("LevelingSkills");
		Level.text = lvl.level.ToString ();
		lightarmortext.text = lvl.lightarmor.ToString ();
		heavyarmortext.text = lvl.heavyarmorshield.ToString ();
		bladestext.text = lvl.blades.ToString ();
		archerytext.text = lvl.archery.ToString ();
		sneaktext.text = lvl.sneak.ToString ();
		alchemytext.text = lvl.alchemy.ToString ();
		smithingtext.text = lvl.smithingenchanting.ToString ();
		elementaltext.text = lvl.elementalm.ToString ();
		supporttext.text = lvl.supportm.ToString ();
		summontext.text = lvl.summonm.ToString ();
		availablestatpts.text = lvl.statpointsavailable.ToString ();
	
	}

	public void ToggleInventory(){
		inventoryon = true;
		skillson = false;
		statson = false;
		quiton = false;
		inventory.SetActive (true);
		skills.SetActive (false);
		stats.SetActive (false);
		quit.SetActive (false);
	}
	public void ToggleSkills(){
		inventoryon = false;
		skillson = true;
		statson = false;
		quiton = false;
		inventory.SetActive (false);
		skills.SetActive (true);
		stats.SetActive (false);
		quit.SetActive (false);
	}
	public void ToggleStats(){
		inventoryon = false;
		skillson = false;
		statson = true;
		quiton = false;
		inventory.SetActive (false);
		skills.SetActive (false);
		stats.SetActive (true);
		quit.SetActive (false);
	}
	public void ToggleQuit(){
		inventoryon = false;
		skillson = false;
		statson = false;
		quiton = true;
		inventory.SetActive (false);
		skills.SetActive (false);
		stats.SetActive (false);
		quit.SetActive (true);
	}
	public void Add(string stat){
		LevelingSkills lvl = (LevelingSkills)player.GetComponent ("LevelingSkills");
		if (stat == "lightarmor") {
			if (lvl.statpointsavailable > 0) {
				lvl.lightarmor++;
				lvl.statpointsavailable--;
			}
		}
		if (stat == "heavyarmor") {
			if (lvl.statpointsavailable > 0) {
				lvl.heavyarmorshield++;
				lvl.statpointsavailable--;
			}
		}
		if (stat == "blades") {
			if (lvl.statpointsavailable > 0) {
				lvl.blades++;
				lvl.statpointsavailable--;
			}
		}
		if (stat == "archery") {
			if (lvl.statpointsavailable > 0) {
				lvl.archery++;
				lvl.statpointsavailable--;
			}
		}
		if (stat == "sneak") {
			if (lvl.statpointsavailable > 0) {
				lvl.sneak++;
				lvl.statpointsavailable--;
			}
		}
		if (stat == "alchemy") {
			if (lvl.statpointsavailable > 0) {
				lvl.alchemy++;
				lvl.statpointsavailable--;
			}
		}
		if (stat == "smithing") {
			if (lvl.statpointsavailable > 0) {
				lvl.smithingenchanting++;
				lvl.statpointsavailable--;
			}
		}
		if (stat == "elemental") {
			if (lvl.statpointsavailable > 0) {
				lvl.elementalm++;
				lvl.statpointsavailable--;
			}
		}
		if (stat == "support") {
			if (lvl.statpointsavailable > 0) {
				lvl.supportm++;
				lvl.statpointsavailable--;
			}
		}
		if (stat == "summon") {
			if (lvl.statpointsavailable > 0) {
				lvl.summonm++;
				lvl.statpointsavailable--;
			}
		}

	}
	public void Subtract(string stat){
		LevelingSkills lvl = (LevelingSkills)player.GetComponent ("LevelingSkills");
		if (stat == "lightarmor") {
			if (lvl.lightarmor > 0) {
				lvl.lightarmor--;
				lvl.statpointsavailable++;
			}
		}
		if (stat == "heavyarmor") {
			if (lvl.heavyarmorshield > 0) {
				lvl.heavyarmorshield--;
				lvl.statpointsavailable++;
			}
		}
		if (stat == "blades") {
			if (lvl.blades > 0) {
				lvl.blades--;
				lvl.statpointsavailable++;
			}
		}
		if (stat == "archery") {
			if (lvl.archery > 0) {
				lvl.archery--;
				lvl.statpointsavailable++;
			}
		}
		if (stat == "sneak") {
			if (lvl.sneak > 0) {
				lvl.sneak--;
				lvl.statpointsavailable++;
			}
		}
		if (stat == "alchemy") {
			if (lvl.alchemy > 0) {
				lvl.alchemy--;
				lvl.statpointsavailable++;
			}
		}
		if (stat == "smithing") {
			if (lvl.smithingenchanting > 0) {
				lvl.smithingenchanting--;
				lvl.statpointsavailable++;
			}
		}
		if (stat == "elemental") {
			if (lvl.elementalm > 0) {
				lvl.elementalm--;
				lvl.statpointsavailable++;
			}
		}
		if (stat == "support") {
			if (lvl.supportm > 0) {
				lvl.supportm--;
				lvl.statpointsavailable++;
			}
		}
		if (stat == "summon") {
			if (lvl.summonm > 0) {
				lvl.summonm--;
				lvl.statpointsavailable++;
			}
		}
	}

	public void skilltab(int tab){
		if (tab == 1) {
			lightarmortab.SetActive (true);
			heavyarmortab.SetActive (false);
			bladestab.SetActive (false);
			archerytab.SetActive (false);
			sneaktab.SetActive (false);
			alchemytab.SetActive (false);
			smithingtab.SetActive (false);
			elementaltab.SetActive (false);
			supporttab.SetActive (false);
			summontab.SetActive (false);
		}
		if (tab == 2) {
			lightarmortab.SetActive (false);
			heavyarmortab.SetActive (true);
			bladestab.SetActive (false);
			archerytab.SetActive (false);
			sneaktab.SetActive (false);
			alchemytab.SetActive (false);
			smithingtab.SetActive (false);
			elementaltab.SetActive (false);
			supporttab.SetActive (false);
			summontab.SetActive (false);
		}
		if (tab == 3) {
			lightarmortab.SetActive (false);
			heavyarmortab.SetActive (false);
			bladestab.SetActive (true);
			archerytab.SetActive (false);
			sneaktab.SetActive (false);
			alchemytab.SetActive (false);
			smithingtab.SetActive (false);
			elementaltab.SetActive (false);
			supporttab.SetActive (false);
			summontab.SetActive (false);
		}
		if (tab == 4) {
			lightarmortab.SetActive (false);
			heavyarmortab.SetActive (false);
			bladestab.SetActive (false);
			archerytab.SetActive (true);
			sneaktab.SetActive (false);
			alchemytab.SetActive (false);
			smithingtab.SetActive (false);
			elementaltab.SetActive (false);
			supporttab.SetActive (false);
			summontab.SetActive (false);
		}
		if (tab == 5) {
			lightarmortab.SetActive (false);
			heavyarmortab.SetActive (false);
			bladestab.SetActive (false);
			archerytab.SetActive (false);
			sneaktab.SetActive (true);
			alchemytab.SetActive (false);
			smithingtab.SetActive (false);
			elementaltab.SetActive (false);
			supporttab.SetActive (false);
			summontab.SetActive (false);
		}
		if (tab == 6) {
			lightarmortab.SetActive (false);
			heavyarmortab.SetActive (false);
			bladestab.SetActive (false);
			archerytab.SetActive (false);
			sneaktab.SetActive (false);
			alchemytab.SetActive (true);
			smithingtab.SetActive (false);
			elementaltab.SetActive (false);
			supporttab.SetActive (false);
			summontab.SetActive (false);
		}
		if (tab == 7) {
			lightarmortab.SetActive (false);
			heavyarmortab.SetActive (false);
			bladestab.SetActive (false);
			archerytab.SetActive (false);
			sneaktab.SetActive (false);
			alchemytab.SetActive (false);
			smithingtab.SetActive (true);
			elementaltab.SetActive (false);
			supporttab.SetActive (false);
			summontab.SetActive (false);
		}
		if (tab == 8) {
			lightarmortab.SetActive (false);
			heavyarmortab.SetActive (false);
			bladestab.SetActive (false);
			archerytab.SetActive (false);
			sneaktab.SetActive (false);
			alchemytab.SetActive (false);
			smithingtab.SetActive (false);
			elementaltab.SetActive (true);
			supporttab.SetActive (false);
			summontab.SetActive (false);
		}
		if (tab == 9) {
			lightarmortab.SetActive (false);
			heavyarmortab.SetActive (false);
			bladestab.SetActive (false);
			archerytab.SetActive (false);
			sneaktab.SetActive (false);
			alchemytab.SetActive (false);
			smithingtab.SetActive (false);
			elementaltab.SetActive (false);
			supporttab.SetActive (true);
			summontab.SetActive (false);
		}
		if (tab == 10) {
			lightarmortab.SetActive (false);
			heavyarmortab.SetActive (false);
			bladestab.SetActive (false);
			archerytab.SetActive (false);
			sneaktab.SetActive (false);
			alchemytab.SetActive (false);
			smithingtab.SetActive (false);
			elementaltab.SetActive (false);
			supporttab.SetActive (false);
			summontab.SetActive (true);
		}
	}

	public void ActiveSkillPointerEnter(GameObject attack){
		Attacks att = (Attacks)attack.GetComponent ("Attacks");
		if (att.active == true) {
			activeskillinfo.SetActive (true);
			nameactiveskill.text = "Name : " + att.attackname;
			damageactiveskill.text = "Damage : " + att.damage.ToString();
			costactiveskill.text = "Cost : " + att.staminacost.ToString();
			accuracyactiveskill.text = "Acc : " + att.accuracy.ToString();
			stunactiveskill.text = "Stun : " + att.stunchance.ToString();
			float totalmagicdmg = att.firedamage += att.icedamage += att.staticdamage;
			magicdmgactiveskill.text = "Magic dmg : " + totalmagicdmg.ToString();
			if (att.allenemies == true) {
				targetsactiveskill.text = "Targets : All";
			} else {
				targetsactiveskill.text = "Targets : 1";
			}
			if (att.range == true) {
				morractiveskill.text = "M or R : R";
			} else {
				morractiveskill.text = "M or R : M";
			}
		}
		if(att.passive == true){
			
		}
	}

	public void ActiveSkillPointerExit(){
		activeskillinfo.SetActive (false);
	}
}
