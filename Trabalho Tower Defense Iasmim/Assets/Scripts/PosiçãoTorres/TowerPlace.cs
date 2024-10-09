using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe que faz com que o jogador escolha onde posicionar as torres.
public class TowerPlace : MonoBehaviour
{
    public GameObject fireTowerPrefab; //Vari�vel do prefab da torre de fogo.
    public GameObject iceTowerPrefab; //Vari�vel do prefab da torre de gelo.
    public GameObject lightTowerPrefab; //Vari�vel do prefab da torre de luz.
    private Camera mainCamera; //Vari�vel que faz com que a camer� "acompanhe" do jogador.

    //M�todo que pega a camera principal.
    public void Start()
    {
        mainCamera = Camera.main;
    }

    //M�todo que detecta o clique do mouse.
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition; //Vari�vel que recebe a posi��o do mouse.
            mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0; // Define a posi��o z para 0 em 2D.

            Instantiate(fireTowerPrefab, mousePosition, Quaternion.identity);
            Instantiate(iceTowerPrefab, mousePosition, Quaternion.identity);
            Instantiate(lightTowerPrefab, mousePosition, Quaternion.identity);
        }
    }
}
