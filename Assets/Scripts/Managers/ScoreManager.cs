using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score; // Static variable to keep track of the score
    public int lol; // Local copy of the score for display

    Text text; // UI Text component to display the score

    void Awake()
    {
        text = GetComponent<Text>(); // Get the Text component
        score = 0; // Initialize the score to zero
    }

    void Update()
    {
        text.text = "Score: " + score; // Update the UI with the current score
        lol = score; // Sync the local variable with the static score
    }
}
