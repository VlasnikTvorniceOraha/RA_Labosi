using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public ParticleSystem bouncyGun;

    public ParticleSystem bubbleGun;

    public ParticleSystem laserGun;

    public ParticleSystem sphereGun;

    ParticleSystem trenutniGun;


    // Start is called before the first frame update
    void Start()
    {
        trenutniGun = bubbleGun;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            trenutniGun = bouncyGun;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            trenutniGun = bubbleGun;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            trenutniGun = laserGun;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            trenutniGun = sphereGun;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            //pucaj
            trenutniGun.Play();
        }
        
    }
}
