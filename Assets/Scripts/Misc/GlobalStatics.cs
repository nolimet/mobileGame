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
}
