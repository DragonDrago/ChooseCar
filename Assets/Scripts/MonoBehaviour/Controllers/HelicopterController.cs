using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HelicopterController : Transport
{
    [SerializeField] GameObject propeller1;
    [SerializeField] GameObject propeller2;

    [SerializeField] private float propellersForce = 1;

    public override void PlayTrasport()
    {
        if(isPlayer)
        {
            playerController.GetRunner.followSpeed = GameManager.Instance.GetGameData.HelicopterSpeed;

            isHelicopter = true;
        }
       else
        {
            enemyController.GetRunner.followSpeed = GameManager.Instance.GetGameData.HelicopterSpeed;

            isHelicopter = false;
        }

        base.PlayTrasport();

        if(isPlayer)
        {
            playerTransportTransform.DOLocalMoveY(15f, 2f);
        }
        else
        {
            enemyTransportTransform.DOLocalMoveY(15f, 2f);
        }
    }

    public override void StopTransport()
    {
        if(isPlayer)
        {
            playerTransportTransform.DOKill();
            isHelicopter = false;
        }
        else
        {
            enemyTransportTransform.DOKill();
        }

        base.StopTransport();
    }

    protected override void Move()
    {
        base.Move();

        RotatePropellers();
    }

    private void RotatePropellers()
    {
        propeller1.transform.Rotate(new Vector3(0f, 0f, propellersForce));
        propeller2.transform.Rotate(new Vector3(0f, propellersForce, 0f));
    }

}
