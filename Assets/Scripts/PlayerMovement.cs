using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float speed = 2f;
    public float jumpForce = 4f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool facingRight = true; // Variable para controlar la dirección del personaje
    Vector3 initialPosition;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    void Update()
    {
        // Movimiento horizontal
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // Verificar si está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

         // Girar el personaje según la dirección en la que se mueve
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }



     // Método para voltear el personaje
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.CompareTag("PlataformaMovil"))
    {
        // Verifica si la plataforma está activa antes de asignar parent
        if(collision.gameObject.activeInHierarchy)
        {
            transform.SetParent(collision.transform);
        }
    }
}

    private void OnCollisionExit2D(Collision2D collision)
{
    if(collision.gameObject.CompareTag("PlataformaMovil"))
    {
        // Verifica si el objeto aún existe y no es nulo
        if(collision.gameObject != null)
        {
            transform.SetParent(null);
            // Opcional: Mantener la escala mundial
            //transform.localScale = Vector3.one;
        }
    }
}
}

