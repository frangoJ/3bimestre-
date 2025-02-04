using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidadeDoJogador;
    public float alturaDoPulo;

    public Rigidbody2D oRigifbody2D;
    
    public SpriteRenderer OSpriteRenderer;
    public AudioSource somDoPulo;

    public bool estaNoChao;
    public Transform verficadorDeChao;
    public float raioDeVerificacao;
    public LayerMask layerDoChao;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MovimentarJogador();
        pular();
    }


    public void MovimentarJogador()
    {
        float inputDoMovimento = Input.GetAxisRaw("Horizontal");
        oRigifbody2D.velocity = new Vector2(inputDoMovimento * velocidadeDoJogador, oRigifbody2D.velocity.y);
        if (inputDoMovimento > 0)
        {
            OSpriteRenderer.flipX = false;
        }

        if (inputDoMovimento < 0)
        {
            OSpriteRenderer.flipX = true;
        }
    }

    public void pular()
    {
        estaNoChao = Physics2D.OverlapCircle(verficadorDeChao.position, raioDeVerificacao, layerDoChao);

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao == true)
        {
            oRigifbody2D.velocity = Vector2.up * alturaDoPulo;
            somDoPulo.Play();
        }
    }
}
