using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public TMP_Text placeText;
    public TMP_Text pushedByText;

    public Player player;
    
    void Start()
    {
        placeText.text = "#" + player.placeOrder; 
        pushedByText.text = "Pushed by " + player.pushedByName; 
    }

    public void ClickAgainButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
