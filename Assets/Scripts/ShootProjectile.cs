using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public Transform barrel;
    public Transform parentShip;
    public GameObject laser;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
