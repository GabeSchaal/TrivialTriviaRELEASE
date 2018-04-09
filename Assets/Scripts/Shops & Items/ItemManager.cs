using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ItemManager : MonoBehaviour {

    PreLoader pl;

    int healthyHeartLivesIncrease = 2;
    int strongShieldIncrease = 4;

    void Awake()
    {
        pl = PreLoader.instance;
    }

    void Start()
    {
        StartCoroutine(ItemPurchaseManager.instance.RandomItemCD());
    }

    public void UseHealthyHeart()
    {
        if(ScoreAndLivesManager.instance.currentLives <= 3 && pl.gameData.HealthyHeartItem >= 1)
        {
            ScoreAndLivesManager.instance.currentLives += healthyHeartLivesIncrease;

            pl.gameData.HealthyHeartItem -= 1;

            SceneUI.instance.hhQuantityText.text = pl.gameData.HealthyHeartItem.ToString();
            
            ScoreAndLivesManager.instance.LifeTracker();
        }
        else
        {
            //TODO: Add popup that tells the player that they have too many lives
        }
    }

    public void UseStrongShield()
    {
        if(ScoreAndLivesManager.instance.currentShields == 0 && pl.gameData.StrongShieldItem >= 1)
        {
            ScoreAndLivesManager.instance.currentShields += strongShieldIncrease;

            pl.gameData.StrongShieldItem -= 1;

            SceneUI.instance.ssQuantityText.text = pl.gameData.StrongShieldItem.ToString();

            ScoreAndLivesManager.instance.ShieldTracker();
        }
        else
        {
            //TODO: Add popup that tells the player that they have too many shields
        }
    }

    public void UseLudacrisLightning()
    {
            if (QuestionManager.instance.wrongAnswer1.interactable == true && QuestionManager.instance.wrongAnswer2.interactable == true && pl.gameData.LudacrisLightningItem >= 1)
            {
                Debug.Log(QuestionManager.instance);
                QuestionManager.instance.wrongAnswer1.interactable = false;
                QuestionManager.instance.wrongAnswerPanel1.SetActive(true);
                QuestionManager.instance.wrongAnswer2.interactable = false;
                QuestionManager.instance.wrongAnswerPanel2.SetActive(true);

                pl.gameData.LudacrisLightningItem -= 1;

                SceneUI.instance.llQuantityText.text = pl.gameData.LudacrisLightningItem.ToString();
            }
    }

    public void UseSaucySkip()
    {
        if (!QuestionManager.instance.continueButton.activeSelf && pl.gameData.SaucySkipItem >= 1)
        {
            QuestionManager.instance.TurnButtonsOff();
            QuestionManager.instance.continueButton.SetActive(true);

            pl.gameData.SaucySkipItem -= 1;

            SceneUI.instance.sskipQuantityText.text = pl.gameData.SaucySkipItem.ToString();
        }
    }
} 
