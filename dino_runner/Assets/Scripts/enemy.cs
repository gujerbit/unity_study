using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D rigid;
    private GameManager manager; //�Ŵ��� ��ü
    private dino dino; //�÷��̾�
    private float speed = 10f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        manager = GameObject.Find("manager").GetComponent<GameManager>(); //�ν����� ���� manager��� ������Ʈ�� GameManager ������Ʈ �޾ƿ���
        dino = GameObject.Find("dino").GetComponent<dino>(); //�ν����� ���� dino��� ������Ʈ�� dino ������Ʈ �޾ƿ���
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestroy()); //�������ڸ��� �ڷ�ƾ ����
    }

    // Update is called once per frame
    void Update()
    {
        if (dino.isDead) //�÷��̾ �׾��ٸ�
        {
            rigid.velocity = new Vector2(0, 0); //�������� �ʵ��� ����
            return;
        }
        //rigid.velocity = new Vector2(-manager.speed, rigid.velocity.y); //��� �������� �̵�
        rigid.velocity = new Vector2(speed, rigid.velocity.y); //��� �������� �̵� manager �Ⱦ��� ���� ��� ���� float ������ speed �����������
    }

    IEnumerator SelfDestroy() //������Ʈ�� ��� �����ִ°��� �����ϱ� ���� �ڵ�
    {
        yield return new WaitForSeconds(5); //5�� ��

        if (!dino.isDead) //�÷��̾ ����ִٸ�
        {
            Destroy(gameObject); //�ڱ� �ڽ� ����
        }
    }
}
