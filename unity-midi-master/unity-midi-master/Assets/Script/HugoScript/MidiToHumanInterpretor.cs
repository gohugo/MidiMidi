using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MidiToHumanInterpretor : MonoBehaviour
{

	[SerializeField]
	public string midiPath;

	private string headerHex;

	private string MThdHex;

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
		// separeted like this:	[4D 54 68 64] [00 00 00 06] [ff ff] [nn nn] [dd dd]
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
			ReadHeader(hex);
		}
		else
		{
			Debug.Log("the file is empty or null");
		}

	}

	private void ReadHeader(string hex) {

		headerHex = hex.Substring(0, 28);
		MThdHex = hex.Substring(0, 8);
		headerLenght = int.Parse(hex.Substring(8, 8), System.Globalization.NumberStyles.HexNumber);
		formatType = int.Parse(hex.Substring(16, 4), System.Globalization.NumberStyles.HexNumber);
		numberOfTrack = int.Parse(hex.Substring(20, 4), System.Globalization.NumberStyles.HexNumber);
		division = int.Parse(hex.Substring(24, 4), System.Globalization.NumberStyles.HexNumber);


		Debug.Log("headerHex = "     + headerHex);
		Debug.Log("MThdHex = "       + MThdHex);
		Debug.Log("headerLenght = "  + headerLenght);
		Debug.Log("formatType = "    + formatType);
		Debug.Log("numberOfTrack = " + numberOfTrack);
		Debug.Log("division = "      + division);



	}

}
