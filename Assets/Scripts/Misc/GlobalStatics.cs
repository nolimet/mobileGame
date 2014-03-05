using UnityEngine;
using System.Collections;

public class GlobalStatics :MonoBehaviour {
    public static int currentType = 0;
    public static int maxType = 5;
    public static int levelToLoad = 0;
	public static bool gravityOff = false;
	public static bool playerOnGround = false;

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

    public static void GameOver()
    {
        levelToLoad = Application.loadedLevel;
        Application.LoadLevelAdditive(3);
    }
}
