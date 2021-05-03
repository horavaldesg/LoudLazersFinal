using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace FinerGames.PitchDetector.Demo
{
    public class SoundVisualizer : MonoBehaviour
    {
        PitchDetector pitchDetector;
        [SerializeField] RectTransform[] boxes;
        // Start is called before the first frame update
        void Start()
        {
            pitchDetector = GameObject.FindGameObjectWithTag("Microphone").GetComponent<PitchDetector>();
        }

        // Update is called once per frame
        void Update()
        {
            if(pitchDetector.Pitch > 0 && pitchDetector.Pitch <= 30)
            {
                boxes[0].GetComponent<RectTransform>().sizeDelta = new Vector2(25, pitchDetector.Pitch);
            }
            else if(pitchDetector.Pitch > 30 && pitchDetector.Pitch <= 40)
            {
                boxes[1].GetComponent<RectTransform>().sizeDelta = new Vector2(25, pitchDetector.Pitch);
            }
            else if (pitchDetector.Pitch > 40 && pitchDetector.Pitch <= 60)
            {
                boxes[2].GetComponent<RectTransform>().sizeDelta = new Vector2(25, pitchDetector.Pitch);
            }
            else if (pitchDetector.Pitch > 60 && pitchDetector.Pitch <= 80)
            {
                boxes[3].GetComponent<RectTransform>().sizeDelta = new Vector2(25, pitchDetector.Pitch);
            }
            else if (pitchDetector.Pitch > 80 && pitchDetector.Pitch <= 110)
            {
                boxes[4].GetComponent<RectTransform>().sizeDelta = new Vector2(25, pitchDetector.Pitch);
            }
            else if (pitchDetector.Pitch > 110 && pitchDetector.Pitch <= 140)
            {
                boxes[5].GetComponent<RectTransform>().sizeDelta = new Vector2(25, pitchDetector.Pitch);
            }
            else if (pitchDetector.Pitch > 140 && pitchDetector.Pitch <= 180)
            {
                boxes[6].GetComponent<RectTransform>().sizeDelta = new Vector2(25, pitchDetector.Pitch);
            }
            else if (pitchDetector.Pitch > 180 && pitchDetector.Pitch <= 300)
            {
                boxes[7].GetComponent<RectTransform>().sizeDelta = new Vector2(25, pitchDetector.Pitch);
            }
            else if (pitchDetector.Pitch > 300 && pitchDetector.Pitch <= 400)
            {
                boxes[8].GetComponent<RectTransform>().sizeDelta = new Vector2(25, pitchDetector.Pitch/2);
            }
            else if (pitchDetector.Pitch > 400 && pitchDetector.Pitch <= 600)
            {
                boxes[9].GetComponent<RectTransform>().sizeDelta = new Vector2(25, pitchDetector.Pitch/2);
            }
            else if (pitchDetector.Pitch > 600 && pitchDetector.Pitch <= 800)
            {
                boxes[10].GetComponent<RectTransform>().sizeDelta = new Vector2(25, pitchDetector.Pitch/2);
            }
            else if (pitchDetector.Pitch > 800 && pitchDetector.Pitch <= 1100)
            {
                boxes[11].GetComponent<RectTransform>().sizeDelta = new Vector2(25, pitchDetector.Pitch/2);
            }
            else if (pitchDetector.Pitch > 1100 && pitchDetector.Pitch <= 1400)
            {
                boxes[12].GetComponent<RectTransform>().sizeDelta = new Vector2(25, pitchDetector.Pitch/2);
            }
            else if (pitchDetector.Pitch > 1400 && pitchDetector.Pitch <= 1800)
            {
                boxes[13].GetComponent<RectTransform>().sizeDelta = new Vector2(25, pitchDetector.Pitch/2);
            }
            else if (pitchDetector.Pitch > 1800)
            {
                boxes[14].GetComponent<RectTransform>().sizeDelta = new Vector2(25, pitchDetector.Pitch/2);
            }
            else
            {
                foreach(RectTransform box in boxes)
                {
                    box.GetComponent<RectTransform>().sizeDelta = new Vector2(25, 5);
                }

            }
        }
    }
}
