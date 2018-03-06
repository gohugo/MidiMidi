using AudioSynthesis.Midi;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityMidi;

public class MidiFileToCSV : MonoBehaviour
{



	[SerializeField]
	StreamingAssetResouce midiSource;

	public Author author;

	private MidiFile midiFile;



	public enum Author
	{
		Bach, Beth, Choppin, Other
	}



	void Start()
	{
		midiFile = new MidiFile(midiSource);
		CreateCSVFile();


	}

	private void CreateCSVFile()
	{
		MidiTrack[] tracks = midiFile.Tracks;

		string midiName = Path.GetFileNameWithoutExtension(midiSource.GetName());

		int ntrack = tracks.Length;
		//before your loop
		var csv = new StringBuilder();


		//in your loop

		//Suggestion made by KyleMit
		var newLine = string.Format("{0},{1}", midiName, ntrack);
		csv.AppendLine(newLine);

		string path = Path.Combine(Path.Combine(Application.streamingAssetsPath, "Created"), midiName + ".csv");
		Debug.Log(path);
		//after your loop
		File.WriteAllText(path, csv.ToString());

	}

}
