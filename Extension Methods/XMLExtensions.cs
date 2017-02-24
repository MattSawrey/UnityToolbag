using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

public static class XmlExtensions
{
	public static T LoadFromXML<T>(this string xmlString)
	{
		T returnValue = default(T);
		
		using (StringReader reader = new StringReader(xmlString))
		{
			object result = new XmlSerializer(typeof(T)).Deserialize(reader);
			if (result is T)
			{
				returnValue = (T)result;
			}
		}
		return returnValue;
	}
	
	public static string GetXml(this object obj)
	{
		using (var textWriter = new StringWriter())
		{
			var settings = new XmlWriterSettings() { Indent = true, IndentChars = "    " }; // For cosmetic purposes.
			using (var xmlWriter = XmlWriter.Create(textWriter, settings))
				new XmlSerializer(obj.GetType()).Serialize(xmlWriter, obj);
			return textWriter.ToString();
		}
	}
	
	public static object Deserialize(this XContainer element, System.Type type)
	{
		using (var reader = element.CreateReader()) 
		{
			return new XmlSerializer(type).Deserialize(reader);
		}
	}
	
	public static XElement SerializeToXElement<T>(this T obj)
	{
		var doc = new XDocument();
		using (var writer = doc.CreateWriter())
			new XmlSerializer(obj.GetType()).Serialize(writer, obj);
		var element = doc.Root;
		if (element == null)
			element.Remove();
		return element;
	}
}
