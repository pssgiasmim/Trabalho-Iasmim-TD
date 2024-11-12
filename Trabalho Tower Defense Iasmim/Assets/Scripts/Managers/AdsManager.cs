using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

//Classe que gerencia as propagandas na cena do jogo.

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener,IUnityAdsShowListener
{
    public string projetoID = "5729648"; //ID do projeto;
    public string bannerID = "Banner_Android"; //ID do banner;
    public string interstitialIDSkip = "Interstitial_Android"; //ID do interstitial que pode pular;
    public string interstitialID = "Interstitial_DontSkip"; //ID do interstitial que NÃO pode pular;
    public string rewardedID = "Rewarded_Android"; //ID da recompensa;


    // Inicia tudo
    void Start()
    {
        Advertisement.Initialize(projetoID, true, this); //Inicia o Unity Ads, preparando o serviço para exibir anúncios no jogo;
    }

    //Mostra o banner num determinado tempo
    public void MostrarBanner()
    {
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER); //Configura o banner na posição superior da tela;

        Advertisement.Banner.Show("Banner_Android"); //Exibe um banner na posição definida pelo SetPosition;
    }

    public void OnInitializationComplete()
    {
        throw new System.NotImplementedException();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    

   
}
