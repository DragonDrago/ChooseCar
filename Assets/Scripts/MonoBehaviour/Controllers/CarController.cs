using DG.Tweening;
using UnityEngine;

public class CarController : Transport
{
    public override void PlayTrasport()
    {
        if(isPlayer)
        {
            if (isHelicopter && playerController.IsMountain)
                return;

            if (playerController.IsIsland)
            {
                playerController.GetRunner.followSpeed = playerController.GetRunner.followSpeed / 10f;
            }
            else
            {
                playerController.GetRunner.followSpeed = GameManager.Instance.GetGameData.CarSpeed;
            }
        }
        else
        {
            if (enemyController.IsIsland)
            {
                enemyController.GetRunner.followSpeed = enemyController.GetRunner.followSpeed / 10f;
            }
            else
            {
                enemyController.GetRunner.followSpeed = GameManager.Instance.GetGameData.CarSpeed;
            }
        }

        base.PlayTrasport();
    }

    public override void StopTransport()
    {
        if(isPlayer)
        {
            if (isHelicopter && playerController.IsMountain)
                return;
        }

        base.StopTransport();
    }


    protected override void Move()
    {
        base.Move();

        
    }
}
