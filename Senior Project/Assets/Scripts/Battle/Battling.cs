using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battling : MonoBehaviour {
	public GameObject setupbattle;
	public GameObject commentarygui;
	public Text commentarytext;
	public GameObject choicesgui;
	public GameObject option1gui;
	public GameObject optionattackgui;
	public GameObject optioninventorygui;
	public GameObject optionmagicgui;
	public GameObject optionrungui;
	public GameObject backbutton;
	public GameObject player;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject firstperson;
	public GameObject secondperson;
	public GameObject thirdperson;
	public GameObject fourthperson;
	public GameObject playermove;
	public GameObject enemy1move;
	public GameObject enemy2move;
	public GameObject enemy3move;
	public GameObject thisturnattack;
	public GameObject selectbutton1;
	public GameObject selectbutton2;
	public GameObject selectbutton3;
	public GameObject selectbutton4;
	public GameObject selectbutton5;
	public GameObject selectbutton22;
	public GameObject targetenemy;
	public GameObject enemyhealthbar1;
	public GameObject enemyhealthbar2;
	public GameObject enemyhealthbar3;
	public GameObject enemyhealthbar4;
	public GameObject enemyhealthbar5;
	public GameObject deadenemy1;
	public GameObject deadenemy2;
	public GameObject deadenemy3;
	public int personturnnum;
	public bool allenemiesdead;
	public bool endbattletext;
	public int exppool;
	public GameObject playervars;


	// Use this for initialization
	void Start () {
		commentarygui.SetActive (false);
		choicesgui.SetActive (true);
		option1gui.SetActive (true);
		optionattackgui.SetActive (false);
		optionmagicgui.SetActive (false);
		selectbutton1.SetActive (false);
		selectbutton2.SetActive (false);
		selectbutton3.SetActive (false);
		selectbutton4.SetActive (false);
		selectbutton5.SetActive (false);
		selectbutton22.SetActive (false);
		backbutton.SetActive (false);
		enemyhealthbar1.SetActive (false);
		enemyhealthbar2.SetActive (false);
		enemyhealthbar3.SetActive (false);
		enemyhealthbar4.SetActive (false);
		enemyhealthbar5.SetActive (false);
		playervars = GameObject.FindGameObjectWithTag ("Walk To Battle");
		player = GameObject.FindGameObjectWithTag ("Player");
		SetupBattle setup = (SetupBattle)setupbattle.GetComponent ("SetupBattle");
		enemy1 = setup.enemy1;
		enemy2 = setup.enemy2;
		enemy3 = setup.enemy3;
		setup.attack1button.GetComponent<Button> ().onClick.AddListener (() => Optionattack (setup.attack1) );
		setup.attack2button.GetComponent<Button> ().onClick.AddListener (() => Optionattack (setup.attack2) );
		setup.attack3button.GetComponent<Button> ().onClick.AddListener (() => Optionattack (setup.attack3) );
		setup.attack4button.GetComponent<Button> ().onClick.AddListener (() => Optionattack (setup.attack4) );
		setup.magic1button.GetComponent<Button> ().onClick.AddListener (() => Optionmagic (setup.magic1) );
		setup.magic2button.GetComponent<Button> ().onClick.AddListener (() => Optionmagic (setup.magic2) );
		setup.magic3button.GetComponent<Button> ().onClick.AddListener (() => Optionmagic (setup.magic3) );
		setup.magic4button.GetComponent<Button> ().onClick.AddListener (() => Optionmagic (setup.magic4) );
		PLayerBattle pbattle = (PLayerBattle)player.GetComponent ("PLayerBattle");
		if (setup.numenemies == 1) {
			EnemyAI enem1stats = (EnemyAI)enemy1.GetComponent ("EnemyAI");
			if (enem1stats.speed >= pbattle.speed) {
				firstperson = enemy1;
				secondperson = player;
			} else {
				firstperson = player;
				secondperson = enemy1;
			}
		}
		if (setup.numenemies == 2) {
			EnemyAI enem1stats = (EnemyAI)enemy1.GetComponent ("EnemyAI");
			EnemyAI enem2stats = (EnemyAI)enemy2.GetComponent ("EnemyAI");
			if (pbattle.speed >= enem1stats.speed && pbattle.speed >= enem2stats.speed) {
				firstperson = player;
				if (enem1stats.speed >= enem2stats.speed) {
					secondperson = enemy1;
					thirdperson = enemy2;
				} else {
					secondperson = enemy2;
					thirdperson = enemy1;
				}
			}
			if (enem1stats.speed >= pbattle.speed && enem1stats.speed >= enem2stats.speed) {
				firstperson = enemy1;
				if (pbattle.speed >= enem2stats.speed) {
					secondperson = player;
					thirdperson = enemy2;
				} else {
					secondperson = enemy2;
					thirdperson = player;
				}
			}
			if (enem2stats.speed >= pbattle.speed && enem2stats.speed >= enem1stats.speed) {
				firstperson = enemy2;
				if (pbattle.speed >= enem1stats.speed) {
					secondperson = player;
					thirdperson = enemy1;
				} else {
					secondperson = enemy1;
					thirdperson = player;
				}
			}
		}
		if(setup.numenemies == 3){
			EnemyAI enem1stats = (EnemyAI)enemy1.GetComponent ("EnemyAI");
			EnemyAI enem2stats = (EnemyAI)enemy2.GetComponent ("EnemyAI");
			EnemyAI enem3stats = (EnemyAI)enemy3.GetComponent ("EnemyAI");
			if (pbattle.speed >= enem1stats.speed && pbattle.speed >= enem2stats.speed && pbattle.speed >= enem3stats.speed) {
				firstperson = player;
				if (enem1stats.speed >= enem2stats.speed && enem1stats.speed >= enem3stats.speed) {
					secondperson = enemy1;
					if (enem2stats.speed >= enem3stats.speed) {
						thirdperson = enemy2;
						fourthperson = enemy3;
					} else {
						thirdperson = enemy3;
						fourthperson = enemy2;
					}
				}
				if (enem2stats.speed >= enem1stats.speed && enem2stats.speed >= enem3stats.speed) {
					secondperson = enemy2;
					if (enem1stats.speed >= enem3stats.speed) {
						thirdperson = enemy1;
						fourthperson = enemy3;
					} else {
						thirdperson = enemy3;
						fourthperson = enemy1;
					}
				}
				if (enem3stats.speed >= enem1stats.speed && enem3stats.speed >= enem2stats.speed) {
					secondperson = enemy3;
					if (enem1stats.speed >= enem2stats.speed) {
						thirdperson = enemy1;
						fourthperson = enemy2;
					} else {
						thirdperson = enemy2;
						fourthperson = enemy1;
					}
				}
			}
			if (enem1stats.speed >= pbattle.speed && enem1stats.speed >= enem2stats.speed && enem1stats.speed >= enem3stats.speed) {
				firstperson = enemy1;
				if (pbattle.speed >= enem2stats.speed && pbattle.speed >= enem3stats.speed) {
					secondperson = player;
					if (enem2stats.speed >= enem3stats.speed) {
						thirdperson = enemy2;
						fourthperson = enemy3;
					} else {
						thirdperson = enemy3;
						fourthperson = enemy2;
					}
				}
				if (enem2stats.speed >= pbattle.speed && enem2stats.speed >= enem3stats.speed) {
					secondperson = enemy2;
					if (pbattle.speed >= enem3stats.speed) {
						thirdperson = player;
						fourthperson = enemy3;
					} else {
						thirdperson = enemy3;
						fourthperson = player;
					}
				}
				if (enem3stats.speed >= pbattle.speed && enem3stats.speed >= enem2stats.speed) {
					secondperson = enemy3;
					if (pbattle.speed >= enem2stats.speed) {
						thirdperson = player;
						fourthperson = enemy2;
					} else {
						thirdperson = enemy2;
						fourthperson = player;
					}
				}
			}
			if (enem2stats.speed >= enem1stats.speed && enem2stats.speed >= pbattle.speed && enem2stats.speed >= enem3stats.speed) {
				firstperson = enemy2;
				if (enem1stats.speed >= enem2stats.speed && enem1stats.speed >= enem3stats.speed) {
					secondperson = enemy1;
					if (pbattle.speed >= enem3stats.speed) {
						thirdperson = player;
						fourthperson = enemy3;
					} else {
						thirdperson = enemy3;
						fourthperson = player;
					}
				}
				if (pbattle.speed >= enem1stats.speed && pbattle.speed >= enem3stats.speed) {
					secondperson = player;
					if (enem1stats.speed >= enem3stats.speed) {
						thirdperson = enemy1;
						fourthperson = enemy3;
					} else {
						thirdperson = enemy3;
						fourthperson = enemy1;
					}
				}
				if (enem3stats.speed >= enem1stats.speed && enem3stats.speed >= pbattle.speed) {
					secondperson = enemy3;
					if (enem1stats.speed >= pbattle.speed) {
						thirdperson = enemy1;
						fourthperson = player;
					} else {
						thirdperson = player;
						fourthperson = enemy1;
					}
				}
			}
			if (enem3stats.speed >= enem1stats.speed && enem3stats.speed >= enem2stats.speed && enem3stats.speed >= pbattle.speed) {
				firstperson = enemy3;
				if (enem1stats.speed >= enem2stats.speed && enem1stats.speed >= pbattle.speed) {
					secondperson = enemy1;
					if (enem2stats.speed >= pbattle.speed) {
						thirdperson = enemy2;
						fourthperson = player;
					} else {
						thirdperson = player;
						fourthperson = enemy2;
					}
				}
				if (enem2stats.speed >= enem1stats.speed && enem2stats.speed >= pbattle.speed) {
					secondperson = enemy2;
					if (enem1stats.speed >= pbattle.speed) {
						thirdperson = enemy1;
						fourthperson = player;
					} else {
						thirdperson = player;
						fourthperson = enemy1;
					}
				}
				if (pbattle.speed >= enem1stats.speed && pbattle.speed >= enem2stats.speed) {
					secondperson = player;
					if (enem1stats.speed >= enem2stats.speed) {
						thirdperson = enemy1;
						fourthperson = enemy2;
					} else {
						thirdperson = enemy2;
						fourthperson = enemy1;
					}
				}
			}
		}
		commentarygui.SetActive (false);
	}

	public void Option1(string option){
		if (option == "Attack") {
			commentarygui.SetActive (false);
			choicesgui.SetActive (true);
			option1gui.SetActive (false);
			optionattackgui.SetActive (true);
			backbutton.SetActive (true);
		}
		if (option == "Inventory") {
			commentarygui.SetActive (false);
			choicesgui.SetActive (true);
			option1gui.SetActive (false);
			optionattackgui.SetActive (true);
			backbutton.SetActive (true);
		}
		if (option == "Magic") {
			commentarygui.SetActive (false);
			choicesgui.SetActive (true);
			option1gui.SetActive (false);
			optionattackgui.SetActive (false);
			optionmagicgui.SetActive (true);
			backbutton.SetActive (true);
		}
		if (option == "Run") {
			EndBattle ();
		}
	}

	public void Optionattack(GameObject attack){
		Attacks att = (Attacks)attack.GetComponent ("Attacks");
		PLayerBattle pbattle = (PLayerBattle)player.GetComponent("PLayerBattle");
		if (pbattle.curstamina >= att.staminacost) {
			SetupBattle setup = (SetupBattle)setupbattle.GetComponent ("SetupBattle");
			thisturnattack = attack;
			if (setup.numenemies == 1) {
				selectbutton1.SetActive (false);
				selectbutton2.SetActive (false);
				selectbutton3.SetActive (false);
				selectbutton4.SetActive (false);
				selectbutton5.SetActive (false);
				enemyhealthbar1.SetActive (false);
				enemyhealthbar2.SetActive (false);
				enemyhealthbar3.SetActive (false);
				enemyhealthbar4.SetActive (false);
				enemyhealthbar5.SetActive (false);
				if (enemy1 != null) {
					selectbutton3.SetActive (true);
					EnemyAI enem1 = (EnemyAI)enemy1.GetComponent ("EnemyAI");
					enem1.ChooseAttack ();
					enemyhealthbar3.SetActive (true);
				}
			}
			if (setup.numenemies == 2) {
				selectbutton1.SetActive (false);
				selectbutton2.SetActive (false);
				selectbutton3.SetActive (false);
				selectbutton4.SetActive (false);
				selectbutton5.SetActive (false);
				enemyhealthbar1.SetActive (false);
				enemyhealthbar2.SetActive (false);
				enemyhealthbar3.SetActive (false);
				enemyhealthbar4.SetActive (false);
				enemyhealthbar5.SetActive (false);
				if (enemy1 != null) {
					selectbutton2.SetActive (true);
					EnemyAI enem1 = (EnemyAI)enemy1.GetComponent ("EnemyAI");
					enem1.ChooseAttack ();
					enemyhealthbar2.SetActive (true);
				}
				if (enemy2 != null) {
					selectbutton4.SetActive (true);
					EnemyAI enem2 = (EnemyAI)enemy2.GetComponent ("EnemyAI");
					enem2.ChooseAttack ();
					enemyhealthbar4.SetActive (true);
				}
			}
			if (setup.numenemies == 3) {
				selectbutton1.SetActive (false);
				selectbutton2.SetActive (false);
				selectbutton3.SetActive (false);
				selectbutton4.SetActive (false);
				selectbutton5.SetActive (false);
				enemyhealthbar1.SetActive (false);
				enemyhealthbar2.SetActive (false);
				enemyhealthbar3.SetActive (false);
				enemyhealthbar4.SetActive (false);
				enemyhealthbar5.SetActive (false);
				if (enemy1 != null) {
					selectbutton1.SetActive (true);
					EnemyAI enem1 = (EnemyAI)enemy1.GetComponent ("EnemyAI");
					enem1.ChooseAttack ();
					enemyhealthbar1.SetActive (true);
				}
				if (enemy2 != null) {
					selectbutton3.SetActive (true);
					EnemyAI enem2 = (EnemyAI)enemy2.GetComponent ("EnemyAI");
					enem2.ChooseAttack ();
					enemyhealthbar3.SetActive (true);
				}
				if (enemy3 != null) {
					selectbutton5.SetActive (true);
					EnemyAI enem3 = (EnemyAI)enemy3.GetComponent ("EnemyAI");
					enem3.ChooseAttack ();
					enemyhealthbar5.SetActive (true);
				}
			}
		}
	}

	public void Optionmagic(GameObject attack){
		Attacks att = (Attacks)attack.GetComponent ("Attacks");
		PLayerBattle pbattle = (PLayerBattle)player.GetComponent("PLayerBattle");
		if (pbattle.curmana >= att.manacost) {
			SetupBattle setup = (SetupBattle)setupbattle.GetComponent ("SetupBattle");
			thisturnattack = attack;
			if (setup.numenemies == 1) {
				selectbutton1.SetActive (false);
				selectbutton2.SetActive (false);
				selectbutton3.SetActive (false);
				selectbutton4.SetActive (false);
				selectbutton5.SetActive (false);
				enemyhealthbar1.SetActive (false);
				enemyhealthbar2.SetActive (false);
				enemyhealthbar3.SetActive (false);
				enemyhealthbar4.SetActive (false);
				enemyhealthbar5.SetActive (false);
				if (enemy1 != null) {
					selectbutton3.SetActive (true);
					EnemyAI enem1 = (EnemyAI)enemy1.GetComponent ("EnemyAI");
					enem1.ChooseAttack ();
					enemyhealthbar3.SetActive (true);
				}
			}
			if (setup.numenemies == 2) {
				selectbutton1.SetActive (false);
				selectbutton2.SetActive (false);
				selectbutton3.SetActive (false);
				selectbutton4.SetActive (false);
				selectbutton5.SetActive (false);
				enemyhealthbar1.SetActive (false);
				enemyhealthbar2.SetActive (false);
				enemyhealthbar3.SetActive (false);
				enemyhealthbar4.SetActive (false);
				enemyhealthbar5.SetActive (false);
				if (enemy1 != null) {
					selectbutton2.SetActive (true);
					EnemyAI enem1 = (EnemyAI)enemy1.GetComponent ("EnemyAI");
					enem1.ChooseAttack ();
					enemyhealthbar2.SetActive (true);
				}
				if (enemy2 != null) {
					selectbutton4.SetActive (true);
					EnemyAI enem2 = (EnemyAI)enemy2.GetComponent ("EnemyAI");
					enem2.ChooseAttack ();
					enemyhealthbar4.SetActive (true);
				}
			}
			if (setup.numenemies == 3) {
				selectbutton1.SetActive (false);
				selectbutton2.SetActive (false);
				selectbutton3.SetActive (false);
				selectbutton4.SetActive (false);
				selectbutton5.SetActive (false);
				enemyhealthbar1.SetActive (false);
				enemyhealthbar2.SetActive (false);
				enemyhealthbar3.SetActive (false);
				enemyhealthbar4.SetActive (false);
				enemyhealthbar5.SetActive (false);
				if (enemy1 != null) {
					selectbutton1.SetActive (true);
					EnemyAI enem1 = (EnemyAI)enemy1.GetComponent ("EnemyAI");
					enem1.ChooseAttack ();
					enemyhealthbar1.SetActive (true);
				}
				if (enemy2 != null) {
					selectbutton3.SetActive (true);
					EnemyAI enem2 = (EnemyAI)enemy2.GetComponent ("EnemyAI");
					enem2.ChooseAttack ();
					enemyhealthbar3.SetActive (true);
				}
				if (enemy3 != null) {
					selectbutton5.SetActive (true);
					EnemyAI enem3 = (EnemyAI)enemy3.GetComponent ("EnemyAI");
					enem3.ChooseAttack ();
					enemyhealthbar5.SetActive (true);
				}
			}
		}
	}

	public void Optionselect(int enemynum){
		SetupBattle setup = (SetupBattle)setupbattle.GetComponent ("SetupBattle");
		if (setup.numenemies == 1) {
			targetenemy = enemy1;
			FirstPerson ();
			personturnnum = 1;
		}
		if (setup.numenemies == 2) {
			if (enemynum == 2) {
				targetenemy = enemy1;
				FirstPerson ();
				personturnnum = 1;
			}
			if (enemynum == 4) {
				targetenemy = enemy2;
				FirstPerson ();
				personturnnum = 1;
			}
		}
		if (setup.numenemies == 3) {
			if (enemynum == 1) {
				targetenemy = enemy1;
				FirstPerson ();
				personturnnum = 1;
			}
			if (enemynum == 3) {
				targetenemy = enemy2;
				FirstPerson ();
				personturnnum = 1;
			}
			if (enemynum == 5) {
				targetenemy = enemy3;
				FirstPerson ();
				personturnnum = 1;
			}
		}
	}

	public void Backbutton(){
		commentarygui.SetActive (false);
		choicesgui.SetActive (true);
		option1gui.SetActive (true);
		optionattackgui.SetActive (false);
		optionmagicgui.SetActive (false);
		selectbutton1.SetActive (false);
		selectbutton2.SetActive (false);
		selectbutton3.SetActive (false);
		selectbutton4.SetActive (false);
		selectbutton5.SetActive (false);
		selectbutton22.SetActive (false);
		backbutton.SetActive (false);
		enemyhealthbar1.SetActive (false);
		enemyhealthbar2.SetActive (false);
		enemyhealthbar3.SetActive (false);
		enemyhealthbar4.SetActive (false);
		enemyhealthbar5.SetActive (false);
		personturnnum = 1;
	}

	public void FirstPerson(){
		commentarygui.SetActive (true);
		choicesgui.SetActive (true);
		option1gui.SetActive (false);
		optionattackgui.SetActive (false);
		optionmagicgui.SetActive (false);
		selectbutton1.SetActive (false);
		selectbutton2.SetActive (false);
		selectbutton3.SetActive (false);
		selectbutton4.SetActive (false);
		selectbutton5.SetActive (false);
		selectbutton22.SetActive (false);
		backbutton.SetActive (false);
		if (firstperson == player) {
			PLayerBattle pbattle = (PLayerBattle)player.GetComponent("PLayerBattle");
			Attacks att = (Attacks)thisturnattack.GetComponent ("Attacks");
			commentarytext.text = "Player used " + att.attackname;
			pbattle.DoDamage (targetenemy, thisturnattack);
		}
		if (firstperson == enemy1) {
			EnemyAI enem1 = (EnemyAI)enemy1.GetComponent ("EnemyAI");
			Attacks att = (Attacks)enem1.activeattack.GetComponent ("Attacks");
			commentarytext.text = enem1.enemyname + " used " + att.attackname;
			enem1.DoDamage ();
		}
		if (firstperson == enemy2) {
			EnemyAI enem2 = (EnemyAI)enemy2.GetComponent ("EnemyAI");
			Attacks att = (Attacks)enem2.activeattack.GetComponent ("Attacks");
			commentarytext.text = enem2.enemyname + " used " + att.attackname;
			enem2.DoDamage ();
		}
		if (firstperson == enemy3) {
			EnemyAI enem3 = (EnemyAI)enemy3.GetComponent ("EnemyAI");
			Attacks att = (Attacks)enem3.activeattack.GetComponent ("Attacks");
			commentarytext.text = enem3.enemyname + " used " + att.attackname;
			enem3.DoDamage ();
		}
	}

	public void SecondPerson(){
		commentarygui.SetActive (true);
		choicesgui.SetActive (true);
		option1gui.SetActive (false);
		optionattackgui.SetActive (false);
		optionmagicgui.SetActive (false);
		selectbutton1.SetActive (false);
		selectbutton2.SetActive (false);
		selectbutton3.SetActive (false);
		selectbutton4.SetActive (false);
		selectbutton5.SetActive (false);
		selectbutton22.SetActive (false);
		backbutton.SetActive (false);
		if (secondperson == player) {
			PLayerBattle pbattle = (PLayerBattle)player.GetComponent("PLayerBattle");
			Attacks att = (Attacks)thisturnattack.GetComponent ("Attacks");
			commentarytext.text = "Player used " + att.attackname;
			pbattle.DoDamage (targetenemy, thisturnattack);
		}
		if (secondperson == enemy1) {
			EnemyAI enem1 = (EnemyAI)enemy1.GetComponent ("EnemyAI");
			Attacks att = (Attacks)enem1.activeattack.GetComponent ("Attacks");
			commentarytext.text = enem1.enemyname + " used " + att.attackname;
			enem1.DoDamage ();
		}
		if (secondperson == enemy2) {
			EnemyAI enem2 = (EnemyAI)enemy2.GetComponent ("EnemyAI");
			Attacks att = (Attacks)enem2.activeattack.GetComponent ("Attacks");
			commentarytext.text = enem2.enemyname + " used " + att.attackname;
			enem2.DoDamage ();
		}
		if (secondperson == enemy3) {
			EnemyAI enem3 = (EnemyAI)enemy3.GetComponent ("EnemyAI");
			Attacks att = (Attacks)enem3.activeattack.GetComponent ("Attacks");
			commentarytext.text = enem3.enemyname + " used " + att.attackname;
			enem3.DoDamage ();
		}
	}

	public void ThirdPerson(){
		commentarygui.SetActive (true);
		choicesgui.SetActive (true);
		option1gui.SetActive (false);
		optionattackgui.SetActive (false);
		optionmagicgui.SetActive (false);
		selectbutton1.SetActive (false);
		selectbutton2.SetActive (false);
		selectbutton3.SetActive (false);
		selectbutton4.SetActive (false);
		selectbutton5.SetActive (false);
		selectbutton22.SetActive (false);
		backbutton.SetActive (false);
		if (thirdperson == player) {
			PLayerBattle pbattle = (PLayerBattle)player.GetComponent("PLayerBattle");
			Attacks att = (Attacks)thisturnattack.GetComponent ("Attacks");
			commentarytext.text = "Player used " + att.attackname;
			pbattle.DoDamage (targetenemy, thisturnattack);
		}
		if (thirdperson == enemy1) {
			EnemyAI enem1 = (EnemyAI)enemy1.GetComponent ("EnemyAI");
			Attacks att = (Attacks)enem1.activeattack.GetComponent ("Attacks");
			commentarytext.text = enem1.enemyname + " used " + att.attackname;
			enem1.DoDamage ();
		}
		if (thirdperson == enemy2) {
			EnemyAI enem2 = (EnemyAI)enemy2.GetComponent ("EnemyAI");
			Attacks att = (Attacks)enem2.activeattack.GetComponent ("Attacks");
			commentarytext.text = enem2.enemyname + " used " + att.attackname;
			enem2.DoDamage ();
		}
		if (thirdperson == enemy3) {
			EnemyAI enem3 = (EnemyAI)enemy3.GetComponent ("EnemyAI");
			Attacks att = (Attacks)enem3.activeattack.GetComponent ("Attacks");
			commentarytext.text = enem3.enemyname + " used " + att.attackname;
			enem3.DoDamage ();
		}
	}

	public void FourthPerson(){
		commentarygui.SetActive (true);
		choicesgui.SetActive (true);
		option1gui.SetActive (false);
		optionattackgui.SetActive (false);
		optionmagicgui.SetActive (false);
		selectbutton1.SetActive (false);
		selectbutton2.SetActive (false);
		selectbutton3.SetActive (false);
		selectbutton4.SetActive (false);
		selectbutton5.SetActive (false);
		selectbutton22.SetActive (false);
		backbutton.SetActive (false);
		if (fourthperson == player) {
			PLayerBattle pbattle = (PLayerBattle)player.GetComponent("PLayerBattle");
			Attacks att = (Attacks)thisturnattack.GetComponent ("Attacks");
			commentarytext.text = "Player used " + att.attackname;
			pbattle.DoDamage (targetenemy, thisturnattack);
		}
		if (fourthperson == enemy1) {
			EnemyAI enem1 = (EnemyAI)enemy1.GetComponent ("EnemyAI");
			Attacks att = (Attacks)enem1.activeattack.GetComponent ("Attacks");
			commentarytext.text = enem1.enemyname + " used " + att.attackname;
			enem1.DoDamage ();
		}
		if (fourthperson == enemy2) {
			EnemyAI enem2 = (EnemyAI)enemy2.GetComponent ("EnemyAI");
			Attacks att = (Attacks)enem2.activeattack.GetComponent ("Attacks");
			commentarytext.text = enem2.enemyname + " used " + att.attackname;
			enem2.DoDamage ();
		}
		if (fourthperson == enemy3) {
			EnemyAI enem3 = (EnemyAI)enemy3.GetComponent ("EnemyAI");
			Attacks att = (Attacks)enem3.activeattack.GetComponent ("Attacks");
			commentarytext.text = enem3.enemyname + " used " + att.attackname;
			enem3.DoDamage ();
		}
	}

	public void Next(){
		bool anydead = false;
		SetupBattle setup = (SetupBattle)setupbattle.GetComponent ("SetupBattle");
		if (endbattletext == true) {
			EndBattle ();
		}
		if(allenemiesdead == true){
			commentarytext.text = "You gained " + exppool.ToString() + " experience pts.";
			endbattletext = true;
		}
		if (setup.numenemies == 1) {
			if (enemy1 != null) {
				EnemyAI enem1 = (EnemyAI)enemy1.GetComponent ("EnemyAI");
				if (enem1.dead == true) {
					exppool += enem1.expgain;
					anydead = true;
					enemy1 = null;
					allenemiesdead = true;
				}
			}
		}
		if (setup.numenemies == 2) {
			if (enemy1 != null) {
				EnemyAI enem1 = (EnemyAI)enemy1.GetComponent ("EnemyAI");
				if (enem1.dead == true) {
					exppool += enem1.expgain;
					anydead = true;
					enemy1 = null;
				}
			}
			if (enemy2 != null) {
				EnemyAI enem2 = (EnemyAI)enemy2.GetComponent ("EnemyAI");
				if (enem2.dead == true) {
					exppool += enem2.expgain;
					anydead = true;
					enemy2 = null;
				}
			}
			if (enemy1 == null && enemy2 == null) {
				allenemiesdead = true;
			}
		}
		if (setup.numenemies == 3) {
			if (enemy1 != null) {
				EnemyAI enem1 = (EnemyAI)enemy1.GetComponent ("EnemyAI");
				if (enem1.dead == true) {
					exppool += enem1.expgain;
					anydead = true;
					enemy1 = null;
				}
			}
			if (enemy2 != null) {
				EnemyAI enem2 = (EnemyAI)enemy2.GetComponent ("EnemyAI");
				if (enem2.dead == true) {
					exppool += enem2.expgain;
					anydead = true;
					enemy2 = null;
				}
			}
			if (enemy3 != null) {
				EnemyAI enem3 = (EnemyAI)enemy3.GetComponent ("EnemyAI");
				if (enem3.dead == true) {
					exppool += enem3.expgain;
					anydead = true;
					enemy3 = null;
				}
			}
			if (enemy1 == null && enemy2 == null && enemy3 == null) {
				allenemiesdead = true;
			}
		}
		if(anydead == true){
			if (firstperson != player && firstperson != null) {
				EnemyAI enem = (EnemyAI)firstperson.GetComponent ("EnemyAI");
				if (enem.dead == true) {
					if (deadenemy1 == null) {
						deadenemy1 = firstperson;
					} else {
						if (deadenemy2 == null) {
							deadenemy2 = firstperson;
						} else {
							deadenemy3 = firstperson;
						}
					}
					commentarytext.text = enem.enemyname + " has died.";
					SpriteRenderer enemysprite = firstperson.GetComponent<SpriteRenderer> ();
					enemysprite.sprite = null;
					enem.curhealth = 1;
					enem.active = false;
					if (setup.numenemies == 1) {
						firstperson = secondperson;
						secondperson = null;
					}
					if (setup.numenemies == 2) {
						firstperson = secondperson;
						secondperson = thirdperson;
						thirdperson = null;
					}
					if (setup.numenemies == 3) {
						firstperson = secondperson;
						secondperson = thirdperson;
						thirdperson = fourthperson;
						fourthperson = null;
					}
				}
			}
			if (secondperson != player && secondperson != null) {
				EnemyAI enem = (EnemyAI)secondperson.GetComponent ("EnemyAI");
				if (enem.dead == true) {
					if (deadenemy1 == null) {
						deadenemy1 = secondperson;
					} else {
						if (deadenemy2 == null) {
							deadenemy2 = secondperson;
						} else {
							deadenemy3 = secondperson;
						}
					}
					commentarytext.text = enem.enemyname + " has died.";
					SpriteRenderer enemysprite = secondperson.GetComponent<SpriteRenderer> ();
					enemysprite.sprite = null;
					enem.curhealth = 1;
					enem.active = false;
					if (setup.numenemies == 1) {
						secondperson = null;
					}
					if (setup.numenemies == 2) {
						secondperson = thirdperson;
						thirdperson = null;
					}
					if (setup.numenemies == 3) {
						secondperson = thirdperson;
						thirdperson = fourthperson;
						fourthperson = null;
					}
				}
			}
			if (thirdperson != player && thirdperson != null) {
				EnemyAI enem = (EnemyAI)thirdperson.GetComponent ("EnemyAI");
				if (enem.dead == true) {
					if (deadenemy1 == null) {
						deadenemy1 = thirdperson;
					} else {
						if (deadenemy2 == null) {
							deadenemy2 = thirdperson;
						} else {
							deadenemy3 = thirdperson;
						}
					}
					commentarytext.text = enem.enemyname + " has died.";
					SpriteRenderer enemysprite = thirdperson.GetComponent<SpriteRenderer> ();
					enemysprite.sprite = null;
					enem.curhealth = 1;
					enem.active = false;
					if (setup.numenemies == 1) {

					}
					if (setup.numenemies == 2) {
						thirdperson = null;
					}
					if (setup.numenemies == 3) {
						thirdperson = fourthperson;
						fourthperson = null;
					}
				}
			}
			if (fourthperson != player && fourthperson != null) {
				EnemyAI enem = (EnemyAI)fourthperson.GetComponent ("EnemyAI");
				if (enem.dead == true) {
					if (deadenemy1 == null) {
						deadenemy1 = fourthperson;
					} else {
						if (deadenemy2 == null) {
							deadenemy2 = fourthperson;
						} else {
							deadenemy3 = fourthperson;
						}
					}
					commentarytext.text = enem.enemyname + " has died.";
					SpriteRenderer enemysprite = fourthperson.GetComponent<SpriteRenderer> ();
					enemysprite.sprite = null;
					enem.curhealth = 1;
					enem.active = false;
					if (setup.numenemies == 1) {

					}
					if (setup.numenemies == 2) {
						
					}
					if (setup.numenemies == 3) {
						fourthperson = null;
					}
				}
			}
		} else {
			if (allenemiesdead == false && endbattletext == false) {
				NextPerson ();
			}
		}
	}

	public void NextPerson(){
		commentarygui.SetActive (false);
		if (personturnnum == 3) {
			if (fourthperson != null) {
				FourthPerson ();
				personturnnum++;
			} else {
				Backbutton ();
			}
		} else {
			if (personturnnum == 2) {
				if (thirdperson != null) {
					ThirdPerson ();
					personturnnum++;
				} else {
					Backbutton ();
				}
			} else {
				if (personturnnum == 1) {
					SecondPerson ();
					personturnnum++;
				}
			}
		}
		if (personturnnum == 4) {
			Backbutton ();
		}
	}

	void Update(){
		SetupBattle setup = (SetupBattle)setupbattle.GetComponent ("SetupBattle");
		if (setup.numenemies == 1) {
			if (enemy1 != null) {
				Slider enemyhealth1 = enemyhealthbar3.GetComponent<Slider> ();
				EnemyAI enem1 = (EnemyAI)enemy1.GetComponent ("EnemyAI");
				enemyhealth1.value = (enem1.curhealth / enem1.maxhealth);
			}
		}
		if (setup.numenemies == 2) {
			if (enemy1 != null) {
				Slider enemyhealth1 = enemyhealthbar2.GetComponent<Slider> ();
				EnemyAI enem1 = (EnemyAI)enemy1.GetComponent ("EnemyAI");
				enemyhealth1.value = (enem1.curhealth / enem1.maxhealth);
			}
			if (enemy2 != null) {
				Slider enemyhealth2 = enemyhealthbar4.GetComponent<Slider> ();
				EnemyAI enem2 = (EnemyAI)enemy2.GetComponent ("EnemyAI");
				enemyhealth2.value = (enem2.curhealth / enem2.maxhealth);
			}
		}
		if (setup.numenemies == 3) {
			if (enemy1 != null) {
				Slider enemyhealth1 = enemyhealthbar1.GetComponent<Slider> ();
				EnemyAI enem1 = (EnemyAI)enemy1.GetComponent ("EnemyAI");
				enemyhealth1.value = (enem1.curhealth / enem1.maxhealth);
			}
			if (enemy2 != null) {
				Slider enemyhealth2 = enemyhealthbar3.GetComponent<Slider> ();
				EnemyAI enem2 = (EnemyAI)enemy2.GetComponent ("EnemyAI");
				enemyhealth2.value = (enem2.curhealth / enem2.maxhealth);
			}
			if (enemy3 != null) {
				Slider enemyhealth3 = enemyhealthbar5.GetComponent<Slider> ();
				EnemyAI enem3 = (EnemyAI)enemy3.GetComponent ("EnemyAI");
				enemyhealth3.value = (enem3.curhealth / enem3.maxhealth);
			}
		}
	}

	public void EndBattle(){
		DontDestroyVars ddv = (DontDestroyVars)playervars.GetComponent ("DontDestroyVars");
		ddv.expadd += exppool;
		SceneManager.LoadScene ("Cave");
	}
}