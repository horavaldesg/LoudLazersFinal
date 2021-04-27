using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            ScoreText.score += 1;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
