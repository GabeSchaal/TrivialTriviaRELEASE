using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameData {
    public static GameData currentGame;

    //Currency Totals
    [SerializeField]
    private float tokenTotal;
    [SerializeField]
    private int gemTotal = 100;

    //Item Totals
    [SerializeField]
    private int healthyHeartItem;
    [SerializeField]
    private int strongShieldItem;
    [SerializeField]
    private int ludacrisLightningItem;
    [SerializeField]
    private int saucySkipItem;

	//Timer
	[SerializeField]
	private int timer;
	[SerializeField]
	private bool firstTimeLaunch = true;

    #region Currency Totals
    public float TokenTotal
    {
        get
        {
            return tokenTotal;
        }

        set
        {
            tokenTotal = value;
        }
    }

    public int GemTotal
    {
        get
        {
            return gemTotal;
        }

        set
        {
            gemTotal = value;
        }
    }
    #endregion

    #region Item Totals
    public int HealthyHeartItem
    {
        get
        {
            return healthyHeartItem;
        }

        set
        {
            healthyHeartItem = value;
        }
    }

    public int StrongShieldItem
    {
        get
        {
            return strongShieldItem;
        }

        set
        {
            strongShieldItem = value;
        }
    }

    public int LudacrisLightningItem
    {
        get
        {
            return ludacrisLightningItem;
        }

        set
        {
            ludacrisLightningItem = value;
        }
    }

    public int SaucySkipItem
    {
        get
        {
            return saucySkipItem;
        }

        set
        {
            saucySkipItem = value;
        }
    }

	public int Timer
	{
		get 
		{
			return timer;
		}
		set 
		{
			timer = value;
		}
	}

	public bool FirstTimeLauch
	{
		get
		{
			return firstTimeLaunch;
		}

		set
		{
			firstTimeLaunch = value;
		}
	}

    #endregion
}
