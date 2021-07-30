using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_enemy : MonoBehaviour
{
    public GameObject cactus_1; //선인장1
    public GameObject cactus_2; //선인장2
    public GameObject cactus_3; //선인장3
    public GameObject cactus_4; //선인장4
    public GameObject fly_dino; //익룡

    public float createSpeed = 4f; //생산 속도

    private bool canCreate = true; //생산 가능한가?
    private int enemyType = 0; //0 - 선인장1, 1 - 선인장2, 2 - 익룡
    private int flySpawnPoint = 0; //0 - 스폰포인트1, 1 - 스폰포인트2

    private dino dino; //플레이어

    private void Awake()
    {
        dino = GameObject.Find("dino").GetComponent<dino>(); //인스펙터 상의 dino라는 오브젝트의 dino 컴포넌트 받아오기
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dino.isDead) return; //플레이어가 죽으면 생산 정지

        if(canCreate) //생산 가능하다면
        {
            canCreate = false; //생산 비활성화
            StartCoroutine(CreateEnemy()); //적 생성 시작
        }
    }

    IEnumerator CreateEnemy()
    {
        if(createSpeed > 2) //생산 속도가 2보다 높다면
        {
            createSpeed -= 0.01f; //생산 속도 증가
            Debug.Log(createSpeed);
        }

        enemyType = Random.Range(0, 6); //적 타입 정하기 0~5

        if(enemyType == 2 || enemyType == 5) //익룡이라면
        {
            Instantiate(fly_dino); //익룡 생성
            flySpawnPoint = Random.Range(0, 3); //땅에서 스폰인지 하늘에서 스폰인지 정하기 0~2

            if (flySpawnPoint == 0)
            {
                fly_dino.transform.position = new Vector3(10, -1, 1); //하늘에서 생성
            } else if(flySpawnPoint == 1)
            {
                fly_dino.transform.position = new Vector3(10, -2.4f, 1); //중간에 생성
            } else if(flySpawnPoint == 2)
            {
                fly_dino.transform.position = new Vector3(10, -2.92f, 1); //땅에서 생성
            }
        } else //그외 (선인장)
        {
            if(enemyType == 0) //선인장1
            {
                Instantiate(cactus_1); //선인장1 생성
                cactus_1.transform.position = new Vector3(10, -2.92f, 1); //땅에서 스폰
            } else if(enemyType == 1) //선인장2
            {
                Instantiate(cactus_2); //선인장2 생성
                cactus_2.transform.position = new Vector3(10, -2.92f, 1); //땅에서 스폰
            } else if(enemyType == 3)
            {
                Instantiate(cactus_3); //선인장3 생성
                cactus_3.transform.position = new Vector3(10, -3.12f, 1); //땅에서 스폰
            } else if(enemyType == 4)
            {
                Instantiate(cactus_4); //선인장4 생성
                cactus_4.transform.position = new Vector3(10, -3.12f, 1); //땅에서 스폰
            }
        }

        yield return new WaitForSeconds(createSpeed); //해당 초 뒤

        canCreate = true; //다시 생산 가능
    }
}
