using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_create : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public Transform point;

    public float delay = 1f;

    private bool isCreate = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isCreate) {
            isCreate = false;
            StartCoroutine(CreateEnemy());
        }
    }

    IEnumerator CreateEnemy() {
        delay = Random.Range(1f, 2.5f);
        int selectEnemy = Random.Range(1, 4);

        if(selectEnemy == 1) {
            Instantiate(enemy1);
            enemy1.transform.position = new Vector2(point.position.x, point.position.y);
        } else if(selectEnemy == 2)
        {
            Instantiate(enemy2);
            enemy2.transform.position = new Vector2(point.position.x, point.position.y);
        } else if(selectEnemy == 3)
        {
            Instantiate(enemy3);
            enemy3.transform.position = new Vector2(point.position.x, point.position.y);
        }

        yield return new WaitForSeconds(delay);

        isCreate = true;
    }
}