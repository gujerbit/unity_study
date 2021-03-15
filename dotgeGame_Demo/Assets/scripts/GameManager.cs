using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string sceneName;
    public Text scoreText;
    public Text maxText;

    public player_move player;

    public static GameManager instance;

    private float scoreTime;
    private float maxScoreTime;

    private void Awake() {
        instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "gameOver") {
            scoreText.text = "CURRENT SCORE : " + PlayerPrefs.GetFloat("current");
            maxText.text = "MAX SCORE : " + PlayerPrefs.GetFloat("max");
        }

        if(PlayerPrefs.GetFloat("max") != null) maxScoreTime = PlayerPrefs.GetFloat("max");
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "gameOver") {
            scoreTime += Time.deltaTime;
            scoreText.text = "SCORE : " + Mathf.Round(scoreTime * 100) * 0.01f;

            if(maxScoreTime <= scoreTime) maxScoreTime = scoreTime;

            if(player.PlayerDead()) {
                PlayerPrefs.SetFloat("current", Mathf.Round(scoreTime * 100) * 0.01f);
                PlayerPrefs.SetFloat("max", Mathf.Round(maxScoreTime * 100) * 0.01f);
                SceneManager.LoadScene(sceneName);
            }
        } else {
            if(Input.GetKeyDown("space")) SceneManager.LoadScene(sceneName);
        }
    }
}
