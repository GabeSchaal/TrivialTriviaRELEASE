using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    PreLoader pl;
    ItemPurchaseManager ipm;
    public static UIManager instance;

    [Header("Title Screen UI Elements")]
    public GameObject titlePanel;
    public GameObject categoryPanel;
    public GameObject shopPanel;
    public GameObject gemsPanel;

    [Header("Shop Resets")]
    public GameObject ItemScrollView;
    public GameObject GemScrollView;

    [Header("Settings Panel")]
    public GameObject settingsPanel;

    public GameObject soundIsOnPanel;
    public GameObject soundIsOffPanel;

    public GameObject musicIsOnPanel;
    public GameObject musicIsOffPanel;
    public string isCorrectAnswer;

    [Header("TextMeshPro Information")]
    //Currency
    public GameObject currentTokensGO;
    [HideInInspector]
    public TextMeshProUGUI currentTokensText;

    public GameObject currentGemsGO;
    [HideInInspector]
    public TextMeshProUGUI currentGemsText;

    //Items
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

	public GameObject timerGO;
	[HideInInspector]
	public TextMeshProUGUI timerText;

    void Awake()
    {
        instance = this;

        currentTokensText = currentTokensGO.GetComponent<TextMeshProUGUI>();
        currentGemsText = currentGemsGO.GetComponent<TextMeshProUGUI>();

        hhQuantityText = hhQuantityGO.GetComponent<TextMeshProUGUI>();
        ssQuantityText = ssQuantityGO.GetComponent<TextMeshProUGUI>();
        llQuantityText = llQuantityGO.GetComponent<TextMeshProUGUI>();
        sskipQuantityText = sskipQuantityGO.GetComponent<TextMeshProUGUI>();

		timerText = timerGO.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        pl = PreLoader.instance;
        ipm = ItemPurchaseManager.instance;
        //Currency
        currentTokensText.text = pl.gameData.TokenTotal.ToString();
        currentGemsText.text = pl.gameData.GemTotal.ToString();

        //Items
        hhQuantityText.text = pl.gameData.HealthyHeartItem.ToString();
        ssQuantityText.text = pl.gameData.StrongShieldItem.ToString();
        llQuantityText.text = pl.gameData.LudacrisLightningItem.ToString();
        sskipQuantityText.text = pl.gameData.SaucySkipItem.ToString();
    }

    #region SoundControl
    public void TurnSoundOff()
    {
        soundIsOffPanel.SetActive(true);
        soundIsOnPanel.SetActive(false);

        GameManager.instance.TurnSoundOff();
    }

    public void TurnSoundOn()
    {
        soundIsOffPanel.SetActive(false);
        soundIsOnPanel.SetActive(true);

        GameManager.instance.TurnSoundOn();
    }

    public void TurnMusicOff()
    {
        musicIsOffPanel.SetActive(true);
        musicIsOnPanel.SetActive(false);

        GameManager.instance.TurnMusicOff();
    }

    public void TurnMusicOn()
    {
        musicIsOffPanel.SetActive(false);
        musicIsOnPanel.SetActive(true);

        GameManager.instance.TurnMusicOn();
    }
    #endregion

    #region Title Panel
    public void CloseOpenPanel()
    {
        titlePanel.SetActive(true);
        categoryPanel.SetActive(false);
        shopPanel.SetActive(false);
        settingsPanel.SetActive(false);
        PlayGenericSound();
    }

    public void Close(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        Debug.Log(ipm);

        ipm.heart.SetActive(false);
        ipm.shield.SetActive(false);
        ipm.lightning.SetActive(false);
        ipm.skip.SetActive(false);
    }

	public void CategorySelectionPanel()
    {
        SceneManager.LoadScene("GameArea");
        PlayGenericSound();
    }

    public void ShopPanel()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
        ItemScrollView.transform.localPosition = new Vector3(0f, 0f, 0f);

        titlePanel.SetActive(!titlePanel.activeSelf);
        PlayGenericSound();
    }

    public void ToggleGemPanel()
    {
        gemsPanel.SetActive(!gemsPanel.activeSelf);
        Debug.Log(GemScrollView);
        GemScrollView.transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    public void SettingsPanel()
    {
        titlePanel.SetActive(false);
        settingsPanel.SetActive(true);
        PlayGenericSound();
    }

    public void PlayGenericSound()
    {
        GameManager.instance.genericButton.Play();
    }
    #endregion

    public void ApplicationQuit()
    {
        Application.Quit();
    }

}
