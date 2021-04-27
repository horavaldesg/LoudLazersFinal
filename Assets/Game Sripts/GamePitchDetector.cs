﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pitch;
using UnityEngine.UI;
namespace FinerGames.PitchDetector.Demo
{
    public class GamePitchDetector : MonoBehaviour
    {
        [SerializeField]PitchDetector pitchDetector;
        [SerializeField] int hightPitchCap = 100;
        [SerializeField] int lowPitchCap = 100;
        [SerializeField] bool endless;
        [SerializeField] bool spaceInvaders;
        [SerializeField] RectTransform slider;
        float constant;
        float rotationValue = 45;

        float move = 5;
        string[] hightNotes = { "A", "C", "D"};
        string[] lowNotes = {"E", "F", "G" };
        GameObject player;
        // Start is called before the first frame update
        void Start()
        {
            
            constant = rotationValue;
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            //show middletone for player
            //visualize it
            if (endless)
            {
                Debug.Log(pitchDetector.Pitch);
                //if (Input.GetKey(KeyCode.Space))
                //{
                if (pitchDetector.Pitch > 0 && pitchDetector.Pitch < 100)
                {   if (slider.transform.position.y <= 278)
                    {
                        slider.transform.position = new Vector3(0, slider.transform.position.y - 1, 0); ;
                    }
                    Debug.Log("Low");
                    if (player.transform.rotation.y == -45)
                    {
                        constant = rotationValue;
                    }
                    else if (player.transform.rotation.y == 45)
                    {
                        constant = -rotationValue;
                    }
                    player.transform.Rotate(0, transform.rotation.y + constant, 0);

                }
                else if (pitchDetector.Pitch >= 100)
                {
                    if (slider.transform.position.y >= -278)
                    {
                        slider.transform.position = new Vector3(0, slider.transform.position.y + 1, 0);
                    }
                    Debug.Log("High");
                    player.GetComponentInChildren<ShootProjectile>().Shoot();
                }
            }
            else if (spaceInvaders)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (player.transform.position.x == 15)
                    {
                        move = -move;
                    }
                    else if (player.transform.position.x == -15)
                    {
                        move = -move;
                    }
                    player.transform.position += new Vector3(move, 0, 0);

                }
                if (pitchDetector.Pitch > 0 && pitchDetector.Pitch < 100)
                {
                    if (player.transform.position.x == 15)
                    {
                        move = -move;
                    }
                    else if (player.transform.position.x == -15)
                    {
                        move = -move;
                    }
                    player.transform.position += new Vector3(move, 0, 0);


                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    player.GetComponentInChildren<ShootProjectile>().Shoot();
                }
                else if (pitchDetector.Pitch >= 100)
                {
                    Debug.Log("High");
                    player.GetComponentInChildren<ShootProjectile>().Shoot();
                }
            }
            //}
            /*
            foreach (string notes in hightNotes) {

                if (notes == PitchDsp.GetNoteName(pitchDetector.MidiNote, false, false)){
                    Debug.Log("High: " + PitchDsp.GetNoteName(pitchDetector.MidiNote, false, false));
                    
                }
                
                
            }
            foreach(string notes in lowNotes)
            {
                if(notes == PitchDsp.GetNoteName(pitchDetector.MidiNote, false, false))
                {
                    Debug.Log("Low: " + PitchDsp.GetNoteName(pitchDetector.MidiNote, false, false));
                }
            }
            */
        }
    }
}