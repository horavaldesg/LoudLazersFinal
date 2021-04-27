﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderScript : MonoBehaviour
{
    Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.CompareTag("Low"))
        {
            MicrophoneScript.quiet = slider.value;

        }
        else if (this.gameObject.CompareTag("Loud"))

        {
            MicrophoneScript.loud = slider.value;
        }
    }
    
}
