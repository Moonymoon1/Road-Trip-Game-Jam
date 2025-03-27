using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] DialogoUI dialogoUI;
    public DialogoUI DialogoUI => dialogoUI;
    public Interagivel Interagivel { get; set;}

    [SerializeField] float velocidade = 10f;
    Rigidbody2D rb;
    Vector2 direção;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movimento();
        Rotação();
        if(Input.GetKeyDown(KeyCode.E))
        {
            Interagivel?.Interagir(this);
        }
    }
    void Movimento()
    {
        if(dialogoUI.EstaAberto) return;

        direção = new Vector2 (Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;
        rb.velocity = direção * velocidade;
    }
    void Rotação()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90f);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 270f);
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180f);
        }
    }
}

