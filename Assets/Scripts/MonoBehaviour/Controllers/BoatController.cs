
using DG.Tweening;
using UnityEngine;

public class BoatController : Transport
{

    public override void PlayTrasport()
    {
        if(isPlayer)
        {
            if (isHelicopter && playerController.IsMountain)
                return;

            if (!playerController.IsIsland)
            {
                playerController.GetRunner.followSpeed = 0;
            }
            else
            {
                playerController.GetRunner.followSpeed = GameManager.Instance.GetGameData.BoatSpeed;
            }
        }
        else
        {
            if (!enemyController.IsIsland)
            {
                enemyController.GetRunner.followSpeed = 0;
            }
            else
            {
                enemyController.GetRunner.followSpeed = GameManager.Instance.GetGameData.BoatSpeed;
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
