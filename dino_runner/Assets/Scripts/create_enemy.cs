using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_enemy : MonoBehaviour
{
    public GameObject cactus_1; //������1
    public GameObject cactus_2; //������2
    public GameObject cactus_3; //������3
    public GameObject cactus_4; //������4
<<<<<<< HEAD
    public GameObject cactus_5; //������5
    public GameObject cactus_6; //������6
    public GameObject fly_dino; //�ͷ�
    public GameObject meteor_1; //�1
    public GameObject meteor_2; //�2

    public float createSpeed = 3.5f; //���� �ӵ�

    private bool canCreate = true; //���� �����Ѱ�?
    private int enemyType = 0; //0 - �ͷ�, 1 - ������, 2 - �
    private int flySpawnPoint = 0; //���� ��ġ
=======
    public GameObject fly_dino; //�ͷ�

    public float createSpeed = 4f; //���� �ӵ�

    private bool canCreate = true; //���� �����Ѱ�?
    private int enemyType = 0; //0 - ������1, 1 - ������2, 2 - �ͷ�
    private int flySpawnPoint = 0; //0 - ��������Ʈ1, 1 - ��������Ʈ2
>>>>>>> ff78e9ef4b678e470ddc99b38636207e0ac932d3

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
<<<<<<< HEAD
        }

        enemyType = Random.Range(0, 3); //�� Ÿ�� ���ϱ� 0~2

        if(enemyType == 0) //�ͷ�
        {
            Instantiate(fly_dino); //�ͷ� ����
            flySpawnPoint = Random.Range(0, 3); //������ġ ���ϱ� 0~2

            if (flySpawnPoint == 0)
            {
                fly_dino.transform.position = new Vector3(25, -1, 1); //�ϴÿ��� ����
            } else if(flySpawnPoint == 1)
            {
                fly_dino.transform.position = new Vector3(25, -2.4f, 1); //�߰��� ����
            } else if(flySpawnPoint == 2)
            {
                fly_dino.transform.position = new Vector3(25, -2.92f, 1); //������ ����
            }
        } else if(enemyType == 1) //������
        {
            enemyType = Random.Range(0, 6); //������ ���� ���ϱ� 0~5

            if (enemyType == 0)
            {
                Instantiate(cactus_1); //������1 ����
                cactus_1.transform.position = new Vector3(25, -2.92f, 1);
            } else if(enemyType == 1)
            {
                Instantiate(cactus_2); //������2 ����
                cactus_2.transform.position = new Vector3(25, -2.92f, 1);
            } else if(enemyType == 2)
            {
                Instantiate(cactus_3); //������3 ����
                cactus_3.transform.position = new Vector3(25, -3.12f, 1);
            } else if(enemyType == 3)
            {
                Instantiate(cactus_4); //������4 ����
                cactus_4.transform.position = new Vector3(25, -3.12f, 1);
            } else if(enemyType == 4)
            {
                Instantiate(cactus_5); //������5 ����
                cactus_5.transform.position = new Vector3(25, -2.92f, 1);
            } else
            {
                Instantiate(cactus_6); //������6 ����
                cactus_6.transform.position = new Vector3(25, -2.92f, 1);
            }
        } else //�
        {
            enemyType = Random.Range(0, 2); //� ���� ���ϱ� 0~1

            if (enemyType == 0)
            {
                Instantiate(meteor_1); //� 1 ����
                meteor_1.transform.position = new Vector3(25, 0.67f, 1);
            }
            else
            {
                Instantiate(meteor_2); //� 2 ����
                meteor_2.transform.position = new Vector3(25, -1.82f, 1); //������ ����
=======
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
>>>>>>> ff78e9ef4b678e470ddc99b38636207e0ac932d3
            }
        }

        yield return new WaitForSeconds(createSpeed); //�ش� �� ��

        canCreate = true; //�ٽ� ���� ����
    }
}
