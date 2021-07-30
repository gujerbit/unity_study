using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_enemy : MonoBehaviour
{
    public GameObject cactus_1; //������1
    public GameObject cactus_2; //������2
    public GameObject cactus_3; //������3
    public GameObject cactus_4; //������4
    public GameObject fly_dino; //�ͷ�

    public float createSpeed = 4f; //���� �ӵ�

    private bool canCreate = true; //���� �����Ѱ�?
    private int enemyType = 0; //0 - ������1, 1 - ������2, 2 - �ͷ�
    private int flySpawnPoint = 0; //0 - ��������Ʈ1, 1 - ��������Ʈ2

    private dino dino; //�÷��̾�

    private void Awake()
    {
        dino = GameObject.Find("dino").GetComponent<dino>(); //�ν����� ���� dino��� ������Ʈ�� dino ������Ʈ �޾ƿ���
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dino.isDead) return; //�÷��̾ ������ ���� ����

        if(canCreate) //���� �����ϴٸ�
        {
            canCreate = false; //���� ��Ȱ��ȭ
            StartCoroutine(CreateEnemy()); //�� ���� ����
        }
    }

    IEnumerator CreateEnemy()
    {
        if(createSpeed > 2) //���� �ӵ��� 2���� ���ٸ�
        {
            createSpeed -= 0.01f; //���� �ӵ� ����
            Debug.Log(createSpeed);
        }

        enemyType = Random.Range(0, 6); //�� Ÿ�� ���ϱ� 0~5

        if(enemyType == 2 || enemyType == 5) //�ͷ��̶��
        {
            Instantiate(fly_dino); //�ͷ� ����
            flySpawnPoint = Random.Range(0, 3); //������ �������� �ϴÿ��� �������� ���ϱ� 0~2

            if (flySpawnPoint == 0)
            {
                fly_dino.transform.position = new Vector3(10, -1, 1); //�ϴÿ��� ����
            } else if(flySpawnPoint == 1)
            {
                fly_dino.transform.position = new Vector3(10, -2.4f, 1); //�߰��� ����
            } else if(flySpawnPoint == 2)
            {
                fly_dino.transform.position = new Vector3(10, -2.92f, 1); //������ ����
            }
        } else //�׿� (������)
        {
            if(enemyType == 0) //������1
            {
                Instantiate(cactus_1); //������1 ����
                cactus_1.transform.position = new Vector3(10, -2.92f, 1); //������ ����
            } else if(enemyType == 1) //������2
            {
                Instantiate(cactus_2); //������2 ����
                cactus_2.transform.position = new Vector3(10, -2.92f, 1); //������ ����
            } else if(enemyType == 3)
            {
                Instantiate(cactus_3); //������3 ����
                cactus_3.transform.position = new Vector3(10, -3.12f, 1); //������ ����
            } else if(enemyType == 4)
            {
                Instantiate(cactus_4); //������4 ����
                cactus_4.transform.position = new Vector3(10, -3.12f, 1); //������ ����
            }
        }

        yield return new WaitForSeconds(createSpeed); //�ش� �� ��

        canCreate = true; //�ٽ� ���� ����
    }
}
