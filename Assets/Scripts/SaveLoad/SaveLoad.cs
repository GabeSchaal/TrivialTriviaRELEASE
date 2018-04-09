using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad {

    public static GameData savedGames = new GameData();

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGame.gd");
        GameData data = new GameData();
        GameData currentData = PreLoader.instance.gameData;

        #region Currency Totals
        data.TokenTotal = currentData.TokenTotal;
        data.GemTotal = currentData.GemTotal;
        #endregion

        #region Item Totals
        data.HealthyHeartItem = currentData.HealthyHeartItem;
        data.StrongShieldItem = currentData.StrongShieldItem;
        data.LudacrisLightningItem = currentData.LudacrisLightningItem;
        data.SaucySkipItem = currentData.SaucySkipItem;
        #endregion

		#region Timers
		data.Timer = currentData.Timer;
		data.FirstTimeLauch = currentData.FirstTimeLauch;
		#endregion

        bf.Serialize(file, data);
        file.Close();
    }

    public static void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/savedGame.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGame.gd", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            GameData loadData = PreLoader.instance.gameData;

            #region Currency Totals
            loadData.TokenTotal = data.TokenTotal;
            loadData.GemTotal = data.GemTotal;
            #endregion

            #region Item Totals
            loadData.HealthyHeartItem = data.HealthyHeartItem;
            loadData.StrongShieldItem = data.StrongShieldItem;
            loadData.LudacrisLightningItem = data.LudacrisLightningItem;
            loadData.SaucySkipItem = data.SaucySkipItem;
            #endregion

			#region Timer
			loadData.Timer = data.Timer;
			loadData.FirstTimeLauch = data.FirstTimeLauch;
			#endregion

            file.Close();
        }
    }
}
