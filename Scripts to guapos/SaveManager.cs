using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public SaveData currentSaveData;
    const string SAVE_FILENAME = "save.sav";


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    public void Save()
    {
        //Hace falta un using
        BinaryFormatter bf = new BinaryFormatter();
        //Y otro using 
        MemoryStream ms = new MemoryStream();//Cosas de la RAM 
        bf.Serialize(ms, currentSaveData);
        File.WriteAllBytes(SAVE_FILENAME, ms.GetBuffer());
    }

    public void Load()
    {
        if(File.Exists(SAVE_FILENAME))
        {
            BinaryFormatter bf = new BinaryFormatter();
            currentSaveData = (SaveData)bf.Deserialize(File.Open(SAVE_FILENAME, FileMode.Open));
        }
    }
}
