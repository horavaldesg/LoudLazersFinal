using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    GameObject audioObj;
    public bool DestroyShip;
    [SerializeField] ParticleSystem particleSystem;
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
                //Instantiate(particleSystem, other.transform.position, other.transform.rotation);
                other.GetComponentInChildren<ParticleSystem>().Play();
                other.GetComponent<SpriteRenderer>().enabled = false;


                Destroy(other.gameObject, other.GetComponentInChildren<ParticleSystem>().main.duration);
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
