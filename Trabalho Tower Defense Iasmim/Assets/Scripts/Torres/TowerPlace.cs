using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//Classe que faz com que o jogador posicione as torres e compre elas.
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
            ComprarTorre(mousePosition);

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

    //Método responsável por comprar a torre de acordo com os pontos que o jogador tem.
    private void ComprarTorre(Vector3 position)
    {
        int valor = currentTipoTorre switch
        {
            TipoTorre.Fire => valorFireTower,
            TipoTorre.Ice => valorIceTower,
            TipoTorre.Light => valorLightTower,
            _ => 0
        };

        if (GameManager.instance.ObterPontos() >= valor)
        {
            TowerArea area = PegarAreaPosicionada(position);
            if (area != null && !area.estaOcupado)
            {
                Instantiate(GetTowerPrefab(), position, Quaternion.identity);
                GameManager.instance.DescontarPontos(valor);
                area.estaOcupado = true;
                ExibirMensagem("Torre " + currentTipoTorre + " comprada!");

            }
            else
            {
                ExibirMensagem("Área já ocupada!");
            }
        }
        else
        {
            ExibirMensagem("Pontos insuficientes para efetuar a compra!");
        }
    }

    //Método que "referencia" os tipos das torres com os seus especificos prefabs.
    private GameObject GetTowerPrefab()
    {
        return currentTipoTorre switch
        {
            TipoTorre.Fire => fireTowerPrefab,
            TipoTorre.Ice => iceTowerPrefab,
            TipoTorre.Light => lightTowerPrefab,
            _ => null

        };
    }

    //Método que pega a área posicionda da torre, onde o jogador clicou
    private TowerArea PegarAreaPosicionada (Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.5f);
        foreach  (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent<TowerArea>(out TowerArea area))
            {
                return area;
            }
        }

        return null;
    }

    private void ExibirMensagem (string mensagem)
    {
        textoDaMensagem.text = mensagem;
    }

}
