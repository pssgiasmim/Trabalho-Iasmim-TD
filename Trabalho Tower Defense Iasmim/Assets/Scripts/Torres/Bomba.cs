using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe onde a bomba será disparada em direção aos inimigos

public class Bomba : MonoBehaviour
{
    private int dano; //Variável que é o dano que a bala causa.
    private GameObject alvo; //Variável que serve como alvo no inimigo.
    public float velocidade = 5f; //Variável da velocidade em que a bola sew mexe.

    //Método que configurfa o dano da bala.
    public void DefinirDano(int novoDano)
    {
        dano = novoDano;
    }

    //Método que define o alvo da bala.
    public void DefinirAlvo(GameObject novoAlvo)
    {
        alvo = novoAlvo;
    }

    //Método que faz a bomba ir em direção de um inimigo.
    private void Update()
    {
        if (alvo! == null)
        {
            Vector2 direction = (alvo.transform.position - transform.position);
            transform.position += (Vector3)direction * velocidade * Time.deltaTime;

            if (Vector2.Distance(transform.position, alvo.transform.position) < 0.2f)
            {
                alvo.GetComponent<EnemyBase>().ReceberDano(dano);

                Destroy(gameObject);
            }
        }

        else
        {
            Destroy(gameObject);
        }
        
    }
}
