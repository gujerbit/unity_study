using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string sceneName;
    public Text scoreText;
    public Text currentText;
    public Text maxText;

    public player_move player;

    private static GameManager instance;
    private float scoreTime;
    private float maxScoreTime;

    private bool main = true;

    public static GameManager getInstance() {
        return instance;
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        scoreTime = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null) {
            Debug.Log("instance is Duplicate");
            instance = this;
        } 

        Debug.Log(SceneManager.GetActiveScene().name);
        Debug.Log(main);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "gameOver") {
            main = false;
        } else {
            main = true;
        }
        
        if(main) {
            scoreTime += Time.deltaTime;
            scoreText.text = "SCORE : " + Mathf.Round(scoreTime * 10) * 0.01f;

            if(player.PlayerDead()) {
                SceneManager.LoadScene(sceneName);
            }

            if(maxScoreTime < scoreTime) maxScoreTime = scoreTime;
        } else {
            currentText.text = "CURRENT SCORE : " + Mathf.Round(scoreTime * 10) * 0.01f;
            maxText.text = "MAX SCORE : " + maxScoreTime;
        }
    }
}
