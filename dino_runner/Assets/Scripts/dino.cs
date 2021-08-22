using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dino : MonoBehaviour
{
    public float jumpPower = 3f; //플레이어의 점프력
    public bool isDead = false; //플레이어 사망 여부

    private bool canJump = true; //점프를 다시 할 수 있는가? (2단 점프 방지)
    private bool gravityUp = false;

    private Rigidbody2D rigid;
    public Animator anim; //플레이어의 애니메이션 컨트롤러

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
        if (isDead) return; //죽으면 조종 불가

        if(gameObject.transform.position.y < -5) //만약 플레이어가 맵탈을 했다면
        {
            gameObject.transform.position = new Vector3(rigid.velocity.x, -3, 1); //플레이어 위치 원상복구
        }

        if(Input.GetKeyDown(KeyCode.Space) && canJump) //점프
        {
            canJump = false; //공중에서 점프 불가능하게 점프 막아놓기
            rigid.AddForce(new Vector2(rigid.velocity.x, jumpPower), ForceMode2D.Impulse); //x축 값은 그대로 y축 값에 현재 y축 값 * 5만큼의 힘 부여
            anim.SetTrigger("isJump"); //애니메이션 파라미터 설정
        }

        if(Input.GetKeyDown(KeyCode.S)) //플레이어가 S버튼을 누르고 있다면
        {
            anim.SetBool("isSlide", true); //애니메이션 파라미터 설정
            rigid.AddForce(new Vector2(rigid.velocity.x, -jumpPower * 0.6f), ForceMode2D.Impulse); //x축 값은 그대로 y축 값에 현재 y축 값 * 0.6만큼의 힘 부여
        } else if(Input.GetKeyUp(KeyCode.S)) //플레이어가 S버튼을 누르고 있지 않다면
        {
            anim.SetBool("isSlide", false); //애니메이션 파라미터 설정
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //콜라이더가 다른 콜라이더에 닿았을 때 발동
    {
        if(collision.gameObject.tag == "ground") //해당 콜라이더의 태그명이 ground라면
        {
            canJump = true; //점프 다시 가능
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //플레이어가 isTrigger 상태의 콜라이더와 닿았을 때 발동
    {
        if (collision.gameObject.tag == "enemy") //해당 콜라이더의 태그명이 enemy라면
        {
            isDead = true; //죽음
            anim.SetBool("isDead", true); //애니메이션 파라미터 설정
        }
    }
}
