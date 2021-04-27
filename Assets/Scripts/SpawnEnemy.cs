using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject[] enemies;
    float speed = 4;
    int i;
    float r;
    public float rate = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        r += Time.deltaTime;
        //Debug.Log(r);
        if (r > rate)
        {
            r = 0;
            Spawn();
           
        }
    }
    void Spawn()
    {
       
        //Debug.Log("Spawn");
        speed = Random.Range(80, 125);
        i = Random.Range(0,spawners.Length);
        int randomEnemies = Random.Range(0, enemies.Length);
        GameObject enemyObj = Instantiate(enemies[randomEnemies]);
        enemyObj.transform.position = spawners[i].transform.position;
        enemyObj.transform.rotation = spawners[i].transform.rotation;
        enemyObj.GetComponentInChildren<Rigidbody>().velocity = -spawners[i].transform.forward * speed * Time.deltaTime;

    }
}
