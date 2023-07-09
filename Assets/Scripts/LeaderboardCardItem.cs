using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardCardItem : MonoBehaviour
{
    public TMP_Text content;

    public void Init(string text)
    {
        content.text = text;
    }
    
}
