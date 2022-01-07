using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private Transform startText;

    [SerializeField]
    private Text levelText;

    [SerializeField]
    private Text totalCoinText;

    [SerializeField]
    private Text upgradeLevelTextCar;

    [SerializeField]
    private Text uprgadeLevelTextBoat;

    [SerializeField]
    private Text upgradeLevelTextHelicopter;

    [SerializeField]
    private Text upgradeAmountTextCar;

    [SerializeField]
    private Text upgradeAmountTextBoat;

    [SerializeField]
    private Text upgradeAmountTextHelicopter;

    [SerializeField]
    private Image soundImageOn;

    [SerializeField]
    private Image soundImageOff;

    public void StartPlayAnimation()
    {
        UpdateStates();

        startText.DOScale(1f, 1f).SetLoops(-1, LoopType.Yoyo);
    }

    public void StartStopAnimation()
    {
        startText.DOKill();
    }


    public void OnClickUpgradeCar()
    {
        GameManager.Instance.GetGameData.UpgradeCar();
        UpdateStates();
    }

    public void OnClickUpgradeBoat()
    {
        GameManager.Instance.GetGameData.UpgradeBoat();
        UpdateStates();
    }

    public void OnClickUpgradeHelicopter()
    {
        GameManager.Instance.GetGameData.UpgradeHelicopter();
        UpdateStates();
    }

    private void UpdateStates()
    {
        levelText.text = "Level " + GameManager.Instance.GetGameData.Level;
        totalCoinText.text = GameManager.Instance.GetGameData.TotalCoin.ToString();

        upgradeLevelTextCar.text = "Level " + GameManager.Instance.GetGameData.CarLevel;
        uprgadeLevelTextBoat.text = "Level " + GameManager.Instance.GetGameData.BoatLevel;
        upgradeLevelTextHelicopter.text = "Level " + GameManager.Instance.GetGameData.HelicopterLevel;

        upgradeAmountTextBoat.text = GameManager.Instance.GetGameData.BoatAmount.ToString();
        upgradeAmountTextCar.text = GameManager.Instance.GetGameData.CarAmount.ToString();
        upgradeAmountTextHelicopter.text = GameManager.Instance.GetGameData.HelicopterAmount.ToString();
    }


    public void OnClickSound()
    {
        if(GameManager.Instance.GetGameData.IsSound)
        {
            soundImageOn.enabled = false;
            soundImageOff.enabled = true;

            GameManager.Instance.GetGameData.IsSound = false;
        }
        else
        {
            soundImageOn.enabled = true;
            soundImageOff.enabled = false;

            GameManager.Instance.GetGameData.IsSound = true;
        }
    }

}
