using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScoreManager : MonoBehaviour
{

    public int newScore; // Stores the latest score to compare with the high score
    public GameObject ST; // Reference to a GameObject (unspecified usage in this script)
    public ScoreManager SM; // Reference to the ScoreManager to fetch the current score
    public Text HiText; // Text component to display the high score
    public Text GGT; // Text component to display messages like "New Hi-Score!!!"

    public void SetHiScore()
    {
        // Fetch the latest score from the ScoreManager
        newScore = SM.lol;

        // Check if the new score is greater than the current high score stored in PlayerPrefs
        if (newScore > PlayerPrefs.GetInt("Hi-Score"))
        {
            // Update the high score in PlayerPrefs
            PlayerPrefs.SetInt("Hi-Score", newScore);

            // Display a message indicating a new high score
            GGT.text = "New Hi-Score!!!";
        }

        // Update the high score display text
        HiText.text = "Hi-Score: " + PlayerPrefs.GetInt("Hi-Score");
    }
}
