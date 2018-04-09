using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreAndLivesManager : MonoBehaviour
{

    public static ScoreAndLivesManager instance;

    QuestionManager questionManager;
    SceneUI sceneUI;

    public int correctAnswerPoints = 100;

    public GameObject GameHasEnded;

    [Header("TextMeshPro Information")]
    public GameObject scoreGO;
    private TextMeshProUGUI score;

    //public GameObject endTokenTotalGO;
    //[HideInInspector]
    //public TextMeshProUGUI endTokenTotal;

    [Header("Player Information")]
    public int currentLives = 3;
    public int currentShields = 0;
    public float scoreTotal = 0;
    public GameObject scoreIncreaseAnim;

    public GameObject livesLeft1;
    public GameObject livesLeft2;
    public GameObject livesLeft3;
    public GameObject livesLeft4;
    public GameObject livesLeft5;

    public GameObject shieldsLeft1;
    public GameObject shieldsLeft2;
    public GameObject shieldsLeft3;
    public GameObject shieldsLeft4;

    public void Awake()
    {
        instance = this;

        //questionManager = new QuestionManager();
        sceneUI = gameObject.GetComponent<SceneUI>();

        LifeTracker();
        ShieldTracker();

        score = scoreGO.GetComponent<TextMeshProUGUI>();
    }

    public void Start()
    {
        score.text = scoreTotal.ToString();
    }

    public void CorrectAnswer()
    {
        scoreTotal += correctAnswerPoints;

        scoreIncreaseAnim.SetActive(true);

        score.text = scoreTotal.ToString();
        sceneUI.egScoreText.text = scoreTotal.ToString();

        GameManager.instance.correctAnswer.Play();
        SceneUI.instance.qcc++;
    }

    public void WrongAnswer()
    {
        if (currentShields > 0)
        {
            currentShields -= 1;
        }
        else if (currentLives > 0)
        {
            currentLives -= 1;
            if (currentLives == 0)
            {
                LifeTracker();
                ShieldTracker();

                sceneUI.GameHasEnded();
            }
        }

        LifeTracker();
        ShieldTracker();
    }

    public void LifeTracker()
    {
        switch (currentLives)
        {
            case 5:
                livesLeft5.SetActive(true);
                livesLeft4.SetActive(true);
                livesLeft3.SetActive(true);
                livesLeft2.SetActive(true);
                livesLeft1.SetActive(true);
                break;
            case 4:
                livesLeft5.SetActive(false);
                livesLeft4.SetActive(true);
                livesLeft3.SetActive(true);
                livesLeft2.SetActive(true);
                livesLeft1.SetActive(true);
                break;
            case 3:
                livesLeft5.SetActive(false);
                livesLeft4.SetActive(false);
                livesLeft3.SetActive(true);
                livesLeft2.SetActive(true);
                livesLeft1.SetActive(true);
                break;
            case 2:
                livesLeft5.SetActive(false);
                livesLeft4.SetActive(false);
                livesLeft3.SetActive(false);
                livesLeft2.SetActive(true);
                livesLeft1.SetActive(true);
                break;
            case 1:
                livesLeft5.SetActive(false);
                livesLeft4.SetActive(false);
                livesLeft3.SetActive(false);
                livesLeft2.SetActive(false);
                livesLeft1.SetActive(true);
                break;
            case 0:
                livesLeft5.SetActive(false);
                livesLeft4.SetActive(false);
                livesLeft3.SetActive(false);
                livesLeft2.SetActive(false);
                livesLeft1.SetActive(false);
                break;
        }
    }

    public void ShieldTracker()
    {
        switch (currentShields)
        {
            case 4:
                shieldsLeft4.SetActive(true);
                shieldsLeft3.SetActive(true);
                shieldsLeft2.SetActive(true);
                shieldsLeft1.SetActive(true);
                break;
            case 3:
                shieldsLeft4.SetActive(false);
                shieldsLeft3.SetActive(true);
                shieldsLeft2.SetActive(true);
                shieldsLeft1.SetActive(true);
                break;
            case 2:
                shieldsLeft4.SetActive(false);
                shieldsLeft3.SetActive(false);
                shieldsLeft2.SetActive(true);
                shieldsLeft1.SetActive(true);
                break;
            case 1:
                shieldsLeft4.SetActive(false);
                shieldsLeft3.SetActive(false);
                shieldsLeft2.SetActive(false);
                shieldsLeft1.SetActive(true);
                break;
            case 0:
                shieldsLeft4.SetActive(false);
                shieldsLeft3.SetActive(false);
                shieldsLeft2.SetActive(false);
                shieldsLeft1.SetActive(false);
                break;
        }
    }
}
