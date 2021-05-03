using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    GameObject audioObj;
    public bool DestroyShip;
    // Start is called before the first frame update
    private void Start()
    {
        audioObj = GameObject.FindGameObjectWithTag("Explosion");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!DestroyShip)
        {
            if (other.tag == "Enemy")
            {
                ScoreText.score += 1;
                audioObj.GetComponent<AudioSource>().Play();
                Destroy(this.gameObject);
                Destroy(other.gameObject);

                //Destroy(other.gameObject);
            }
            else if (other.tag == "Finish")
            {
                Destroy(this.gameObject);
            }
        }
        else if (DestroyShip)
        {
            Destroy(other.gameObject);
        }
    }
    
}
