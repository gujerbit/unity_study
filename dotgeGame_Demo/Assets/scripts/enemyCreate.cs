using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCreate : MonoBehaviour
{
    public Transform top;
    public Transform bottom;
    public Transform left;
    public Transform right;
    public GameObject enemy;
    public float delay = 0.5f;

    private bool createCan = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(createCan) {
            createCan = false;
            StartCoroutine(CreateEnemy());
        }
    }

    IEnumerator CreateEnemy() {
        int rndPosition = Random.Range(1, 5);
        float rndRange = Random.Range(-5, 6);
        Instantiate(enemy);

        if(rndPosition == 1) enemy.transform.position = new Vector2(top.position.x + rndRange, top.position.y);
        if(rndPosition == 2) enemy.transform.position = new Vector2(bottom.position.x + rndRange, bottom.position.y);
        if(rndPosition == 3) enemy.transform.position = new Vector2(left.position.x, left.position.y + rndRange);
        if(rndPosition == 4) enemy.transform.position = new Vector2(right.position.x, right.position.y + rndRange);

        yield return new WaitForSeconds(delay);

        createCan = true;
    }
}
