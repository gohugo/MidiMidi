using AudioSynthesis.Synthesis;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoAnimation : MonoBehaviour
{

	public  MeshRenderer[] meshRenderers;
	private Color[] backupMR;
	public bool[] keysOn;
	

	public static Color ON = Color.blue;
	public static Color OFF = Color.white;

	private static PianoAnimation instance = null;

	public  delegate void KeyChange(int key, bool isOn);
	

	public PianoAnimation() {
	
	}
	
	private void Start()
	{
		keysOn = new bool[meshRenderers.Length];
		backupMR = new Color[meshRenderers.Length];
		for (int i = 0; i < meshRenderers.Length; i++)
		{
			Color c = meshRenderers[i].material.color;
			backupMR[i] = new Color(c.r, c.g, c.b);
		}

	}

	void Awake()
	{
		
		keysOn = new bool[meshRenderers.Length];
	
		Synthesizer.Keychange = KeyStatusChange;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void KeyStatusChange(int key, bool isOn)
	{
		int index = key -21 ; 
		Debug.Log("KeyStatusChange key = " + key+" isOn = "+isOn);
		meshRenderers[index].material.SetColor("_Color", isOn ? ON : backupMR[index]);
		
	}

}
