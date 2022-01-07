using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FinishUI : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup winGroup;

    [SerializeField]
    private CanvasGroup failGroup;

    [SerializeField]
    private Text coinText;

    [SerializeField]
    private Button watchButton;

    [SerializeField]
    private Button coinButton;


    public void ShowWin()
    {
        winGroup.DOFade(1f, 0.1f);
        winGroup.interactable = true;
        winGroup.blocksRaycasts = true;


        failGroup.interactable = false;
        failGroup.blocksRaycasts = false;
        failGroup.DOFade(0f, 0.1f);
    }

    public void ShowFail()
    {
        winGroup.DOFade(0f, 0.1f);
        winGroup.interactable = false;
        winGroup.blocksRaycasts = false;


        failGroup.interactable = true;
        failGroup.blocksRaycasts = true;
        failGroup.DOFade(1f, 0.1f);
    }

    public void OnClickNextButton()
    {
        GameManager.Instance.GetInterstitial.ShowInterstitial();
        GameManager.Instance.NextLevel();
        GameManager.Instance.GetGameData.SetTotalCoin(1);
    }

    public void OnClickRestartButton()
    {
        GameManager.Instance.GetInterstitial.ShowInterstitial();
        GameManager.Instance.RestartGame();
    }

}
