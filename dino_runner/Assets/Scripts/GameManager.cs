using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager manager; //�ڱ� �ڽ�
    public Text currentScoreText; //���� ���� �ؽ�Ʈ
    public Text highScoreText; //�ְ� ���� �ؽ�Ʈ
    public Text gameoverText; //���� ���� �ؽ�Ʈ
    public GameObject replayIcon; //���� ���� ������

    public float speed = 10f; //���� �����̴� �ӵ�

    private bool speedUp = true; //���ǵ尡 �ö� �� �ִ°�
    private float highScore = 0; //�ְ� ����
    private float currentScore = 0; //���� ����

    private dino dino; //�÷��̾�
    private create_enemy createEnemy;

    private void Awake()
    {
        manager = this; //�̱��� ����
        dino = GameObject.Find("dino").GetComponent<dino>(); //�ν����� ���� dino��� ������Ʈ�� dino ������Ʈ �޾ƿ���
        createEnemy = GameObject.Find("createEnemy").GetComponent<create_enemy>();
        PlayerPrefs.SetFloat("high", 0); //�ְ� ���� ����
        replayIcon.SetActive(false); //���� ���� ������ ���߱�
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetFloat("high"); //�ְ� ���� �޾ƿ���
    }

    // Update is called once per frame
    void Update()
    {
        if(dino.isDead) //�÷��̾ �׾��ٸ�
        {
            PlayerPrefs.SetFloat("high", highScore); //�ְ� ���� ����
            highScoreText.text = Mathf.Ceil(highScore).ToString(); //�ְ� ���� �ؽ�Ʈ ���
            replayIcon.SetActive(true); //���� ���� ������ ����
            gameoverText.text = "GAME OVER"; //���� ���� �ؽ�Ʈ ����

            if (Input.GetKeyDown(KeyCode.Space)) //�÷��̾ ���� ���¿��� �����̽��ٸ� ������ �����
            {
                dino.isDead = false; //�÷��̾� ���� ���� �ʱ�ȭ
                dino.anim.SetBool("isDead", false); //�÷��̾� �ִϸ��̼� �ʱ�ȭ
                currentScore = 0; //���� ���� �ʱ�ȭ
                replayIcon.SetActive(false); //���� ���� ������ ���߱�
                gameoverText.text = ""; //���� ���� �ؽ�Ʈ ���߱�
                speed = 10f;
                createEnemy.createSpeed = 4f;
                GameObject[] enemy = GameObject.FindGameObjectsWithTag("enemy"); //���� enemy �±׸� ���� �ִ� ��� ���� ������Ʈ�� ȣ��
                for(int i = 0; i < enemy.Length; i++)
                {
                    Destroy(enemy[i]); //��� ���� ����
                }
            }
        } else //�÷��̾ ����ִ� ����
        {
            if (highScore <= currentScore) //�ְ� �������� ���� ������ ���ٸ�
            {
                highScore = currentScore; //�ְ� ������ ���� ���� ������
                highScoreText.text = Mathf.Ceil(currentScore).ToString(); //�ְ� ���� �ؽ�Ʈ ���
            }

            currentScore += Time.deltaTime * 10; //���� ���
            currentScoreText.text = Mathf.Ceil(currentScore).ToString(); //���� ���� �ؽ�Ʈ ���

            if (speedUp) //���ǵ尡 �ö� �� �ִٸ�
            {
                speedUp = false; //���ǵ� �ø��� ��Ȱ��ȭ
                StartCoroutine(SpeedUP()); //�ڷ�ƾ ����
            }
        }
    }

    IEnumerator SpeedUP() //�ӵ� �ø���
    {
        speed += 0.03f; //���� �ӵ� ����

        yield return new WaitForSeconds(0.7f); //0.7����

        speedUp = true; //�ӵ� �ø��� �ٽ� Ȱ��ȭ
    }
}
