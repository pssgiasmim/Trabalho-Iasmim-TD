using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//Classe que faz com que o jogador escolha onde posicionar as torres.
public class TowerPlace : MonoBehaviour
{
    public GameObject fireTowerPrefab; //Vari�vel do prefab da torre de fogo.
    public GameObject iceTowerPrefab; //Vari�vel do prefab da torre de gelo.
    public GameObject lightTowerPrefab; //Vari�vel do prefab da torre de luz.
    private Camera mainCamera; //Vari�vel que faz com que a camer� "acompanhe" do jogador.


    public int valorFireTower = 100; //Vari�vel com valor de fire tower.
    public int valorIceTower = 150; //Vari�vel com valor de ice tower.
    public int valorLightTower = 200; //Vari�vel com valor de light tower.

    [SerializeField] TextMeshProUGUI textoDaMensagem; //Vari�vel que vai aparecer o texto das mensagens sobre as compras.

    //M�todo que pega a camera principal.
    public void Start()
    {
        mainCamera = Camera.main;
        textoDaMensagem.text = ""; 
    }

    //M�todo que identifica os membros da numera��o, que no caso s�o as identifica��es das torres.
    private enum TipoTorre
    {
        Fire,
        Ice,
        Light
    }

    //Especifica o tipo de torre padr�o
    private TipoTorre currentTipoTorre = TipoTorre.Fire;

    //M�todo respons�vel por "comprar" as torres, detectar o clique do mouse e atribuir teclas do keypad.
    public void Update()
    {
        //Detecta o clique do mouse
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition; //Vari�vel que recebe a posi��o do mouse.
            mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0; // Define a posi��o z para 0 em 2D.

            int valor = 0; //Vari�vel de valor (geral) que � igual a 0.

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

        //Bot�es que selecionam a torre.
        //Bot�es [1], [2] e [3] alternam os tipos de torre. No keyPad
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
