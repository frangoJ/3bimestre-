using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 10f;  // Velocidade de movimentação
    public float focaPulo = 10f;   // Força do pulo
    private bool noChao = false;   // Verifica se o jogador está no chão

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Verifica se o jogador está colidindo com o chão
        if (collision.gameObject.CompareTag("chao"))
        {
            noChao = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Define que o jogador não está mais no chão
        if (collision.gameObject.CompareTag("chao"))
        {
            noChao = false;
        }
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Movimentação para a esquerda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-velocidade * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = true;
        }

        // Movimentação para a direita
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(velocidade * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = false;
        }

        // Pular
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            _rigidbody2D.AddForce(Vector2.up * focaPulo, ForceMode2D.Impulse);
            noChao = false; // Impede pular novamente até tocar o chão
        }
    }
}