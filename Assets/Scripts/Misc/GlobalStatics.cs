﻿using UnityEngine;
using System.Collections;

public class GlobalStatics :MonoBehaviour {
    public static int currentType = 0;
    public static int maxType = 5;
    public static int levelToLoad = 0;
	public static bool playerOnGround = false;
    public static bool loadedLevel = false;
    public static bool SelectedAObject = false;
    public const string audioManager= "SoundManager";

    public static void load(int level)
    {
        levelToLoad = level;
        Application.LoadLevelAdditive(2);
    }

    public static Color randomColor()
    {
       // float numb = 0.0039215686274509803921568627451f;
        Color output = new Color();
        output.b = 1 * Random.value;
        output.g = 1 * Random.value;
        output.r = 1 * Random.value;
        output.a = 1;

        return output;
    }

    public static Color RGBAColour(int R,int G,int B,float A)
    {
        float numb = 0.0039215686274509803921568627451f;
        Color output = new Color();
        
        output.r = R * numb;
        output.g = G * numb;
        output.b = B * numb;
        output.a = A * numb;

        return output;
    }

    public static void GameOver()
    {
        if (!loadedLevel)
        {
            
            levelToLoad = Application.loadedLevel;
            Application.LoadLevelAdditive(3);
            loadedLevel = true;
        }
    }
    public static void GraviChange()
    {
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            go.SendMessage("GraviSwitch", SendMessageOptions.DontRequireReceiver);
        }
    }
}
