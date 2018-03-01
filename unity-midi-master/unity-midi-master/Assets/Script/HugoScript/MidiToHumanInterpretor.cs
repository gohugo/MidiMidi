using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MidiToHumanInterpretor : MonoBehaviour
{

	[SerializeField]
	public string midiPath;

	private string header;

	private int headerLenght;

	private int formatType;

	private int numberOfTrack;

	private int division;


	private void Awake()
	{
		Debug.Log("MidiToHumanInterpretor: Awake()");
		ReadMidiFile();
	}


	private void ReadMidiFile()
	{
		Debug.Log("ReadMidiFile()");
		// Example Header:			4D 54 68 64 00 00 00 06 ff ff nn nn dd dd
		//	separeted like this:	[4D 54 68 64] [00 00 00 06] [ff ff] [nn nn] [dd dd]
		// Header format:  header_chunk = "MThd" + <header_length> + <format> + <n> + <division>

		FileStream fs = new FileStream(midiPath, FileMode.Open);
		int hexIn;
		string hex = null;

		for (int i = 0; (hexIn = fs.ReadByte()) != -1; i++)
		{
			hex += string.Format("{0:X2}", hexIn);
			
		}
		if (!string.IsNullOrEmpty(hex))
		{
			Debug.Log(hex);
		}

	}

}
