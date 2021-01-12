﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        //rbにRigitbodyを代入する
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    // Update is called once per frame
    //  Fixedを付けるとフレーム数を関係なくする事ができる
    void FixedUpdate()
    {
        //  moveHに左右方向の動きを代入
        float moveH = Input.GetAxis("Horizontal");
        //  movevに上下方向の動きを代入
        float moveV = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveH, 0, moveV);
        //  変数rbにmoveを入れる
        rb.AddForce(move * speed);
    }
    //アイテムに触れた瞬間に消す
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        count = count + 1;
        Debug.Log(count);
    }
}
