using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

	public GameObject game;
	public AudioSource shootAudio;
	float rotationValue = 45;
	float constant;
	// Use this for initialization
	void Start () {

		constant = rotationValue;
        //box.GetComponent<Renderer>().enabled = false;
        MicrophoneScript.onStartLoud += this.LoudStartEvent;
        MicrophoneScript.onEndLoud += this.LoudEndEvent;
        MicrophoneScript.rotateRight += this.RotateRight;
		MicrophoneScript.shoot += this.Shoot;
	}
	
	// Update is called once per frame
	void Update () {

	}

	// called when volume is above a given threshold
	public void LoudStartEvent () {
		//box.GetComponent<Renderer>().enabled = true;
	}

	// called when volume is below a given threshold
	public void LoudEndEvent () {
		//box.GetComponent<Renderer>().enabled = false;
	}
	public void RotateRight()
	{
		//Debug.Log("Quiet");
		if (game.transform.rotation.y == -45)
		{
			constant = rotationValue;
		}
		else if(game.transform.rotation.y == 45)
        {
			constant = -rotationValue;
        }
		game.transform.Rotate(0, transform.rotation.y + constant, 0);


	}
	
	public void Shoot()
	{
		shootAudio.Play();
		game.GetComponentInChildren<ShootProjectile>().Shoot();

		//Debug.Log("Shoot");
	}
}
