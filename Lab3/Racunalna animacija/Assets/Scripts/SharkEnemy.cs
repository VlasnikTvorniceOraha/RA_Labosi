using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SharkEnemy : MonoBehaviour
{
    GameObject player;

    public float aggroDistance;

    public float moveRate;

    public float moveSpeed;

    public float hp;

    public float fireRate;

    public Canvas canvas;

    public TMP_Text hpText;

    public ParticleSystem puska;

    bool puca;

    bool umro;

    bool kretara;

    Vector2 velocity;

    Rigidbody2D rigid;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        puca = false;
        umro = false;
        kretara = false;
        rigid = this.GetComponent<Rigidbody2D>();
        
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

            if (!kretara) {
                StartCoroutine(pomakniSe());
                kretara = true;
            }
            //ganjaj

            if (!puca && Vector3.Distance(this.transform.position, player.transform.position) < 3f ) {
                StartCoroutine(pucaj());
                puca = true;
            } else if (Vector3.Distance(this.transform.position, player.transform.position) > 3f) {
                puca = false;
            }
            


        } else if (Vector3.Distance(this.transform.position, player.transform.position) >= aggroDistance) {
            puca = false;
        }

        if (hp <= 0f && !umro) {
            //umri
            umro = true;
            puca = false;
            kretara = false;
            
            
            player.GetComponent<PlayerController>().DamagePlayer(-20);

            StartCoroutine(prestaniKretat());
        }
        
    }

    IEnumerator pucaj() {
        puska.Play();

        yield return new WaitForSeconds(fireRate);

        if (puca) {
            StartCoroutine(pucaj());
        }




    }

    IEnumerator prestaniKretat() {
        
        yield return new WaitForSeconds(10f);
        this.GetComponent<PolygonCollider2D>().enabled = false;
        rigid.velocity = new Vector2(0f, 0f);
        rigid.angularVelocity = 0f;

    }

    IEnumerator pomakniSe() {
        
        rigid.AddForce((player.transform.position - transform.position).normalized * moveSpeed);

        yield return new WaitForSeconds(moveRate);

        if (!umro) {
            StartCoroutine(pomakniSe());
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
