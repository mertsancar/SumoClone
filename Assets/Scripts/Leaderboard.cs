using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public static Dictionary<int, string> leaderboard = new Dictionary<int, string>();
    
    public static int AddLeaderboard(string userName)
    {
        var players = GameObject.Find("Players");
        var place = players.transform.childCount;
        if (!leaderboard.ContainsKey(place))
        {
            leaderboard.Add(place, userName);
        }

        return place;
    }
    
    public static Dictionary<int, string> GetLeaderboard()
    {
        return leaderboard.OrderBy(obj => obj.Key).ToDictionary(obj => obj.Key, obj => obj.Value);
    }
}
