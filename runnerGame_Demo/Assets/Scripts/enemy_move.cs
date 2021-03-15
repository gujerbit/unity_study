using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rigid;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDie());
    }

    // Update is called once per frame
    void Update()
    {
        speed = Random.Range(5f, 11f);
        rigid.velocity = new Vector2(-1 * speed, 0);
    }

    IEnumerator SelfDie() {
        yield return new WaitForSeconds(10);

        Destroy(gameObject);
    }
}