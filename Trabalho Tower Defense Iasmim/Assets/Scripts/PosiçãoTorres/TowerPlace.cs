using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Classe que faz com que o jogador escolha onde posicionar as torres.
public class TowerPlace : MonoBehaviour
{
    public GameObject fireTowerPrefab; //Variável do prefab da torre de fogo.
    public GameObject iceTowerPrefab; //Variável do prefab da torre de gelo.
    public GameObject lightTowerPrefab; //Variável do prefab da torre de luz.
    private Camera mainCamera; //Variável que faz com que a camerâ "acompanhe" do jogador.

    //Método que pega a camera principal.
    public void Start()
    {
        mainCamera = Camera.main;
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

    //Método que detecta o clique do mouse.
    public void Update()
    {
        //Detecta o clique do mouse
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition; //Variável que recebe a posição do mouse.
            mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0; // Define a posição z para 0 em 2D.

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
        }

        //Botões que selecionam a torre.
        //Botões [1], [2] e [3] alternam os tipos de torre. No keyPad
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {

        }
       
    }

    
}
