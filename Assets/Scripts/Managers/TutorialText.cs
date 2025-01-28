using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour {

	public float timer;

	void Start () {
		timer = 0;
	}
	
	void Update () {
		timer = timer + 1 * Time.deltaTime;
		if (timer >= 10) {
			gameObject.SetActive (false);
		}
	}
}
