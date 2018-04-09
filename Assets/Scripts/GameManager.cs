using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //The Game Manager handles Scene Management, Save, Music/Sound controls and Quit Application
    public static GameManager instance;

    public AudioSource musicSource;

    public AudioSource genericButton;
    public AudioSource correctAnswer;
    public AudioSource wrongAnswer;
    public AudioSource buyItem;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);
    }

    #region Music Contorls
    public void TurnMusicOff()
    {
        musicSource.Pause();
    }

    public void TurnMusicOn()
    {
        musicSource.Play();
    }

    public void TurnSoundOff()
    {
        genericButton.volume = 0.0f;
        correctAnswer.volume = 0.0f;
        wrongAnswer.volume = 0.0f;
        buyItem.volume = 0.0f;
    }

    public void TurnSoundOn()
    {
        genericButton.volume = 1.0f;
        correctAnswer.volume = 1.0f;
        wrongAnswer.volume = 1.0f;
        buyItem.volume = 1.0f;
    }
    #endregion

   

    public void QuitApplication()
    {
        SaveGame();
        Application.Quit();
    }

    void SaveGame()
    {
        SaveLoad.Save();
    }
   
}
