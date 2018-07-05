using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    enum Note
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G
    };

    private Dictionary<KeyCode, GameObject> oscillators = new Dictionary< KeyCode, GameObject>();
    private Dictionary<Note, double> noteToFrequency = new Dictionary<Note, double>();
    private Dictionary<KeyCode, Note> keyToNote = new Dictionary<KeyCode, Note>();

	// Use this for initialization
    void Start () {
        noteToFrequency.Add(Note.A, 220.0);
        noteToFrequency.Add(Note.B, 246.94);
        noteToFrequency.Add(Note.C, 261.63);
        noteToFrequency.Add(Note.D, 293.66);
        noteToFrequency.Add(Note.E, 329.63);
        noteToFrequency.Add(Note.F, 349.23);
        noteToFrequency.Add(Note.G, 392.00);

        keyToNote.Add(KeyCode.A, Note.A);
        keyToNote.Add(KeyCode.B, Note.B);
        keyToNote.Add(KeyCode.C, Note.C);
        keyToNote.Add(KeyCode.D, Note.D);
        keyToNote.Add(KeyCode.E, Note.E);
        keyToNote.Add(KeyCode.F, Note.F);
        keyToNote.Add(KeyCode.G, Note.G);
	}
	
    private void _generateOscillatorForKeyCode(KeyCode keyCode)
    {
        Note note = keyToNote[keyCode];

        if (oscillators.ContainsKey(keyCode) &&
                oscillators[keyCode] != null)
        {
            Destroy((GameObject)oscillators[keyCode]);
            oscillators[keyCode] = null;
        }

        double octaveMultiplier = (double)Random.Range(1, 5);
        double computedFrequency = noteToFrequency[note] * octaveMultiplier;

        oscillators[keyCode] = (GameObject)Instantiate(Resources.Load("Prefabs/Oscillator"));
        ((GameObject)oscillators[keyCode]).GetComponent<Oscillator>().frequency = computedFrequency;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _generateOscillatorForKeyCode(KeyCode.A);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            _generateOscillatorForKeyCode(KeyCode.B);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            _generateOscillatorForKeyCode(KeyCode.C);
        }
	}
}
