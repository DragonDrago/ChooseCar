using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class Transport : MonoBehaviour
{
    [SerializeField]
    protected bool isPlayer;

    protected PlayerController playerController;
    protected EnemyController enemyController;

    protected Transform playerTransportTransform;
    protected Transform enemyTransportTransform;

    protected bool isHelicopter;
    public bool IsHelicoper { get { return isHelicopter; } set { isHelicopter = value; } }

    private void Awake()
    {
        if (isPlayer)
        {
            playerController = GetComponentInParent<PlayerController>();
            playerTransportTransform = transform.parent;
        }
        else
        {
            enemyController = GetComponentInParent<EnemyController>();
            enemyTransportTransform = transform.parent; 
        }

    }

    public virtual void PlayTrasport()
    {
        ShowTransport();
    }

    public virtual void ShowTransport()
    {
        transform.DOScale(Vector3.one, 0.1f).SetDelay(0.025f).SetEase(Ease.OutBounce);
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
      
    }


    public virtual void StopTransport()
    {
        transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InBounce);

        if(isPlayer)
        {
            playerTransportTransform.DOLocalMoveY(0f, 1f);
        }
        else
        {
            enemyTransportTransform.DOLocalMoveY(0f, 1f);
        }
    }

       

}
