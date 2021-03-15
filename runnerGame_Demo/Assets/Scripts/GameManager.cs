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
            //scoreText, maxText ≥÷æÓ¡‡æﬂµ 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.DeadStatus())
        {
            if (maxScore <= currentScore) maxScore = currentScore;
            PlayerPrefs.SetFloat("current", currentScore);
            PlayerPrefs.SetFloat("max", maxScore);
            SceneManager.LoadScene(sceneName);
        }

        if(SceneManager.GetActiveScene().name == "gameOver")
        {
            if(Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(sceneName);
            }
        } else
        {
            currentScore += Time.deltaTime;
            scoreText.text = "SCORE : " + Mathf.round(currentScore * 100) * 0.01f;
        }
    }
}