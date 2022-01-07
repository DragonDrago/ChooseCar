using System.Collections;
using System.Collections.Generic;
using Dreamteck.Forever;
using UnityEngine;

public class Controllers : MonoBehaviour
{
    [SerializeField]
    protected List<Transport> transports;

    [SerializeField]
    protected GameController gameController;

    protected Runner basicRanner;
    public Runner GetRunner { get { return basicRanner; } }

    protected int activeIndex = 0;
    protected int groundIndex = 0;

    protected bool isMountain;
    public bool IsMountain { get { return isMountain; } }

    protected bool isIsland;
    public bool IsIsland { get { return isIsland; } }


    public virtual void StartGame()
    {
        basicRanner = GetComponent<Runner>();

        basicRanner.followSpeed = GameManager.Instance.GetGameData.CarSpeed;
    }

    protected virtual void ShowTransport(int index)
    {
        transports[activeIndex].StopTransport();

        activeIndex = index;

        transports[index].PlayTrasport();
    }

    public virtual void ResetTransport()
    {
        transports[activeIndex].StopTransport();
        activeIndex = 0;
        transports[activeIndex].ShowTransport();
        basicRanner.followSpeed = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter(other);
    }


    public virtual void TriggerEnter(Collider other)
    {

    }


    private void OnTriggerExit(Collider other)
    {
        TriggerExit(other);
    }
    
    public virtual void TriggerExit(Collider other)
    {

    }

}
