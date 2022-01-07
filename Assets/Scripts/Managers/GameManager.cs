using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private GameController gameController;

    [SerializeField]
    private GameData gameData;
    public GameData GetGameData { get { return gameData; } }

    private Interstitial interstitial;
    public Interstitial GetInterstitial { get { return interstitial; } }

    private bool isFinish;
    public bool IsFinish { get { return isFinish; } set { isFinish = value; } }

    private bool isPause;
    public bool IsPause { get { return isPause; } set { isPause = value; } }

    private bool isWin;
    public bool IsWin { get { return isWin; } set { isWin = value; } }

    protected override void Awake()
    {
        base.Awake();

        interstitial = GetComponent<Interstitial>();

        uiManager.ShowLoading();
        gameData.Load();
    }


    public void StartGame()
    {
        gameController.StartGame();
    }

    public void RestartGame()
    {
        gameController.RestartGame();
        uiManager.ShowLoading();
    }

    public void FinishGame()
    {
        isFinish = true;
        uiManager.ShowFinish();
    }

    public void NextLevel()
    {
        gameData.CompletedLevel();
        IsFinish = false;
        gameController.RestartGame();
        uiManager.ShowLoading();
    }

    private void OnApplicationPause(bool pause)
    {
        gameData.Save();
    }

    private void OnApplicationQuit()
    {
        gameData.Save();
    }
}
