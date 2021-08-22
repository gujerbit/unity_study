using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D rigid;
    private GameManager manager; //매니저 객체
    private dino dino; //플레이어
    private float speed = 10f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        manager = GameObject.Find("manager").GetComponent<GameManager>(); //인스펙터 상의 manager라는 오브젝트의 GameManager 컴포넌트 받아오기
        dino = GameObject.Find("dino").GetComponent<dino>(); //인스펙터 상의 dino라는 오브젝트의 dino 컴포넌트 받아오기
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestroy()); //시작하자마자 코루틴 실행
    }

    // Update is called once per frame
    void Update()
    {
        if (dino.isDead) //플레이어가 죽었다면
        {
            rigid.velocity = new Vector2(0, 0); //움직이지 않도록 설정
            return;
        }
        //rigid.velocity = new Vector2(-manager.speed, rigid.velocity.y); //계속 왼쪽으로 이동
        rigid.velocity = new Vector2(speed, rigid.velocity.y); //계속 왼쪽으로 이동 manager 안쓰는 버전 대신 위에 float 형으로 speed 정의해줘야함
    }

    IEnumerator SelfDestroy() //오브젝트가 계속 남아있는것을 방지하기 위한 코드
    {
        yield return new WaitForSeconds(5); //5초 후

        if (!dino.isDead) //플레이어가 살아있다면
        {
            Destroy(gameObject); //자기 자신 삭제
        }
    }
}
