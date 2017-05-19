using System;
using UnityEngine;
using System.IO;
using System.Text;
using System.Xml.Serialization;

//TODO - look into creating files of native data type - I.E. json saves as Json
/// <summary>
/// Static helper for Serializing and Deserializing data to and from txt, xml, json and bin.
/// </summary>
public static class SaveLoad
{
    public static string gameBaseDirectory = Application.persistentDataPath + Path.DirectorySeparatorChar;

    public static void SaveToText(this object obj, string filePath, bool createFileIfNotExist)
    {
        if (!File.Exists(filePath))
            if (createFileIfNotExist)
                CreateFile(filePath);
            else
                throw new Exception("Trying to write to a file that does not exist");

        using (StreamWriter sw = new StreamWriter(filePath))
        {
            sw.WriteLine(obj.ToString());
        }
    }

    public static string LoadFromText(string filePath)
    {
        if (!File.Exists(filePath))
            throw new Exception("Trying to load file that cannot be found");

        using (StreamReader sr = new StreamReader(filePath))
        {
            return sr.ReadToEnd();
        }
    }

    public static void SerializeToXML(object obj, string filePath)
    {
        StringBuilder xml = new StringBuilder();
        XmlSerializer serializer = new XmlSerializer(obj.GetType());
        using (TextWriter textWriter = new StringWriter(xml))
        {
            serializer.Serialize(textWriter, obj);
        }

        xml.SaveToText(filePath, true);
    }

    public static T DeSerializeFromXML<T>(string filePath)
    {
        string xml = LoadFromText(filePath);
        T obj = default(T);
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (TextReader textReader = new StringReader(xml))
        {
            obj = (T) serializer.Deserialize(textReader);
        }
        return obj;
    }

    public static void SerializeToJson(object obj, string filePath)
    {
        string json = JsonUtility.ToJson(obj);
        json.SaveToText(filePath, true);
    }

    public static T DeserializeFromJson<T>(string filePath)
    {
        string json = LoadFromText(filePath);
        return JsonUtility.FromJson<T>(json);
    }

    public static void CreateFile(string filePath)
    {
        var file = File.Create(filePath);
        file.Close();
    }
}
