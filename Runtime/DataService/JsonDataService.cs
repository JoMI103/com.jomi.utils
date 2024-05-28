using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonDataService : IDataService
{
    //https://www.youtube.com/watch?v=mntS45g8OK4

    public T LoadData<T>(string RelativePath, bool Encrypted = false)
    {
        string path = Application.persistentDataPath + RelativePath;

        if (!File.Exists(path))
        {
            Debug.LogError($"Cannot load file at {path}. File does not exist!");
            throw new FileNotFoundException($"{path} does not exist");
        }

        try
        {
            T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            return data;
        }
        catch
        {
            Debug.LogError("Failed to load data");
            throw;
        }
    }

    public bool SaveData<T>(string RelativePath, T data, bool Encrypted = false)
    {
        string path = Application.persistentDataPath + RelativePath;

        try
        {
            if (File.Exists(path))
            {
                Debug.Log("Deliting old file and writing a new one");
                File.Delete(path);
            }
            else
            {
                Debug.Log("Wrinting file for the first time");
            }

            using FileStream stream = File.Create(path);
            stream.Close();
            File.WriteAllText(path, JsonConvert.SerializeObject(data));
            return true;
        }
        catch 
        {
            Debug.Log("Unable to save data");
            return false;
        }
    }
}
