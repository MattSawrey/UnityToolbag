using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class MyStringFunctions 
{
	public static string RemoveSpacesFromString(this string text)
	{
		char[] characters = text.ToCharArray();
		List<char> nonBlankChars = new List<char>();

		char blank = ' ';

        for(int i=0; i<characters.Length; i++)
            if (characters[i] != blank)
                nonBlankChars.Add(characters[i]);

        return new string(nonBlankChars.ToArray());
	}

	public static Vector3 GetVector3FromString(this string text)
	{
		text = text.Replace('(', ' ');
		text = text.Replace(')', ' ');

		string[] temp = text.Split(',');
		float x = float.Parse(temp[0]);
		float y = float.Parse(temp[1]);
		float z = float.Parse(temp[2]);
		Vector3 rValue = new Vector3(x,y,z);
		return rValue;
	}

    public static Vector2 GetVector2FromString(this string text)
    {
        text = text.Replace('(', ' ');
        text = text.Replace(')', ' ');

        string[] temp = text.Split(',');
        float x = float.Parse(temp[0]);
        float y = float.Parse(temp[1]);
        Vector2 result = new Vector2(x, y);
        return result;
    }
}
