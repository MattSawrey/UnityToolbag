using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    #region - Binary
    public static void SaveAsBinary(object objectToSerialize, string fileName)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + fileName);
        bf.Serialize(file, objectToSerialize);
        file.Close();
    }

    public static T LoadFromBinary<T>(string fileName)
    {
        if (File.Exists(Application.persistentDataPath + "/" + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + fileName, FileMode.Open);
            T result = (T)bf.Deserialize(file);
            file.Close();
            return result;
        }
        else
            throw new Exception("Attempting to load data from: " + fileName + ". File could not be found");
    }
    #endregion
}
