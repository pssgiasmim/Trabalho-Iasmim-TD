using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//Classe que faz com que o jogador escolha onde posicionar as torres.
public class TowerPlace : MonoBehaviour
{
    public GameObject fireTowerPrefab; //Variável do prefab da torre de fogo.
    public GameObject iceTowerPrefab; //Variável do prefab da torre de gelo.
    public GameObject lightTowerPrefab; //Variável do prefab da torre de luz.
    private Camera mainCamera; //Variável que faz com que a camerâ "acompanhe" do jogador.


    public int valorFireTower = 100; //Variável com valor de fire tower.
    public int valorIceTower = 150; //Variável com valor de ice tower.
    public int valorLightTower = 200; //Variável com valor de light tower.

    [SerializeField] TextMeshProUGUI textoDaMensagem; //Variável que vai aparecer o texto das mensagens sobre as compras.

    //Método que pega a camera principal.
    public void Start()
    {
        mainCamera = Camera.main;
        textoDaMensagem.text = ""; 
    }

    //Método que identifica os membros da numeração, que no caso são as identificações das torres.
    private enum TipoTorre
    {
        Fire,
        Ice,
        Light
    }

    //Especifica o tipo de torre padrão
    private TipoTorre currentTipoTorre = TipoTorre.Fire;

    //Método responsável por "comprar" as torres, detectar o clique do mouse e atribuir teclas do keypad.
    public void Update()
    {
        //Detecta o clique do mouse
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition; //Variável que recebe a posição do mouse.
            mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0; // Define a posição z para 0 em 2D.

            int valor = 0; //Variável de valor (geral) que é igual a 0.

            switch (currentTipoTorre)
            {
                case TipoTorre.Fire:
                    valor = valorFireTower;
                break;

                case TipoTorre.Ice:
                    valor = valorFireTower;
                break;

                case TipoTorre.Light:
                    valor = valorFireTower;
                break;

            }


            if (GameManager.instance.ObterPontos() >= valor)
            {
                //Instancia a torre com base no que foi selecionado.
                switch (currentTipoTorre)
                {
                    case TipoTorre.Fire:

                        Instantiate(fireTowerPrefab, mousePosition, Quaternion.identity);

                        break;

                    case TipoTorre.Ice:

                        Instantiate(iceTowerPrefab, mousePosition, Quaternion.identity);

                        break;

                    case TipoTorre.Light:

                        Instantiate(lightTowerPrefab, mousePosition, Quaternion.identity);

                        break;
                }

                GameManager.instance.DescontarPontos(valor);
                textoDaMensagem.text = "Torre " + currentTipoTorre + " comprada!";
            }
            else
            {
                textoDaMensagem.text = "Pontos insuficientes para comprar a torre.";
            }
            
        }

        //Botões que selecionam a torre.
        //Botões [1], [2] e [3] alternam os tipos de torre. No keyPad
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            currentTipoTorre = TipoTorre.Fire;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            currentTipoTorre = TipoTorre.Ice;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            currentTipoTorre = TipoTorre.Light;
        }
    }
}
