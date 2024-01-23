using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{

    GameObject player;

    public float aggroDistance;

    public float fireRate;

    public float hp;

    public Canvas canvas;

    public TMP_Text hpText;

    public ParticleSystem puska;

    bool puca;

    bool umro;

    bool healo;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        puca = false;
        umro = false;
        healo = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //hpText.text = hp.ToString();

        //ako je igrac unutar dometa pocni pucat i okretat se
        if (Vector3.Distance(this.transform.position, player.transform.position) < aggroDistance && !umro) {
            //okreni se prema igracu

            this.transform.up = new Vector2(player.transform.position.x, player.transform.position.y) - new Vector2(this.transform.position.x, this.transform.position.y);
            canvas.transform.rotation = Quaternion.identity;
            //pucaj

            
            if (!puca) {
                StartCoroutine(pucaj());
            }
            puca = true;




        } else if (Vector3.Distance(this.transform.position, player.transform.position) >= aggroDistance) {
            puca = false;
        }

        if (hp <= 0f && !umro) {
            //umri
            umro = true;
            puca = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            
            player.GetComponent<PlayerController>().DamagePlayer(-20);
        }
        
    }

    IEnumerator pucaj() {
        puska.Play();

        yield return new WaitForSeconds(fireRate);

        if (puca) {
            StartCoroutine(pucaj());
        }




    }

    public void Damage(float damage) {
        hp -= damage;
        hp = (float) Math.Round(hp, 2);
        hpText.text = hp.ToString();
    }

     private void OnParticleCollision(GameObject other) {
        Debug.Log("hit");
        switch(other.tag) {

            case "Bouncy":
            Damage(5f);
            break;

            case "Bubble":
            Damage(0.1f);
            break;

            case "Laser":
            Damage(5f);
            break;

            case "Sphere":
            Damage(1f);
            break;

            default:
            break;

        }
    }

}
