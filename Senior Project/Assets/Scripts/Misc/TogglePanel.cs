using UnityEngine;
using System.Collections;

public class TogglePanel : MonoBehaviour {
	public GameObject window;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("e")) {
			window.SetActive (!window.activeSelf);
		}
	}
}
