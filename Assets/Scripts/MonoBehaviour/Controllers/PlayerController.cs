using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : Controllers
{

    private bool isMountain;
    public bool IsMountain { get { return isMountain; } }

    private void Awake()
    {
        Events.buttonClickDelegate += PlayTransport;
    }

    public override void StartGame()
    {
        base.StartGame();

        transports[0].PlayTrasport();
    }

    private void PlayTransport(int index)
    {
        if (transports[activeIndex].IsHelicoper && isMountain)
            return;

        if(activeIndex != index)
        {
            ShowTransport(index);
        }
    }

    protected override void ShowTransport(int index)
    {
        base.ShowTransport(index);
    }

    private void OnDisable()
    {
        Events.buttonClickDelegate -= PlayTransport;
    }


    public override void TriggerEnter(Collider other)
    {
        base.TriggerEnter(other);

        if (other.gameObject.CompareTag("Mountain"))
        {
            isMountain = true;

            if (activeIndex != 2)
            {
                basicRanner.followSpeed = 0f;
            }
        }


        if (other.gameObject.CompareTag("Island"))
        {
            isIsland = true;

            if (activeIndex == 0)
            {
                basicRanner.followSpeed = basicRanner.followSpeed / 10f;
            }
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.Instance.IsWin = gameController.GetEnemyController.IsFinish ? false : true;

            GameManager.Instance.FinishGame();
        }

        if (other.gameObject.CompareTag("ChangeGround"))
        {
            groundIndex++;

            Events.groundChangeDelegate?.Invoke(groundIndex);
        }

    }

    public override void TriggerExit(Collider other)
    {
        base.TriggerExit(other);

        if (other.gameObject.CompareTag("Mountain"))
        {
            isMountain = false;
        }

        if (other.gameObject.CompareTag("Island"))
        {
            isIsland = false;

            if (activeIndex == 1)
            {
                basicRanner.followSpeed = 0;
            }
        }

    }

   
}
