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
        Vector3 mousePosition = Input.mousePosition; //Variável que recebe a posição do mouse.
        if (Input.GetMouseButtonDown(0))
        {
            
            mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0; // Define a posição z para 0 em 2D.

            Instantiate(fireTowerPrefab, mousePosition, Quaternion.identity);
            Instantiate(iceTowerPrefab, mousePosition, Quaternion.identity);
            Instantiate(lightTowerPrefab, mousePosition, Quaternion.identity);
        }

        switch (currentTipoTorre)
        {
            case TipoTorre.Fire:

                Instantiate(fireTowerPrefab, mousePosition, Quaternion.identity);

            break;

            case TipoTorre.Ice:

                Instantiate(iceTowerPrefab, mousePosition, Quaternion. identity);

            break;

            case TipoTorre.Light:

                Instantiate(lightTowerPrefab, mousePosition, Quaternion.identity);

            break;
        }
    }

    
}
