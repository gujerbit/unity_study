using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 7f; //나의 이동 속도

    private Rigidbody2D rigid; //rigidbody2d 컴포넌트
    private Vector2 vec; //2d 벡터 (x, y)

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>(); //현재 나한테 붙어있는 rigidbody2d 컴포넌트 받아오기
    }

    // Start is called before the first frame update
    void Start()
    {
        vec = GameObject.FindGameObjectWithTag("Player").transform.position - gameObject.transform.position; //Player라는 태그를 가진 오브젝트 위치값

        StartCoroutine(SelfDie());
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(vec.normalized.x * speed, vec.normalized.y * speed); //위치값에 nomalized를 안하면 상대적인 힘이 그대로 적용됨
    }

    IEnumerator SelfDie() {
        yield return new WaitForSeconds(4);

        Destroy(gameObject);
    }
}
