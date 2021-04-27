using UnityEngine;
using System.Collections;
using UnityEngine.Audio; // required for dealing with audiomixers
using UnityEngine.Events;
public class MicrophoneScript : MonoBehaviour {
	
	public GameObject game;

	public delegate void MicrophoneEventHandler();
	public static event MicrophoneEventHandler onStartLoud;
	public static event MicrophoneEventHandler rotateRight;
	public static event MicrophoneEventHandler onEndLoud;
	public static event MicrophoneEventHandler shoot;

	bool aboveThreshold = false;

	//an audio source also attached to the same object as this script is
	AudioSource src;

	//make an audio mixer from the "create" menu, then drag it into the public field on this script.
	//double click the audio mixer and next to the "groups" section, click the "+" icon to add a 
	//child to the master group, rename it to "microphone".  Then in the audio source, in the "output" option, 
	//select this child of the master you have just created.
	//go back to the audiomixer inspector window, and click the "microphone" you just created, then in the 
	//inspector window, right click "Volume" and select "Expose Volume (of Microphone)" to script,
	//then back in the audiomixer window, in the corner click "Exposed Parameters", click on the "MyExposedParameter"
	//and rename it to "Volume"
	public AudioMixer masterMixer;

	public float volumeToTriggerEvent = 5;
	public static float quiet = 3;
	public static float loud = 7;

	void Start() {
		quiet = 3;
		loud = 7;
		// set volume of mixer
		masterMixer.SetFloat ("Volume", -80);

		// start the microphone listener
		src = GetComponent<AudioSource>();
		src.clip = null;
		src.clip = Microphone.Start (null, true, 600, 44100);

		// wait for the microphone to start up
		while (!(Microphone.GetPosition (null) > 0)) {
		}
		src.Play (); // Play the audio source
	}

	void Update(){
		
			// check for a sound event
			float loudness = GetAveragedVolume() * 100f;
		//Debug.Log(loudness);

		if (loudness < loud && loudness > quiet)
		{

			if (!aboveThreshold && onStartLoud != null)
			{
				rotateRight();
			}
			aboveThreshold = true;

		}
		else if (loudness > loud)
		{

			if (!aboveThreshold && onStartLoud != null)
			{

				shoot();
			}
			aboveThreshold = true;

		}

		else
		{
			if (aboveThreshold && onEndLoud != null)
			{
				onEndLoud();
			}
			aboveThreshold = false;
		}
		
		
	}

	float GetAveragedVolume() { 
		
		float[] data = new float[512];
		float a = 0;
		src.GetOutputData(data,0);
		foreach(float s in data)
		{
			a += Mathf.Abs(s);
		}
		return a/512;
	}

}