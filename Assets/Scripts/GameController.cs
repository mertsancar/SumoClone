using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform players;

    public TMP_Text timeCounter;
    public float currentTime = 59;
    void Start()
    {
        StartTimeCounter();
        SetBots();
    }

    void Update()
    {
        if ((int)currentTime > 0)
        {
            UpdateTimeCounter();
        }

        if (players.childCount == 1)
        {
            Leaderboard.leaderboard.Add(1, players.GetChild(0).name);
            ScreenManager.instance.OpenScreen(ScreenNames.LeaderboardScreen);
            Destroy(players.GetChild(0).gameObject); 
        }
    }
    private void SetBots()
    {
        var nickNames = Parser.GetNickNames();
        for (int i = 0; i < players.childCount; i++)
        {
            var child = players.GetChild(i);
            if (child.name == "PLayer")
            {
                continue;
            }
            if (child.CompareTag("Player"))
            {
                child.name = nickNames[Random.Range(0, nickNames.Count - 1)];
                nickNames.Remove(child.name);
            }        
        }
    }

    private void StartTimeCounter()
    {
        timeCounter.text = "Time: 01:00";
    }
    
    private void UpdateTimeCounter()
    {
        currentTime -= Time.deltaTime;
        timeCounter.text = "Time: 00:" + (int)currentTime;

        if ((int)currentTime <= 0)
        {
            ScreenManager.instance.OpenScreen(ScreenNames.LeaderboardScreen);
        }
    }
    

}
