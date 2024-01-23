using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoillowPoint : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) {
            transform.position = Vector2.Lerp(player.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.3f);
        } else {
            transform.position = player.transform.position;
        }
        
        
    }
}
