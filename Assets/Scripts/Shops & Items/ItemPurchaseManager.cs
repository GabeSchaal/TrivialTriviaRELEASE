using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPurchaseManager : MonoBehaviour {

    PreLoader pl;
    UIManager ui;

	public static ItemPurchaseManager instance;

    //Holiday Boost
    int holidayBoost = 0;

    //Item TOKEN Purchase Amounts
    int healthyHeartPAT = 1;
    int strongShieldPAT = 1;
    int ludacrisLightningPAT = 1;
    int saucySkipPAT = 1;

    //Item GEM Purchase Amounts
    int healthyHeartPAG = 3;
    int strongShieldPAG = 3;
    int ludacrisLightningPAG = 3;
    int saucySkipPAG = 3;

    //Item Prices
    int healthyHeartTOKENCost = 300;
    int healthyHeartGEMCost = 75;

    int strongShieldTOKENCost = 600;
    int strongShieldGEMCost = 150;

    int ludacrisLightningTOKENCost = 300;
    int ludacrisLightningGEMCost = 75;

    int saucySkipTOKENCost = 500;
    int saucySkipGEMCost = 125;

	public Button randomItemButton;

    public GameObject rewardPanel;

    public GameObject heart;
    public GameObject shield;
    public GameObject lightning;
    public GameObject skip;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pl = PreLoader.instance;
        ui = UIManager.instance;

		if (pl.gameData.FirstTimeLauch) {
			pl.gameData.Timer = 300;
			pl.gameData.FirstTimeLauch = false;
			randomItemButton.interactable = false;

			StartCoroutine (RandomItemCD ());
		} else if (pl.gameData.FirstTimeLauch == false && pl.gameData.Timer > 0) {
			randomItemButton.interactable = false;
			StartCoroutine (RandomItemCD ());
		} else if (pl.gameData.FirstTimeLauch == false && pl.gameData.Timer <= 0) {
			randomItemButton.interactable = true;
		} else
        {
            pl.gameData.Timer = 300;
            StartCoroutine(RandomItemCD());
        }
			
    }

    #region Randomized Item - WATCH AD

	#region Timers for Bonus Events
	//River Timer
	public IEnumerator RandomItemCD()
	{
		while (pl.gameData.Timer >= 0)
		{
			//Converts the int to a string to be displayed in a timer format
			string minutesAndSeconds = string.Format("{0:#0} : {1:00}", Mathf.Floor(pl.gameData.Timer / 60), Mathf.Floor(pl.gameData.Timer % 60));

			ui.timerText.text = minutesAndSeconds;   

			pl.gameData.Timer -= 1;
			yield return new WaitForSeconds(1f);
		}
		//Stops the timer so it will not keep ticking down
		StopCoroutine(RandomItemCD());

		//Makes both the small side UI button and the button at the river clickable
		randomItemButton.interactable = true;
	}
	#endregion

	public void RandomItem()
	{
		if(pl.gameData.Timer <= 0)
		{
			AdManager.instance.WatchAdForRandomItem();
			pl.gameData.Timer = 300;
			ui.timerText.text = pl.gameData.Timer.ToString();

			StartCoroutine (RandomItemCD ());
			randomItemButton.interactable = false;

		}
	}

    #endregion

    #region Item PURCHASE
    //Healthy Heart
    public void BuyHealthyHeartTOKENS()
    {
        if(pl.gameData.TokenTotal >= healthyHeartTOKENCost)
        {
            pl.gameData.TokenTotal -= healthyHeartTOKENCost;
            pl.gameData.HealthyHeartItem += healthyHeartPAT + holidayBoost;

            ui.hhQuantityText.text = pl.gameData.HealthyHeartItem.ToString();
            ui.currentTokensText.text = pl.gameData.TokenTotal.ToString();

            GameManager.instance.buyItem.Play();
        }
    }

    public void BuyHealthyHeartGEMS()
    {
        if(pl.gameData.GemTotal >= healthyHeartGEMCost)
        {
            pl.gameData.GemTotal -= healthyHeartGEMCost;
            pl.gameData.HealthyHeartItem += healthyHeartPAG + holidayBoost;

            Debug.Log(ui);
            ui.hhQuantityText.text = pl.gameData.HealthyHeartItem.ToString();
            ui.currentGemsText.text = pl.gameData.GemTotal.ToString();

            GameManager.instance.buyItem.Play();
        }
    }

    //Strong Shield
    public void BuyStrongShieldTOKENS()
    {
        if (pl.gameData.TokenTotal >= strongShieldTOKENCost)
        {
            pl.gameData.TokenTotal -= strongShieldTOKENCost;
            pl.gameData.StrongShieldItem += strongShieldPAT + holidayBoost;

            ui.ssQuantityText.text = pl.gameData.StrongShieldItem.ToString();
            ui.currentTokensText.text = pl.gameData.TokenTotal.ToString();

            GameManager.instance.buyItem.Play();
        }       
    }

    public void BuyStrongShieldGEMS()
    {
        if (pl.gameData.GemTotal >= strongShieldGEMCost)
        {
            pl.gameData.GemTotal -= strongShieldGEMCost;
            pl.gameData.StrongShieldItem += strongShieldPAG + holidayBoost;

            ui.ssQuantityText.text = pl.gameData.StrongShieldItem.ToString();
            ui.currentGemsText.text = pl.gameData.GemTotal.ToString();

            GameManager.instance.buyItem.Play();
        }
    }

    //Ludacris Lightning
    public void BuyLudacrisLightningTOKENS()
    {
        if (pl.gameData.TokenTotal >= ludacrisLightningTOKENCost)
        {
            pl.gameData.TokenTotal -= ludacrisLightningTOKENCost;
            pl.gameData.LudacrisLightningItem += ludacrisLightningPAT + holidayBoost;

            ui.llQuantityText.text = pl.gameData.LudacrisLightningItem.ToString();
            ui.currentTokensText.text = pl.gameData.TokenTotal.ToString();

            GameManager.instance.buyItem.Play();
        }
    }

    public void BuyLudacrisLightningGEMS()
    {
        if (pl.gameData.GemTotal >= ludacrisLightningGEMCost)
        {
            pl.gameData.GemTotal -= ludacrisLightningGEMCost;
            pl.gameData.LudacrisLightningItem += ludacrisLightningPAG + holidayBoost;

            ui.llQuantityText.text = pl.gameData.LudacrisLightningItem.ToString();
            ui.currentGemsText.text = pl.gameData.GemTotal.ToString();

            GameManager.instance.buyItem.Play();
        }     
    }

    //Saucy Skip
    public void BuySaucySkipTOKENS()
    {
        if (pl.gameData.TokenTotal >= saucySkipTOKENCost)
        {
            pl.gameData.TokenTotal -= saucySkipTOKENCost;
            pl.gameData.SaucySkipItem += saucySkipPAT + holidayBoost;

            ui.sskipQuantityText.text = pl.gameData.SaucySkipItem.ToString();
            ui.currentTokensText.text = pl.gameData.TokenTotal.ToString();

            GameManager.instance.buyItem.Play();
        }        
    }

    public void BuySaucySkipGEMS()
    {
        if (pl.gameData.GemTotal >= saucySkipGEMCost)
        {
            pl.gameData.GemTotal -= saucySkipGEMCost;
            pl.gameData.SaucySkipItem += saucySkipPAG + holidayBoost;

            ui.sskipQuantityText.text = pl.gameData.SaucySkipItem.ToString();
            ui.currentGemsText.text = pl.gameData.GemTotal.ToString();

            GameManager.instance.buyItem.Play();
        }  
    }
    #endregion

}
