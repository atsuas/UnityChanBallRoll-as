using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalChecker : MonoBehaviour
{
    public GameObject unityChan;
    public AudioSource gameBgm;     //プレイ中のBGMを代入
    public AudioSource goalBgm;     //ゴール後のBGMを代入
    public GameObject retryButton;  //ボタンを代入するpublic変数

    // Start is called before the first frame update
    void Start()
    {
        retryButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Goalで止まる処理
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        unityChan.transform.LookAt(Camera.main.transform);
        unityChan.GetComponent<Animator>().SetTrigger("Goal");

        gameBgm.Stop();
        goalBgm.Play();

        retryButton.SetActive(true);
    }

    public void RetryStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
