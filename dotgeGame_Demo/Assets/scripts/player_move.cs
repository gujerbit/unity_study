using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public float speed = 10f; //나의 이동 속도

    private Rigidbody2D rigid; //rigidbody2d 컴포넌트
    private float x = 0; //플레이어 수평 이동값
    private float y = 0; //플레이어 수직 이동값
    private bool isDead = false;

    private void Awake()
    { //스크립트 비활성화 시에도 적용
        rigid = GetComponent<Rigidbody2D>(); //현재 나한테 붙어있는 rigidbody2d 컴포넌트 받아오기
    }

    // Start is called before the first frame update
    void Start() 
    { //awake 다음에 적용
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) return;
        x = Input.GetAxis("Horizontal"); //키보드의 x축 값을 가져온다
        y = Input.GetAxis("Vertical"); //키보드의 y축 값을 가져온다

        rigid.velocity = new Vector2(x * speed, y * speed); //rigid의 속력 벡터를 나타냄. 힘을 받는 즉시 적용
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Enemy") {
            isDead = true;
            Debug.Log("GameOver");
        }
    }

    public bool PlayerDead() {
        return isDead;
    }
}
