using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    private dino dino; //플레이어
    private GameManager manager; //매니저 객체

    // Start is called before the first frame update
    void Start()
    {
        dino = GameObject.Find("dino").GetComponent<dino>(); //인스펙터 상의 dino라는 오브젝트의 dino 컴포넌트 받아오기
        manager = GameObject.Find("manager").GetComponent<GameManager>(); //인스펙터 상의 manager라는 오브젝트의 GameManager 컴포넌트 받아오기
    }

    // Update is called once per frame
    void Update()
    {
        if (dino.isDead) return; //죽으면 실행 중지

        if(-40.42f > transform.position.x) //해당 위치보다 내 위치가 더 왼쪽에 있다면 (-가 높을수록 왼쪽)
        {
            transform.position = new Vector3(141.68f, 0.52f, 1); //이 위치로 강제 이동
        }

        transform.Translate(new Vector3(-manager.speed, 0, 0) * Time.deltaTime); //manager에 있는 speed 만큼 왼쪽으로 이동하는데 시간에 흐름에 따라 이동 (Time.deltaTime 없으면 순간 이동됨)
    }
}
