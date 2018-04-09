using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneUI : MonoBehaviour {

    PreLoader pl;
    
    public static SceneUI instance;

    public int qcc = 0;

    public int bonusTokens;
    public int btReward = 1;
    public int randomTokenReward = 0;

    public int bonusGems;
    public int bgReward = 1;
    public int randomGemReward = 0;

    public GameObject soundIsOffPanel;
    public GameObject musicIsOffPanel;
    public GameObject itemIconClose;

    #region TextMeshPro
    [Header("TextMeshPro Information")]
    public GameObject questionTextGO;
    [HideInInspector]
    public TextMeshProUGUI questionText;

    public GameObject answerAGO;
    [HideInInspector]
    public TextMeshProUGUI answerAText;

    public GameObject answerBGO;
    [HideInInspector]
    public TextMeshProUGUI answerBText;

    public GameObject answerCGO;
    [HideInInspector]
    public TextMeshProUGUI answerCText;

    public GameObject answerDGO;
    [HideInInspector]
    public TextMeshProUGUI answerDText;

    [Header("Item Text Info")]
    public GameObject hhQuantityGO;
    [HideInInspector]
    public TextMeshProUGUI hhQuantityText;

    public GameObject ssQuantityGO;
    [HideInInspector]
    public TextMeshProUGUI ssQuantityText;

    public GameObject llQuantityGO;
    [HideInInspector]
    public TextMeshProUGUI llQuantityText;

    public GameObject sskipQuantityGO;
    [HideInInspector]
    public TextMeshProUGUI sskipQuantityText;

    [Header("End Screen Text Info")]
    public GameObject egScoreGO;
    [HideInInspector]
    public TextMeshProUGUI egScoreText;

    public GameObject egTokensGO;
    [HideInInspector]
    public TextMeshProUGUI egTokensText;

    public GameObject egGemsGO;
    [HideInInspector]
    public TextMeshProUGUI egGemsText;
    #endregion

    [Header("Buttons")]
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Button buttonD;

    public GameObject quitGamePanel;
    public GameObject settingsInfoPanel;
    public GameObject settingsIconClose;
    public GameObject settingsIconOpen;
    public GameObject gameHasEndedPanel;

    public List<GameObject> RandomRewardsGO;

    public int bonusRewardAd;

    void Awake()
    {
        pl = PreLoader.instance;

        instance = this;

        questionText = questionTextGO.GetComponent<TextMeshProUGUI>();

        answerAText = answerAGO.GetComponent<TextMeshProUGUI>();
        answerBText = answerBGO.GetComponent<TextMeshProUGUI>();
        answerCText = answerCGO.GetComponent<TextMeshProUGUI>();
        answerDText = answerDGO.GetComponent<TextMeshProUGUI>();

        hhQuantityText = hhQuantityGO.GetComponent<TextMeshProUGUI>();
        ssQuantityText = ssQuantityGO.GetComponent<TextMeshProUGUI>();
        llQuantityText = llQuantityGO.GetComponent<TextMeshProUGUI>();
        sskipQuantityText = sskipQuantityGO.GetComponent<TextMeshProUGUI>();

        egScoreText = egScoreGO.GetComponent<TextMeshProUGUI>();
        egTokensText = egTokensGO.GetComponent<TextMeshProUGUI>();
        egGemsText = egGemsGO.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        hhQuantityText.text = pl.gameData.HealthyHeartItem.ToString();
        ssQuantityText.text = pl.gameData.StrongShieldItem.ToString();
        llQuantityText.text = pl.gameData.LudacrisLightningItem.ToString();
        sskipQuantityText.text = pl.gameData.SaucySkipItem.ToString();
    }

    #region Settings Panel Control
    public void OpenSettingsInfoPanel()
    {
        settingsInfoPanel.SetActive(true);

        settingsIconClose.SetActive(true);
        settingsIconOpen.SetActive(false);

        UIManager.instance.PlayGenericSound();
    }

    public void CloseSettingsInfoPanel()
    {
        settingsInfoPanel.SetActive(false);

        settingsIconClose.SetActive(false);
        settingsIconOpen.SetActive(true);

        UIManager.instance.PlayGenericSound();
    }

    public void OpenQuitGamePanel()
    {
        quitGamePanel.SetActive(true);

        UIManager.instance.PlayGenericSound();
    }

    public void CloseQuitGamePanel()
    {
        quitGamePanel.SetActive(false);

        UIManager.instance.PlayGenericSound();
    }

    public void QuitGame()
    {
        UIManager.instance.PlayGenericSound();

        SceneManager.LoadScene("Main");
    }
    #endregion

    #region Items Panel Control
    public void ToggleItemsPanel(GameObject itemPanel)
    {
        itemPanel.SetActive(!itemPanel.activeSelf);
        itemIconClose.SetActive(!itemIconClose.activeSelf);

        UIManager.instance.PlayGenericSound();
    }
    #endregion

    #region Sound Control FROM Game Manager
    public void TurnMusicOff()
    {
        GameManager.instance.TurnMusicOff();
        musicIsOffPanel.SetActive(true);
    }

    public void TurnMusicOn()
    {
        GameManager.instance.TurnMusicOn();
        musicIsOffPanel.SetActive(false);
    }

    public void TurnSoundOff()
    {
        GameManager.instance.TurnSoundOff();
        soundIsOffPanel.SetActive(true);
    }

    public void TurnSoundOn()
    {
        GameManager.instance.TurnSoundOn();
        soundIsOffPanel.SetActive(false);
    }
    #endregion

    #region End Game Screen Controls
    public void GameHasEnded()
    {
        RewardCalculations();
        gameHasEndedPanel.SetActive(true);

        CurrencyReward();
    }

    public void CurrencyReward()
    {
        pl.gameData.TokenTotal += ((ScoreAndLivesManager.instance.scoreTotal * .1f) + bonusTokens + randomTokenReward);
        pl.gameData.GemTotal += bonusGems + randomGemReward;

        egTokensText.text = ((ScoreAndLivesManager.instance.scoreTotal * .1f) + bonusTokens + randomTokenReward).ToString();
        egGemsText.text = (bonusGems + randomGemReward).ToString();
    }

    public void RewardCalculations()
    {
        bonusTokens = btReward * qcc;
        bonusGems = bgReward * qcc;

        if(qcc >= 20)
        {
            int randomNumberReward = Random.Range(0, 5);

            switch(randomNumberReward)
            {
                case 0:
                    randomGemReward += 10;
                    RandomRewardsGO[0].SetActive(true);

                    //Lets RandomRewardAd know which item to boost
                    bonusRewardAd = 0;
                    
                    break;
                case 1:
                    pl.gameData.HealthyHeartItem += 1;
                    RandomRewardsGO[1].SetActive(true);

                    //Lets RandomRewardAd know which item to boost
                    bonusRewardAd = 1;
                    break;
                case 2:
                    pl.gameData.StrongShieldItem += 1;
                    RandomRewardsGO[2].SetActive(true);

                    //Lets RandomRewardAd know which item to boost
                    bonusRewardAd = 2;
                    break;
                case 3:
                    randomTokenReward += 25;
                    RandomRewardsGO[3].SetActive(true);

                    //Lets RandomRewardAd know which item to boost
                    bonusRewardAd = 3;
                    break;
                case 4:
                    pl.gameData.LudacrisLightningItem += 1;
                    RandomRewardsGO[4].SetActive(true);

                    //Lets RandomRewardAd know which item to boost
                    bonusRewardAd = 4;
                    break;
                case 5:
                    pl.gameData.SaucySkipItem += 1;
                    RandomRewardsGO[5].SetActive(true);

                    //Lets RandomRewardAd know which item to boost
                    bonusRewardAd = 5;
                    break;
            }
        }
    }

    //List of adRewards

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main");
    }
    #endregion

    #region Category Selection
    public void CategorySelection(GameObject canvasGroup)
    {
        canvasGroup.SetActive(true);
        UIManager.instance.PlayGenericSound();
    }
    #endregion
}
