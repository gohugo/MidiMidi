using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void NoteOn(int channel, int note,int velocity) {
		Debug.Log("WOW NotE ON "+note);
	}
}
