using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager instance;

    SceneUI sceneUI;

    ScoreAndLivesManager scoreScript;
    RandomizeButtons randomButtons;

    public List<Question> totalQuestions;
    List<Question> unAnsweredQuestions = new List<Question>();

    public Sprite imageSpriteWrongAnswer;

    [Header("Buttons")]
    public Button correctAnswer;
    public Button wrongAnswer1;
    public Button wrongAnswer2;
    public Button wrongAnswer3;

    [Header("Answer Panels")]
    public GameObject continueButton;
    public GameObject correctAnswerPanel;
    public GameObject wrongAnswerPanel1;
    public GameObject wrongAnswerPanel2;
    public GameObject wrongAnswerPanel3;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreScript = gameObject.GetComponent<ScoreAndLivesManager>();
        randomButtons = gameObject.GetComponent<RandomizeButtons>();

        sceneUI = gameObject.GetComponent<SceneUI>();
        
        foreach (Question question in totalQuestions)
        {
            unAnsweredQuestions.Add(question);
        }
        LoadQuestion();
    }

    #region Calls/Loads New Questions
    public void LoadQuestion()
    {
        int x = unAnsweredQuestions.Count;
        int y = Random.Range(0, x);

        if (x == 0)
        {
            sceneUI.GameHasEnded();
        }
        else if (x > 0)
        {
            NextQuestion(unAnsweredQuestions[y]);
            unAnsweredQuestions.RemoveAt(y);
        }

        UIManager.instance.PlayGenericSound();

        TurnButtonsBackOn();
    }

    void NextQuestion(Question nextQuestion)
    {
        sceneUI.answerAText.text = nextQuestion.answer;
        sceneUI.questionText.text = nextQuestion.text;

        sceneUI.answerBText.text = nextQuestion.wrongAnswer1;
        sceneUI.answerCText.text = nextQuestion.wrongAnswer2;
        sceneUI.answerDText.text = nextQuestion.wrongAnswer3;

        //SceneUI.instance.questionsCompletedCount++;

        randomButtons.MoveButtons();
    }
    #endregion

    #region Correct or Wrong Answer
    public void CorrectAnswer()
    {
        correctAnswerPanel.SetActive(true);
        continueButton.SetActive(true);

        correctAnswer.interactable = false;
        TurnButtonsOff();
     
        scoreScript.CorrectAnswer();
    }

    public void WrongAnswer(GameObject wrongAnswerButton)
    {
        GameObject wrongAnswerPanel = wrongAnswerButton.transform.GetChild(0).gameObject;



        wrongAnswerPanel.SetActive(true);
        Button answerButton = wrongAnswerButton.GetComponent<Button>();
        answerButton.interactable = false;

        //if (GameObject.FindGameObjectsWithTag("answerB)

        scoreScript.WrongAnswer();
    }
    #endregion

    #region Turns Buttons On/Off
    public void TurnButtonsBackOn()
    {
        correctAnswer.interactable = true;
        correctAnswerPanel.SetActive(false);

        wrongAnswer1.interactable = true;
        wrongAnswerPanel1.SetActive(false);

        wrongAnswer2.interactable = true;
        wrongAnswerPanel2.SetActive(false);

        wrongAnswer3.interactable = true;
        wrongAnswerPanel3.SetActive(false);

        continueButton.SetActive(false);
        scoreScript.scoreIncreaseAnim.SetActive(false);
    }

    public void TurnButtonsOff()
    {
        correctAnswer.interactable = false;
        wrongAnswer1.interactable = false;
        wrongAnswer2.interactable = false;
        wrongAnswer3.interactable = false;
    }
    #endregion
      
}