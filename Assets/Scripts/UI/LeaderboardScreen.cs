using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardScreen : MonoBehaviour
{
    public GameObject leaderboardCardPrefab;
    public Transform leaderboardLayout;
    
    void Start()
    {
        var leaderboard = Leaderboard.GetLeaderboard();
        foreach (var player in leaderboard)
        {
            var go = Instantiate(leaderboardCardPrefab, leaderboardLayout);
            var cardData = go.GetComponent<LeaderboardCardItem>();
            cardData.Init(player.Key + ") " + player.Value);
        }
    }

    public void ClickAgainButton()
    {
        SceneManager.LoadScene("SampleScene");
    }


}
