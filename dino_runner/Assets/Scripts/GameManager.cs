using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager manager; //자기 자신
    public Text currentScoreText; //현재 점수 텍스트
    public Text highScoreText; //최고 점수 텍스트
    public Text gameoverText; //게임 오버 텍스트
    public GameObject replayIcon; //게임 오버 아이콘

    public float speed = 10f; //적들 움직이는 속도

    private bool speedUp = true; //스피드가 올라갈 수 있는가
    private float highScore = 0; //최고 점수
    private float currentScore = 0; //현재 점수

    private dino dino; //플레이어
    private create_enemy createEnemy;

    private void Awake()
    {
        manager = this; //싱글톤 패턴
        dino = GameObject.Find("dino").GetComponent<dino>(); //인스펙터 상의 dino라는 오브젝트의 dino 컴포넌트 받아오기
        createEnemy = GameObject.Find("createEnemy").GetComponent<create_enemy>();
        PlayerPrefs.SetFloat("high", 0); //최고 점수 세팅
        replayIcon.SetActive(false); //게임 오버 아이콘 감추기
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetFloat("high"); //최고 점수 받아오기
    }

    // Update is called once per frame
    void Update()
    {
        if(dino.isDead) //플레이어가 죽었다면
        {
            PlayerPrefs.SetFloat("high", highScore); //최고 점수 세팅
            highScoreText.text = Mathf.Ceil(highScore).ToString(); //최고 점수 텍스트 기록
            replayIcon.SetActive(true); //게임 오버 아이콘 생성
            gameoverText.text = "GAME OVER"; //게임 오버 텍스트 생성

            if (Input.GetKeyDown(KeyCode.Space)) //플레이어가 죽은 상태에서 스페이스바를 누르면 재시작
            {
                dino.isDead = false; //플레이어 죽음 상태 초기화
                dino.anim.SetBool("isDead", false); //플레이어 애니메이션 초기화
                currentScore = 0; //현재 점수 초기화
                replayIcon.SetActive(false); //게임 오버 아이콘 감추기
                gameoverText.text = ""; //게임 오버 텍스트 감추기
                speed = 10f;
                createEnemy.createSpeed = 4f;
                GameObject[] enemy = GameObject.FindGameObjectsWithTag("enemy"); //현재 enemy 태그를 갖고 있는 모든 게임 오브젝트들 호출
                for(int i = 0; i < enemy.Length; i++)
                {
                    Destroy(enemy[i]); //모든 적들 삭제
                }
            }
        } else //플레이어가 살아있는 동안
        {
            if (highScore <= currentScore) //최고 점수보다 현재 점수가 높다면
            {
                highScore = currentScore; //최고 점수에 현재 점수 덮어씌우기
                highScoreText.text = Mathf.Ceil(currentScore).ToString(); //최고 점수 텍스트 기록
            }

            currentScore += Time.deltaTime * 10; //점수 상승
            currentScoreText.text = Mathf.Ceil(currentScore).ToString(); //현재 점수 텍스트 기록

            if (speedUp) //스피드가 올라갈 수 있다면
            {
                speedUp = false; //스피드 올리기 비활성화
                StartCoroutine(SpeedUP()); //코루틴 실행
            }
        }
    }

    IEnumerator SpeedUP() //속도 올리기
    {
        speed += 0.03f; //현재 속도 증가

        yield return new WaitForSeconds(0.7f); //0.7초후

        speedUp = true; //속도 올리기 다시 활성화
    }
}
