using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class SaveData
{
    public int currentLevel = 1;
    public int currentGemsCount = 0;
    public Skin[] skinsProps = new Skin[0]; 
    
    public SaveData()
    {
        currentLevel = 1;
        currentGemsCount = 0;
        skinsProps = new Skin[0];
    }
}

[Serializable]
public class Skin
{
    public int id = 0;
    public bool purchased = false;
    public bool selected = false;
}

public class SaveGame
{
    public void Save(int level = -1, int gemsCount = -1, Skin[] skinProps = null)
    {
        SaveData prevSave = LoadGame();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/SaveData.dat");
        SaveData data = new SaveData();

        if (prevSave.currentLevel<level){
            data.currentLevel = level;
        }
        else
        {
            data.currentLevel = prevSave.currentLevel;
        }
        if (prevSave.currentGemsCount != gemsCount&&gemsCount!=-1)
        {
            data.currentGemsCount = gemsCount;
        }
        else
        {
            data.currentGemsCount = prevSave.currentGemsCount;
        }
        if (skinProps!=null)
        {
            data.skinsProps = skinProps;
        }
        else
        {
            data.skinsProps = prevSave.skinsProps==null?new Skin[0]: prevSave.skinsProps;
        }
        bf.Serialize(file, data);
        file.Close();
    }

    public SaveData LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
              File.Open(Application.persistentDataPath 
              + "/SaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            data.skinsProps = data.skinsProps == null ? new SaveData().skinsProps : data.skinsProps;
            file.Close();
            return data;
        }
        else return new SaveData();
    }

        public void Reset()
        {
            if (File.Exists(Application.persistentDataPath 
            + "/SaveData.dat"))
            {
                File.Delete(Application.persistentDataPath 
                + "/SaveData.dat");
            }
        }
}
