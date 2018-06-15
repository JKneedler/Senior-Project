using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetupBattle : MonoBehaviour {
	public GameObject reqvars;
	public GameObject spawn1;
	public GameObject spawn2;
	public GameObject spawn3;
	public GameObject spawn4;
	public GameObject spawn5;
	public int numenemies;
	public int curnumenemies;
	public GameObject enemy1instant;
	public GameObject enemy2instant;
	public GameObject enemy3instant;
	public GameObject nullobj;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject attack1;
	public GameObject attack2;
	public GameObject attack3;
	public GameObject attack4;
	public GameObject magic1;
	public GameObject magic2;
	public GameObject magic3;
	public GameObject magic4;
	public Text attack1gui;
	public Text attack2gui;
	public Text attack3gui;
	public Text attack4gui;
	public Text magic1gui;
	public Text magic2gui;
	public Text magic3gui;
	public Text magic4gui;
	public GameObject attack1button;
	public GameObject attack2button;
	public GameObject attack3button;
	public GameObject attack4button;
	public GameObject magic1button;
	public GameObject magic2button;
	public GameObject magic3button;
	public GameObject magic4button;



	// Use this for initialization
	void Awake () {
		enemy1instant = nullobj;
		enemy2instant = nullobj;
		enemy3instant = nullobj;
		reqvars = GameObject.FindGameObjectWithTag ("Walk To Battle");
		DontDestroyVars vars = (DontDestroyVars)reqvars.GetComponent("DontDestroyVars");
		attack1 = vars.attack1;
		attack2 = vars.attack2;
		attack3 = vars.attack3;
		attack4 = vars.attack4;
		Attacks atttext1 = (Attacks)attack1.GetComponent ("Attacks");
		Attacks atttext2 = (Attacks)attack2.GetComponent ("Attacks");
		Attacks atttext3 = (Attacks)attack3.GetComponent ("Attacks");
		Attacks atttext4 = (Attacks)attack4.GetComponent ("Attacks");
		attack1gui.text = atttext1.attackname;
		attack2gui.text = atttext2.attackname;
		attack3gui.text = atttext3.attackname;
		attack4gui.text = atttext4.attackname;
		magic1 = vars.magic1;
		magic2 = vars.magic2;
		magic3 = vars.magic3;
		magic4 = vars.magic4;
		Attacks magtext1 = (Attacks)magic1.GetComponent ("Attacks");
		Attacks magtext2 = (Attacks)magic2.GetComponent ("Attacks");
		Attacks magtext3 = (Attacks)magic3.GetComponent ("Attacks");
		Attacks magtext4 = (Attacks)magic4.GetComponent ("Attacks");
		magic1gui.text = magtext1.attackname;
		magic2gui.text = magtext2.attackname;
		magic3gui.text = magtext3.attackname;
		magic4gui.text = magtext4.attackname;
		if (vars.enem1 != nullobj) {
			enemy1instant = vars.enem1;
			numenemies ++;
		}
		if (vars.enem2 != nullobj) {
			if (numenemies == 0) {
				enemy1instant = vars.enem2;
			}
			if (numenemies == 1) {
				enemy2instant = vars.enem2;
			}
			numenemies++;
		}
		if (vars.enem3 != nullobj) {
			if (numenemies == 0) {
				enemy1instant = vars.enem3;
			}
			if (numenemies == 1) {
				enemy2instant = vars.enem3;
			}
			if (numenemies == 2) {
				enemy3instant = vars.enem3;
			}
			numenemies++;
		}
		if (numenemies == 1) {
			Rigidbody en1 = enemy1instant.gameObject.GetComponent<Rigidbody> ();
			Instantiate (en1, spawn3.transform.position, Quaternion.identity);
			enemy1 = GameObject.FindGameObjectWithTag ("Enemy");
			enemy1.tag = "Clone";
		}
		if (numenemies == 2) {
			Rigidbody en1 = enemy1instant.gameObject.GetComponent<Rigidbody> ();
			Instantiate (en1, spawn2.transform.position, Quaternion.identity);
			enemy1 = GameObject.FindGameObjectWithTag ("Enemy");
			enemy1.tag = "Clone";
			Rigidbody en2 = enemy2instant.gameObject.GetComponent<Rigidbody> ();
			Instantiate (en2, spawn4.transform.position, Quaternion.identity);
			enemy2 = GameObject.FindGameObjectWithTag ("Enemy");
			enemy2.tag = "Clone";
		}
		if (numenemies == 3) {
			Rigidbody en1 = enemy1instant.gameObject.GetComponent<Rigidbody> ();
			Instantiate (en1, spawn1.transform.position, Quaternion.identity);
			enemy1 = GameObject.FindGameObjectWithTag ("Enemy");
			enemy1.tag = "Clone";
			Rigidbody en2 = enemy2instant.gameObject.GetComponent<Rigidbody> ();
			Instantiate (en2, spawn3.transform.position, Quaternion.identity);
			enemy2 = GameObject.FindGameObjectWithTag ("Enemy");
			enemy2.tag = "Clone";
			Rigidbody en3 = enemy3instant.gameObject.GetComponent<Rigidbody> ();
			Instantiate (en3, spawn5.transform.position, Quaternion.identity);
			enemy3 = GameObject.FindGameObjectWithTag ("Enemy");
			enemy3.tag = "Clone";
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
