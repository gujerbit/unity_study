using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text maxScoreText;
    public player player;
    public string sceneName;

    public static GameManager instance;

    private float currentScore;
    private float maxScore;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "gameOver")
        {
            scoreText.text = "CURRENT SCORE : " + Mathf.Round(PlayerPrefs.GetFloat("current") * 100) * 0.01f;
            maxScoreText.text = "MAX SCORE : " + Mathf.Round(PlayerPrefs.GetFloat("max") * 100) * 0.01;
        }

        maxScore = PlayerPrefs.GetFloat("max");
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "gameOver")
        {
            if(Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(sceneName);
            }
        } else
        {
            currentScore += Time.deltaTime;
            scoreText.text = "SCORE : " + Mathf.Round(currentScore * 100) * 0.01f;

            if (player.DeadStatus())
            { 
                if (maxScore <= currentScore) maxScore = currentScore;
                PlayerPrefs.SetFloat("current", currentScore);
                PlayerPrefs.SetFloat("max", maxScore);
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}