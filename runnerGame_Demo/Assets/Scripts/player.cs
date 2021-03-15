using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float jumpForce = 100f;

    private Rigidbody2D rigid;
    private bool enableJump = true;
    private bool isDead = false;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) return;

        if(enableJump && Input.GetKeyDown("space")) {
            enableJump = false;
            rigid.velocity = new Vector2(0, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "background") {
            enableJump = true;
        } else if(col.gameObject.tag == "enemy") {
            isDead = true;
        }
    }

    public bool DeadStatus() {
        return isDead;
    }
}
