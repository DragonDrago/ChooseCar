using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{

    [SerializeField]
    private Button[] buttons = new Button[3];

    [SerializeField]
    private Image[] images = new Image[3];

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private Sprite[] buttonSprites = new Sprite[3];

    [SerializeField]
    private Text levelText;

    private bool isBlock, isBackBlock;


    private void Start()
    {
        Events.groundChangeDelegate += ChangeGround;
    }


    public void SetButtonIcons()
    {
        foreach(Button button in buttons)
        {
            button.onClick.RemoveAllListeners();
        }

        levelText.text = "Level " + GameManager.Instance.GetGameData.Level;

        int[] indexes = Constance.GetRandomIndex(3);

        buttons[0].onClick.AddListener(() => OnClickButton(indexes[0]));
        images[0].sprite = buttonSprites[indexes[0]];

        buttons[1].onClick.AddListener(() => OnClickButton(indexes[1]));
        images[1].sprite = buttonSprites[indexes[1]];

        buttons[2].onClick.AddListener(() => OnClickButton(indexes[2]));
        images[2].sprite = buttonSprites[indexes[2]];

    }

    private void OnClickButton(int index)
    {
        if (isBlock)
            return;

        isBlock = true;

        Events.buttonClickDelegate?.Invoke(index);

        StartCoroutine(WaitOnClick());
    }
    
    private IEnumerator WaitOnClick()
    {
        yield return new WaitForSeconds(0.5f);

        isBlock = false;
    }

    public void SetSliderMaxValue(int value)
    {
        slider.maxValue = value;
    }

    private void ChangeGround(int value)
    {
        slider.value = value;
    }

    public void ResetSlider()
    {
        slider.value = 0;
    }

    public void OnClickBack()
    {
        if (isBackBlock)
            return;

        isBackBlock = true;

        GameManager.Instance.RestartGame();

        StartCoroutine(WaitOnClickBack());
    }

    private IEnumerator WaitOnClickBack()
    {
        yield return new WaitForSeconds(0.5f);

        isBackBlock = false;
    }


}
