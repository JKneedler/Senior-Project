using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelingSkills : MonoBehaviour {
	public int lightarmor;
	public int heavyarmorshield;
	public int blades;
	public int archery;
	public int sneak;
	public int alchemy;
	public int smithingenchanting;
	public int elementalm;
	public int supportm;
	public int summonm;
	public int statpointsavailable;
	public int level;
	public float curexp;
	public float maxexp;
	public Slider levelingbar;
	public GameObject playervars;

	// Use this for initialization
	void Start () {
		playervars = GameObject.FindGameObjectWithTag ("Walk To Battle");
		DontDestroyVars ddv = (DontDestroyVars)playervars.GetComponent ("DontDestroyVars");
		lightarmor = ddv.lightarmor;
		heavyarmorshield = ddv.heavyarmorshield;
		blades = ddv.blades;
		archery = ddv.archery;
		sneak = ddv.sneak;
		alchemy = ddv.alchemy;
		smithingenchanting = ddv.smithingenchanting;
		elementalm = ddv.elementalm;
		supportm = ddv.supportm;
		summonm = ddv.summonm;
		statpointsavailable = ddv.statpointsavailable;
		level = ddv.level;
		curexp = ddv.curexp;
		maxexp = ddv.maxexp;
		curexp += ddv.expadd;
		ddv.expadd = 0;
	}

	public void Save (){
		DontDestroyVars ddv = (DontDestroyVars)playervars.GetComponent ("DontDestroyVars");
		ddv.lightarmor = lightarmor;
		ddv.heavyarmorshield = heavyarmorshield;
		ddv.blades = blades;
		ddv.archery = archery;
		ddv.sneak = sneak;
		ddv.alchemy = alchemy;
		ddv.smithingenchanting = smithingenchanting;
		ddv.elementalm = elementalm;
		ddv.supportm = supportm;
		ddv.summonm = summonm;
		ddv.statpointsavailable = statpointsavailable;
		ddv.level = level;
		ddv.curexp = curexp;
		ddv.maxexp = maxexp;
	}
	
	// Update is called once per frame
	void Update () {
		levelingbar.value = (curexp / maxexp);
		if (curexp >= maxexp) {
			level++;
			curexp -= maxexp;
			statpointsavailable += 10;
			maxexp += 50;
		}
	}
}
