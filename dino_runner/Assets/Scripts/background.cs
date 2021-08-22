using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    private dino dino; //�÷��̾�
    private GameManager manager; //�Ŵ��� ��ü

    // Start is called before the first frame update
    void Start()
    {
        dino = GameObject.Find("dino").GetComponent<dino>(); //�ν����� ���� dino��� ������Ʈ�� dino ������Ʈ �޾ƿ���
        manager = GameObject.Find("manager").GetComponent<GameManager>(); //�ν����� ���� manager��� ������Ʈ�� GameManager ������Ʈ �޾ƿ���
    }

    // Update is called once per frame
    void Update()
    {
        if (dino.isDead) return; //������ ���� ����

        if(-40.42f > transform.position.x) //�ش� ��ġ���� �� ��ġ�� �� ���ʿ� �ִٸ� (-�� �������� ����)
        {
            transform.position = new Vector3(141.68f, 0.52f, 1); //�� ��ġ�� ���� �̵�
        }

        transform.Translate(new Vector3(-manager.speed, 0, 0) * Time.deltaTime); //manager�� �ִ� speed ��ŭ �������� �̵��ϴµ� �ð��� �帧�� ���� �̵� (Time.deltaTime ������ ���� �̵���)
    }
}
