using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cestica : MonoBehaviour
{
    Camera mainCamera;

    Vector3 startScale;

    public bool mijenjajVelicinu;

    public float rateVelicine;

    public bool canCollide;

    // Start is called before the first frame update
    void Start()
    {

        mainCamera = Camera.main;
        startScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(mainCamera.transform);
        transform.Rotate(0, 180, 0);

        if (mijenjajVelicinu) {
            transform.localScale = transform.localScale + new Vector3(rateVelicine, rateVelicine, rateVelicine);
        }
        
    }

    public void resetScale() {
        
        this.transform.localScale = startScale;

    }

    private void OnCollisionEnter(Collision other) {
        if (canCollide) {
            this.gameObject.SetActive(false);
        }
        
    }
}
