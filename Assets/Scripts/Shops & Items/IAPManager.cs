using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPManager : MonoBehaviour {

	public void buy150gems()
    {
        PreLoader.instance.gameData.GemTotal += 150;
        UIManager.instance.currentGemsText.text = PreLoader.instance.gameData.GemTotal.ToString();
    }

    public void buy225gems()
    {
        PreLoader.instance.gameData.GemTotal += 225;
        UIManager.instance.currentGemsText.text = PreLoader.instance.gameData.GemTotal.ToString();
    }

    public void buy450gems()
    {
        PreLoader.instance.gameData.GemTotal += 450;
        UIManager.instance.currentGemsText.text = PreLoader.instance.gameData.GemTotal.ToString();
    }

    public void buy1500gems()
    {
        PreLoader.instance.gameData.GemTotal += 1500;
        UIManager.instance.currentGemsText.text = PreLoader.instance.gameData.GemTotal.ToString();
    }

    public void buy3000gems()
    {
        PreLoader.instance.gameData.GemTotal += 3000;
        UIManager.instance.currentGemsText.text = PreLoader.instance.gameData.GemTotal.ToString();
    }

    public void buy7500gems()
    {
        PreLoader.instance.gameData.GemTotal += 7500;
        UIManager.instance.currentGemsText.text = PreLoader.instance.gameData.GemTotal.ToString();
    }

    public void buy15000gems()
    {
        PreLoader.instance.gameData.GemTotal += 15000;
        UIManager.instance.currentGemsText.text = PreLoader.instance.gameData.GemTotal.ToString();
    }
}
