using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoader : MonoBehaviour {

    //The Preloader handles the GameData, initial LoadData, and Starting the Music/Sounds
    public static PreLoader instance;
    public GameData gameData;

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

        SceneManager.LoadScene("Main");
    }

    void Start()
    {
        SaveLoad.Load();
        InvokeRepeating("SaveGame", 2f, 2f);
    }

    #region Music Contorls
    public void TurnMusicOff()
    {
        AudioListener.pause = true;
    }

    public void TurnMusicOn()
    {
        AudioListener.pause = false;
    }
    #endregion

    void SaveGame()
    {
        SaveLoad.Save();
    }

    public void QuitApplication()
    {
        SaveGame();
        Application.Quit();
    }
}