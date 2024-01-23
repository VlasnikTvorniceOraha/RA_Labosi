using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;

    public float playerHealth = 100f;

    public GameObject crosshair;

    public GameObject Canvas;

    public TMP_Text hpText;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
    }

    void Update ()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        LookAtMouse();

        if (playerHealth < 0f) {
            Die();
        }
    }

    private void FixedUpdate()
    {  
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void LookAtMouse() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = mousePos - new Vector2(transform.position.x, transform.position.y);
        crosshair.transform.position = Input.mousePosition;
        Canvas.transform.rotation = Quaternion.identity;
    }

    private void Die() {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }

    public void DamagePlayer(float damage) {
        playerHealth -= damage;
        playerHealth = (float)Math.Round(playerHealth, 2);
        hpText.text = playerHealth.ToString();
    }

    private void OnParticleCollision(GameObject other) {
        Debug.Log("hit");
        switch(other.tag) {

            case "Bouncy":
            DamagePlayer(5f);
            break;

            case "Bubble":
            DamagePlayer(0.1f);
            break;

            case "Laser":
            DamagePlayer(5f);
            break;

            case "Sphere":
            DamagePlayer(1f);
            break;

            default:
            break;

        }
    }
}
