using AudioSynthesis.Midi;
using AudioSynthesis.Midi.Event;
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

		//Suggestion made by KyleMit
		string newLine = string.Format("{0},{1}", midiName, ntrack);
		foreach (MidiTrack track in tracks)
		{
			foreach (MidiEvent midEvent in track.MidiEvents)
			{
				newLine = string.Format("{0},{1}", newLine, midEvent.ToString());
				newLine = string.Format("{0},{1},{2},{3}",newLine, midEvent.Command,midEvent.Data1, midEvent.Data2);
			}
		}
		var csv = new StringBuilder();
		csv.AppendLine(newLine);

		string path = Path.Combine(Path.Combine(Application.streamingAssetsPath, "Created"), midiName + ".csv");
		Debug.Log(path);
		//after your loop
		File.WriteAllText(path, csv.ToString());

	}

}
