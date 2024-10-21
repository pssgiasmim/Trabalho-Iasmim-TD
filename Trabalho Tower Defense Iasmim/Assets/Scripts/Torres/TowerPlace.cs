using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//Classe que faz com que o jogador posicione as torres e compre elas.
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
            ComprarTorre(mousePosition);

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

    //M�todo respons�vel por comprar a torre de acordo com os pontos que o jogador tem.
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
                ExibirMensagem("�rea j� ocupada!");
            }
        }
        else
        {
            ExibirMensagem("Pontos insuficientes para efetuar a compra!");
        }
    }

    //M�todo que "referencia" os tipos das torres com os seus especificos prefabs.
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

    //M�todo que pega a �rea posicionda da torre, onde o jogador clicou
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
