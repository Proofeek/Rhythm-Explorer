using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using System.Linq;

public class Midi_To : MonoBehaviour
{
    public GameObject Target1L;
    public GameObject Target2L;
    public GameObject Target1R;
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;

    public BeatScroller theBS;

    void Start()
    {
        ConvertMidiToText("C:/Users/kiill/Desktop/RhytmGame/Elev2.mid", "C:/Users/kiill/Desktop/RhytmGame/midi2.txt");
        ConvertTextToGameObjects();
    }

    void Update()
    {
        
    }

    public static void ConvertMidiToText(string midiFilePath, string textFilePath)
    {
        var midiFile = MidiFile.Read(midiFilePath);

        IEnumerable<Note> notes = midiFile.GetNotes();
        //midiFile.ReplaceTempoMap(TempoMap.Create(Tempo.FromBeatsPerMinute(108)));

        File.WriteAllLines(textFilePath, notes.Select(n => $"{n.NoteNumber} {n.Time} {n.Length}"));

        List < Note > noteslist = notes.ToList();
        foreach (var x in noteslist)
        {
            Debug.Log(x.ToString());
        }
    }

    public void ConvertTextToGameObjects()
    {
        string[] entries = File.ReadAllText("C:/Users/kiill/Desktop/RhytmGame/midi2.txt").Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { ' ' });
            int noteName = int.Parse(entryInfo[0]);
            float noteTime = float.Parse(entryInfo[1]);
            if(noteName == 62) //LEFT
			{
                GameObject HeartClone = Instantiate(Target1L);
                HeartClone.transform.SetParent(b1.transform, false);
                HeartClone.name = "Target_1L_" + (b1.transform.childCount);
                HeartClone.transform.position = new Vector3(0f, ((noteTime/96) +1), 0f);
            }
            if (noteName == 61) //MID
            {
                GameObject HeartClone = Instantiate(Target2L);
                HeartClone.transform.SetParent(b2.transform, false);
                HeartClone.name = "Target_2L_" + (b2.transform.childCount);
                HeartClone.transform.position = new Vector3(0f, ((noteTime / 96) + 1), 0f);
            }
            if (noteName == 60) //RIGHT
            {
                GameObject HeartClone = Instantiate(Target1R);
                HeartClone.transform.SetParent(b3.transform, false);
                HeartClone.name = "Target_1R_" + (b3.transform.childCount);
                HeartClone.transform.position = new Vector3(0f, ((noteTime / 96) + 1), 0f);
            }


        }
        theBS.Prep();
    }
}
