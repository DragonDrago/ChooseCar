using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameData", menuName = "Dates/GameData")]
public class GameData : ScriptableObject
{
    [SerializeField]
    private int level = 1;
    public int Level { get { return level; } }

    [SerializeField]
    private double totalCoin = 600;
    public double TotalCoin { get { return totalCoin; } }

    [SerializeField]
    private int carLevel = 1;
    public int CarLevel { get { return carLevel; } }

    [SerializeField]
    private int boatLevel = 1;
    public int BoatLevel { get { return boatLevel; } }

    [SerializeField]
    private int helicoptreLevel = 1;
    public int HelicopterLevel { get { return helicoptreLevel; } }

    [SerializeField]
    private float carSpeed = 10;
    public float CarSpeed { get { return carSpeed; } }

    [SerializeField]
    private float boatSpeed = 10;
    public float BoatSpeed { get { return boatSpeed; } }

    [SerializeField]
    private float helicopterSpeed = 5;
    public float HelicopterSpeed { get { return helicopterSpeed; } }

    [SerializeField]
    private int carAmount = 1600;
    public int CarAmount { get { return carAmount; } }

    [SerializeField]
    private int boatAmount = 1600;
    public int BoatAmount { get { return boatAmount; } }

    [SerializeField]
    private int helicopterAmount = 1600;
    public int HelicopterAmount { get { return helicopterAmount; } }

    [SerializeField]
    private bool isSound = true;
    public bool IsSound { get { return isSound; } set { isSound = value; } }

    [SerializeField]
    private int giftCoin = 600;

    [SerializeField]
    private string key = "datas";

    public void Load()
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), this);
    }

    public void CompletedLevel()
    {
        level++;
        totalCoin += 600;
    }


    public void UpgradeCar()
    {
        if(totalCoin >= carAmount)
        {
            totalCoin -= carAmount;
            carLevel++;
            carSpeed += 0.1f;
        }
    }

    public void UpgradeBoat()
    {
        if(totalCoin >= boatAmount)
        {
            totalCoin -= boatAmount;
            boatLevel++;
            boatSpeed += 0.1f;
        }
    }

    public void UpgradeHelicopter()
    {
        if(totalCoin >= helicopterAmount)
        {
            totalCoin -= helicopterAmount;
            helicoptreLevel++;
            helicopterSpeed += 0.1f;
        }
    }

    public void SetTotalCoin(int x)
    {
        totalCoin += giftCoin * x;
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }

}
