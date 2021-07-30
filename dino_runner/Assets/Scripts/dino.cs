using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dino : MonoBehaviour
{
    public float jumpPower = 3f; //�÷��̾��� ������
    public bool isDead = false; //�÷��̾� ��� ����

    private bool canJump = true; //������ �ٽ� �� �� �ִ°�? (2�� ���� ����)
    private bool gravityUp = false;

    private Rigidbody2D rigid;
    public Animator anim; //�÷��̾��� �ִϸ��̼� ��Ʈ�ѷ�

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return; //������ ���� �Ұ�

        if(gameObject.transform.position.y < -5) //���� �÷��̾ ��Ż�� �ߴٸ�
        {
            gameObject.transform.position = new Vector3(rigid.velocity.x, -3, 1); //�÷��̾� ��ġ ���󺹱�
        }

        if(Input.GetKeyDown(KeyCode.Space) && canJump) //����
        {
            canJump = false; //���߿��� ���� �Ұ����ϰ� ���� ���Ƴ���
            rigid.AddForce(new Vector2(rigid.velocity.x, jumpPower), ForceMode2D.Impulse); //x�� ���� �״�� y�� ���� ���� y�� �� * 5��ŭ�� �� �ο�
            anim.SetTrigger("isJump"); //�ִϸ��̼� �Ķ���� ����
        }

        if(Input.GetKeyDown(KeyCode.S)) //�÷��̾ S��ư�� ������ �ִٸ�
        {
            anim.SetBool("isSlide", true); //�ִϸ��̼� �Ķ���� ����
            rigid.AddForce(new Vector2(rigid.velocity.x, -jumpPower * 0.6f), ForceMode2D.Impulse); //x�� ���� �״�� y�� ���� ���� y�� �� * 0.6��ŭ�� �� �ο�
        } else if(Input.GetKeyUp(KeyCode.S)) //�÷��̾ S��ư�� ������ ���� �ʴٸ�
        {
            anim.SetBool("isSlide", false); //�ִϸ��̼� �Ķ���� ����
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //�ݶ��̴��� �ٸ� �ݶ��̴��� ����� �� �ߵ�
    {
        if(collision.gameObject.tag == "ground") //�ش� �ݶ��̴��� �±׸��� ground���
        {
            canJump = true; //���� �ٽ� ����
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //�÷��̾ isTrigger ������ �ݶ��̴��� ����� �� �ߵ�
    {
        if (collision.gameObject.tag == "enemy") //�ش� �ݶ��̴��� �±׸��� enemy���
        {
            isDead = true; //����
            anim.SetBool("isDead", true); //�ִϸ��̼� �Ķ���� ����
        }
    }
}
