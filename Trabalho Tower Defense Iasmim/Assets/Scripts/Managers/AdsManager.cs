using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using static UnityEngine.Advertisements.Advertisement;

//Classe que gerencia as propagandas na cena do jogo.

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener,IUnityAdsShowListener
{
    public string projetoID = "5729648"; //ID do projeto;
    public string bannerID = "Banner_Android"; //ID do banner;
    public string interstitialIDSkip = "Interstitial_Android"; //ID do interstitial que pode pular;
    public string interstitialID = "Interstitial_DontSkip"; //ID do interstitial que NÃO pode pular;
    public string rewardedID = "Rewarded_Android"; //ID da recompensa;

    private bool anuncioExibido = false; //Verifica s tem anúncio sendo exibido;
    public float tempoExibicaoBanner = 10f; //Tempo de exibição do banner na  tela;
    public float tempoEsconderBanner = 5f; //Tempo em que o banner fica escondido;
    private float timer = 0f; //Timer para controlar o tempo;
    private bool bannerVisivel = false; //Controla se o Banner está aparecendo na tela;

    // Inicia tudo
    void Start()
    {
        Advertisement.Initialize(projetoID, true, this); //Inicia o Unity Ads, preparando o serviço para exibir anúncios no jogo;
        
    }

    //Método que é chamado a cada frame
    void Update()
    {
        if (anuncioExibido) return; // Não mostra o banner enquanto outro anúncio estiver sendo exibido
        {
            timer += Time.deltaTime;
        }

        // Lógica para exibir e esconder o banner com base no tempo
        if (bannerVisivel)
        {
            if (timer >= tempoExibicaoBanner)
            {
                Advertisement.Banner.Hide(); // Esconde o banner depois de 10 segundos
                bannerVisivel = false;
                timer = 0f; // Reinicia o timer
            }
        }
        else
        {
            if (timer >= tempoEsconderBanner)
            {
                // Exibe o banner depois de 5 segundos
                Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER); //Configura o banner na posição superior da tela;
                Advertisement.Banner.Show("Banner_Android"); 
                bannerVisivel=true;
                timer = 0f; 
            }
        }
    }


    //Mostra o banner num determinado tempo
    public void MostrarBanner()
    {
        if (!Advertisement.isInitialized || Advertisement.isShowing) return; //Não mostrar o banner se outro anúncio estiver sendo exibido;

        bannerVisivel = true;
        timer = 0f;
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        //Para dar recompensa, o delegate pode ser criado dentro deste script, porém deve armazenar os métodos de fora.
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        //Aprecer mensagem que ocorreu erro ao carregar a propaganda
    }

    public void OnUnityAdsShowStart(string placementId)
    {

    }
    public void OnInitializationComplete()
    {
        //Não utilizar
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        //Não utilizar
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        //Não Utilizar
    }

    

   
}
