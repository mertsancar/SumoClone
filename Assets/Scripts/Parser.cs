using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parser
{
    public static List<string> GetNickNames()
    {
        TextAsset nicknameText = Resources.Load<TextAsset>("nickNames");
        
        var nicknames = new List<string>();
        if (nicknameText != null)
        {
            string[] lines = nicknameText.text.Split('\n');

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                if (!string.IsNullOrEmpty(trimmedLine))
                {
                    nicknames.Add(trimmedLine);
                }
            }
        }
        else
        {
            Debug.LogError("Nickname file not found in Resources folder: " + "nickNames");
        }

        return nicknames;
    }
}
