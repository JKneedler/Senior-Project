using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour {

	public GameObject attack;
	public GameObject player;
	public bool unlocked;
	public Text reqlevel;
	public Text typereqlevel;
	public GameObject redx;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		redx.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
		Attacks att = (Attacks)attack.GetComponent ("Attacks");
		reqlevel.text = att.reqlevel.ToString();
		typereqlevel.text = att.typereqlevel.ToString();
		LevelingSkills lvlsk = (LevelingSkills)player.GetComponent ("LevelingSkills");
		if (lvlsk.level >= att.reqlevel) {
			if (att.type == "Blades" && lvlsk.blades >= att.typereqlevel) {
				unlocked = true;
			}
			if (att.type == "Archery" && lvlsk.archery >= att.typereqlevel) {
				unlocked = true;
			}
			if (att.type == "Elemental Magic" && lvlsk.elementalm >= att.typereqlevel) {
				unlocked = true;
			}
		}
		if (unlocked == false) {
			redx.SetActive (true);
		}
		if (unlocked == true) {
			redx.SetActive (false);
		}
	
	}
}
