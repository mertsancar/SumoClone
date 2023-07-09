using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;
    
    [SerializeField] private List<GameObject> screens;

    public void Awake()
    {
        instance = this;
    }

    public void OpenScreen(string screenName)
    {
        CloseScreens();
        screens.FindLast(s => s.name == screenName).SetActive(true);
    }
    
    public void CloseScreens()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    
}

public static class ScreenNames
{
    public const string PauseScreen = "PauseScreen";
    public const string EndScreen = "EndScreen";
    public const string LeaderboardScreen = "LeaderboardScreen";
}
