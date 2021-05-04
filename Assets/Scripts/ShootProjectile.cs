using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public Transform barrel;
    public Transform parentShip;
    public GameObject laser;
    public float speed = 5;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    public void Shoot()
    {

        GameObject laserObj = Instantiate(laser);
        laserObj.transform.position = barrel.transform.position;
        laserObj.transform.rotation = parentShip.transform.rotation;
        laserObj.GetComponentInChildren<Rigidbody>().velocity = laserObj.transform.forward * speed;
        player.GetComponentInChildren<ParticleSystem>().Play();
    }
}
