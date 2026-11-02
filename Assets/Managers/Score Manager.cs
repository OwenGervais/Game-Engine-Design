using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int CurrentScore { get; set; }

    public TextMeshPro scoreText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ResetScore();
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        UpdateText();
    }

    public void AddScore(int amount)
    {
        CurrentScore += amount;
        UpdateText();
    }

    private void UpdateText()
    {
        if (scoreText != null) scoreText.text = CurrentScore.ToString();

        //Cool Tech: The Questionmark makes it so the scoretext is null if it cannot find the gameobject, otherwise it would give an error
        else scoreText = GameObject.Find("Score Text")?.GetComponent<TextMeshPro>();
    }
}
