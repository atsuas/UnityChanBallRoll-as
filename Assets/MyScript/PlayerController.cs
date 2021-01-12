using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  //シーンを操作する際に必要

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    int count;
    public Text countText;  //カウントテキストの宣言
    AudioSource getSE;

    // Start is called before the first frame update
    void Start()
    {
        //rbにRigitbodyを代入する
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        getSE = GetComponent<AudioSource>();
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
        //アイテムと落下時の壁の接触を分ける
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            getSE.Play();
        }
        else if (other.gameObject.CompareTag("Bottom"))
        {
            //シーンを読み込む際のスクリプト
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        
    }
    //メソッドを定義する
    void SetCountText()
    {
        //Tostringをつけて文字を数値に変換
        countText.text = "ゲット数:" + count.ToString();
    }
}
