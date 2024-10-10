using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe onde a bomba ser� disparada em dire��o aos inimigos

public class Bomba : MonoBehaviour
{
    private int dano; //Vari�vel que � o dano que a bala causa.
    private GameObject alvo; //Vari�vel que serve como alvo no inimigo.
    public float velocidade = 5f; //Vari�vel da velocidade em que a bola sew mexe.

    //M�todo que configurfa o dano da bala.
    public void DefinirDano(int novoDano)
    {
        dano = novoDano;
    }

    //M�todo que define o alvo da bala.
    public void DefinirAlvo(GameObject novoAlvo)
    {
        alvo = novoAlvo;
    }

    //M�todo que faz a bomba ir em dire��o de um inimigo.
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
