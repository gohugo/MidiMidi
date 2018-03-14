using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoAnimation : MonoBehaviour {
	public MeshRenderer[] meshRenderers;
	public bool[] keysOn;


	void Init() {
		keysOn = new bool[meshRenderers.Length];

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
