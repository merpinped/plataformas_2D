using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SpriteRenderer spRd;
    bool isJumping = false; //Para comprobar si ya está saltando

    void Start()
    {
        // RigidBody y Sprite renderer del personaje principal
        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float movimientoH = Input.GetAxisRaw("Horizontal"); // 1 si va hacia la derecha y -1 hacia la izquierda
        rb2d.velocity = new Vector2(movimientoH * 7, rb2d.velocity.y);

        if (movimientoH > 0)
        {
            spRd.flipX = false;
            gameObject.GetComponent<Animator>().SetBool("moving", true);
        }
        else if (movimientoH < 0)
        {
            spRd.flipX = true;
            gameObject.GetComponent<Animator>().SetBool("moving", true);
        } else
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }

        if (Input.GetButton("Jump") && !isJumping)
        {
            gameObject.GetComponent<Animator>().SetBool("jumping", true);
            rb2d.AddForce(Vector2.up * 300);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Si el jugador colisiona con un objeto con la etiqueta suelo
        if (other.gameObject.CompareTag("Ground"))
        {
            gameObject.GetComponent<Animator>().SetBool("jumping", false);
            isJumping = false;
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0); // Le quito la fuerza de salto remanente que tuviera
        }
    }
}
