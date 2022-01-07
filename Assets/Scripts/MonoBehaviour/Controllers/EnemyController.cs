using System.Collections;
using System.Collections.Generic;
using Dreamteck.Forever;
using UnityEngine;

public class EnemyController : Controllers
{


    private bool isFinish;
    public bool IsFinish { get { return isFinish; } }

    public override void StartGame()
    {
        base.StartGame();
    }

    protected override void ShowTransport(int index)
    {
        base.ShowTransport(index);
    }


    public override void TriggerEnter(Collider other)
    {
        base.TriggerEnter(other);

        if (other.gameObject.CompareTag("Mountain"))
        {
            isMountain = true;
            StartCoroutine(WaitForShowTransport(2));
        }

        if (other.gameObject.CompareTag("Island"))
        {
            isIsland = true;
            StartCoroutine(WaitForShowTransport(1));
        }

        if (other.gameObject.CompareTag("City"))
        {
            StartCoroutine(WaitForShowTransport(0));
        }

        if (other.gameObject.CompareTag("Desert"))
        {
            StartCoroutine(WaitForShowTransport(0));
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            isFinish = true;
        }
    }

    public override void TriggerExit(Collider other)
    {
        base.TriggerExit(other);

        if (other.gameObject.CompareTag("Mountain"))
        {
            isMountain = false;
            ShowTransport(0);
        }

        if (other.gameObject.CompareTag("Island"))
        {
            isIsland = false;
            ShowTransport(0);
        }
    }


    private IEnumerator WaitForShowTransport(int index)
    {
        if(activeIndex != index)
        {
            basicRanner.followSpeed = 0;

            int random = Random.Range(3, 6);

            yield return new WaitForSeconds(random);

            ShowTransport(index);
        }
        
    }

}
