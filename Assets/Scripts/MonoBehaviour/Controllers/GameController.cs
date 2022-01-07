using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Forever;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private LevelGenerator levelGenerator;


    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private EnemyController enemyController;
    public EnemyController GetEnemyController { get { return enemyController; } }


    public void StartGame()
    {
        playerController.StartGame();
        enemyController.StartGame();
    }


    public void RestartGame()
    {
        levelGenerator.Restart();

        playerController.ResetTransport();
        enemyController.ResetTransport();

        //GameManager.Instance.SetSSegmentCout(levelGenerator.);
    }

}
