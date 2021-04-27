using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTime : MonoBehaviour
{
    GameObject micObj;
    // Start is called before the first frame update
    void Start()
    {
        micObj = GameObject.FindGameObjectWithTag("Microphone");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause()
    {
       
        micObj.GetComponent<MicrophoneScript>().enabled = false;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        micObj.GetComponent<MicrophoneScript>().enabled = true;
        Time.timeScale = 1;
    }
}
