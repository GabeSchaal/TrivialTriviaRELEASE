using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{

    ItemPurchaseManager ipm;
    PreLoader pl;
    public static AdManager instance;

    private int gemsRewarded = 15;

    private int adType;

    private void Start()
    {
        //Advertisement.Initialize("1644012");
        //Advertisement.Initialize("1644013");

        instance = this;

        ipm = ItemPurchaseManager.instance;
        pl = PreLoader.instance;
    }

    public void WatchAdForGems()
    {
        adType = 0;
        Debug.Log(adType);
        ShowOptions so = new ShowOptions();
        so.resultCallback = AdReward;

        GameManager.instance.TurnMusicOff();

        Advertisement.Show("rewardedVideo", so);
    }

    public void WatchAdForRandomItem()
    {
        adType = 1;

        ShowOptions so = new ShowOptions();
        so.resultCallback = AdReward;

        GameManager.instance.TurnMusicOff();

        Advertisement.Show("rewardedVideo", so);
    }

    public void WatchAdForBonusItem()
    {
        adType = 2;

        ShowOptions so = new ShowOptions();
        so.resultCallback = AdReward;

        GameManager.instance.TurnMusicOff();

        Advertisement.Show("rewardedVideo", so);
    }

    private void AdReward(ShowResult obj)
    {
        if (obj == ShowResult.Finished)
        {
            switch (adType)
            {
                case 0:
                    GameManager.instance.TurnMusicOn();

                    PreLoader.instance.gameData.GemTotal += gemsRewarded;
                    UIManager.instance.currentGemsText.text = PreLoader.instance.gameData.GemTotal.ToString();
                    break;
                case 1:
                    GameManager.instance.TurnMusicOn();

                    int itemReward = UnityEngine.Random.Range(0, 3);

                    switch (itemReward)
                    {
                        //TODO: Call animation letting player know which item they got

                        //Healthy Heart
                        case 0:
                            PreLoader.instance.gameData.HealthyHeartItem += 1;
                            UIManager.instance.hhQuantityText.text = PreLoader.instance.gameData.HealthyHeartItem.ToString();

                            ipm.rewardPanel.SetActive(true);
                            ipm.heart.SetActive(true);
                            break;
                        //Strong Shield
                        case 1:
                            PreLoader.instance.gameData.StrongShieldItem += 1;
                            UIManager.instance.ssQuantityText.text = PreLoader.instance.gameData.StrongShieldItem.ToString();

                            ipm.rewardPanel.SetActive(true);
                            ipm.shield.SetActive(true);
                            break;
                        //Ludacris Lightning
                        case 2:
                            PreLoader.instance.gameData.LudacrisLightningItem += 1;
                            UIManager.instance.llQuantityText.text = PreLoader.instance.gameData.LudacrisLightningItem.ToString();

                            ipm.rewardPanel.SetActive(true);
                            ipm.lightning.SetActive(true);
                            break;
                        //Saucy Skip
                        case 3:
                            PreLoader.instance.gameData.SaucySkipItem += 1;
                            UIManager.instance.sskipQuantityText.text = PreLoader.instance.gameData.SaucySkipItem.ToString();

                            ipm.rewardPanel.SetActive(true);
                            ipm.skip.SetActive(true);
                            break;
                    }
                    break;
                case 2:
                    GameManager.instance.TurnMusicOn();

                    switch (SceneUI.instance.bonusRewardAd)
                    {
                        case 0:
                            pl.gameData.GemTotal += 10;
                            break;
                        case 1:
                            pl.gameData.HealthyHeartItem += 1;
                            break;
                        case 2:
                            pl.gameData.StrongShieldItem += 1;
                            break;
                        case 3:
                            pl.gameData.TokenTotal += 25;
                            break;
                        case 4:
                            pl.gameData.LudacrisLightningItem += 1;
                            break;
                        case 5:
                            pl.gameData.SaucySkipItem += 1;
                            break;
                    }
                    break;
            }



        }
    }

}
