using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //  カメラとプレイヤの距離を出す
        offset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    //  Lateupdateは全てのクラスのUpdateが事項された後に実行される
    void LateUpdate()
    {
        //Playerの位置を取得して、カメラの位置に代入する
        this.transform.position = player.transform.position + offset;
    }
}
