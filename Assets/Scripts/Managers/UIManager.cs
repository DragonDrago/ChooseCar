using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Dreamteck.Forever;

public class UIManager : Singleton<UIManager>
{

    [SerializeField]
    private CanvasGroup menuGroup;

    [SerializeField]
    private CanvasGroup gameGroup;

    [SerializeField]
    private CanvasGroup finishGroup;

    [SerializeField]
    private MenuUI menuUI;

    [SerializeField]
    private GameUI gameUI;
    public GameUI GetGameUI { get { return gameUI; } }

    [SerializeField]
    private FinishUI finishUI;

    [SerializeField]
    private CanvasGroup loadingGroup;

    [SerializeField]
    private Slider slider;

    public void ShowMenu()
    {
        menuGroup.DOFade(1f, 0.25f);
        menuGroup.interactable = true;
        menuGroup.blocksRaycasts = true;

        gameGroup.DOFade(0f, 0.01f);
        gameGroup.interactable = false;
        gameGroup.blocksRaycasts = false;

        finishGroup.DOFade(0f, 0.01f);
        finishGroup.interactable = false;
        finishGroup.blocksRaycasts = false;

        menuUI.StartPlayAnimation();
    }


    public void ShowGame()
    {
        gameUI.SetButtonIcons();
        gameUI.ResetSlider();

        menuUI.StartStopAnimation();

        menuGroup.DOFade(0f, 0.01f);
        menuGroup.interactable = false;
        menuGroup.blocksRaycasts = false;

        gameGroup.DOFade(1f, 0.25f);
        gameGroup.interactable = true;
        gameGroup.blocksRaycasts = true;

        GameManager.Instance.StartGame();
    }

    public void ShowFinish()
    {
        if(GameManager.Instance.IsWin)
        {
            finishUI.ShowWin();
        }
        else
        {
            finishUI.ShowFail();
        }

        finishGroup.DOFade(1f, 0.25f).SetDelay(2f).OnComplete( () => {
            gameGroup.interactable = false;
            gameGroup.blocksRaycasts = false;

            finishGroup.interactable = true;
            finishGroup.blocksRaycasts = true;

        });
    }

    public void ShowLoading()
    {
        loadingGroup.DOFade(1f, 0.001f);
        loadingGroup.interactable = true;
        loadingGroup.blocksRaycasts = false;

        StartCoroutine(WaitForLoading());
    }

    private IEnumerator WaitForLoading()
    {
        float value = 0;

        while(value <= slider.maxValue)
        {
            slider.value = value;
            value += 0.1f;

            yield return new WaitForSeconds(0.1f);
        }

        slider.value = value;

        loadingGroup.interactable = false;
        loadingGroup.blocksRaycasts = false;
        loadingGroup.DOFade(0f, 0.05f);

        ShowMenu();
    }

    public void OnClickStart()
    {
        ShowGame();
    }

    public void OnClickBack()
    {
        ShowMenu();
    }

}
