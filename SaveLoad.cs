using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

public static class SaveLoad
{
	#region SAVING

	public static void SaveToXML(this object obj, string filePath, bool createFileIfNotExist)
	{
		if(!File.Exists(filePath))
		{
			if(createFileIfNotExist)
				CreateFile(filePath);
		}

		using(StreamWriter sw = new StreamWriter(filePath))
		{
			var objToWrite = obj.GetXml();
			Debug.Log(objToWrite);
			sw.Write(objToWrite);
		}
	}

	public static void WriteToXML(this object obj, string filePath, bool createFileIfNotExist)
	{
		if(!File.Exists(filePath))
		{
			if(createFileIfNotExist)
				CreateFile(filePath);
		}
		var serializer = new XmlSerializer(obj.GetType());
		using(StreamWriter stream = new StreamWriter(filePath + ".xml"))
		{
			serializer.Serialize(stream, obj);
		}
	}

	public static void WriteToBinary(this object obj, string filePath, bool createFileIfNotExist)
	{
		if(!File.Exists(filePath))
		{
			if(createFileIfNotExist)
				CreateFile(filePath);
		}

		var formatter = new BinaryFormatter();
		using(FileStream stream = File.Open(filePath, FileMode.Append))
		{
			formatter.Serialize(stream, obj);
		}
	}

	public static void WriteDataListToTextFile<T>(T dataList, string filePath, bool createFileIfNotExist) where T : IEnumerable, ICollection
	{
		string filePathToUse = filePath + ".txt";

		if(!File.Exists(filePathToUse))
		{
			if(createFileIfNotExist)
				CreateFile(filePathToUse);
		}
		
		using(StreamWriter sw = new StreamWriter(filePathToUse))
		{
			foreach(var type in dataList)
			{				
				Debug.Log(dataList.Count);
				sw.WriteLine(type.ToString());
			}
		}
	}

	public static void SaveToTextFile(this object obj, string filePath, bool createFileIfNotExist)
	{
		if(!File.Exists(filePath))
		{
			if(createFileIfNotExist)
				CreateFile(filePath);
		}

		using(StreamWriter sw = new StreamWriter(filePath))
		{
			sw.WriteLine(obj.ToString());
		}
	}
	
	#endregion

	#region LOADING

	public static T LoadCollectionFromXML<T>(string filePath)
	{
		if(!File.Exists(filePath))
		{
			throw new Exception("Trying to load a file that does not exist");
		}
		using(StreamReader sr = new StreamReader(filePath))
		{
			var xmlLoadedString = sr.ReadToEnd();
			var result = xmlLoadedString.LoadFromXML<T>();
			return result;
		}
	}

	public static string ReadFromTextFile(string filePath)
	{
		string filePathToUse = filePath + ".txt";

		if(!File.Exists(filePathToUse))
		{
			throw new Exception("Trying to load a file that does not exist");
		}
		using(StreamReader sr = new StreamReader(filePathToUse))
		{
			var stringRead = sr.ReadToEnd();
			return stringRead;
		}
	}

	public static string[] ReadLinesFromTextFile(string filePath)
	{
		string filePathToUse = filePath + ".txt";

		List<string> result = new List<string>();
		
		if(!File.Exists(filePathToUse))
		{
			throw new Exception("Trying to load a file that does not exist");
		}
		using(StreamReader sr = new StreamReader(filePathToUse))
		{
			string line;

			do
			{
				line = sr.ReadLine();
				result.Add(line);
			}while(line != null);
		}

		return result.ToArray();
	}
	
	#endregion

	public static int NumLines(string filePath)
	{
		int result = 0;
		using(StreamReader sr = new StreamReader(filePath))
		{
			string[] lines = sr.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			for(int i = 0; i < lines.Length; i++)
			{
				result++;
			}
		}		
		return result;
	}

	public static void CreateFile(string filePath)
	{
		using(StreamWriter sw = new StreamWriter(File.Create(filePath)))
		{}
	}
}

