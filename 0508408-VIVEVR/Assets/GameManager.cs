using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//場景管理器API
using Valve.VR.InteractionSystem;

public class GameManager : MonoBehaviour
{
    [Header("棒球數量")]
    public Text textBallCount;
    [Header("分數")]
    public Text textScore;
    [Header("進球音效")]
    public AudioClip soundTwo;
    [Header("自我挑戰音效")]
    public AudioClip soundThree;

    private AudioSource aud;

   //紀錄 整數 球數量/分數
   private int ballCount = 9;
    private int score;

    private ThreePoint threePoint;  //欄位

    private void Start()
    {
        aud = GetComponent<AudioSource>();

        //三分球物件 =透過類型尋找物件<類型>()  當要尋找的類型場景上只有一種時適用
        threePoint = FindObjectOfType<ThreePoint>();
    }

    public void UseBall(GameObject ball)
    {
        //刪除(球.取得物件<丟>())
        //刪除(球.取得物件<互動>())
        Destroy(ball.GetComponent<Throwable>());
        Destroy(ball.GetComponent<Interactable>());

        //減數量
        ballCount--;
        //減完後並更新文字
        textBallCount.text = "棒球數量" + ballCount + " / 9";
    }
        //觸發碰撞
    private void OnTriggerEnter(Collider other)
    {

        if(threePoint.inThreePoint)
        {
            score += 30;                          //被判斷是在三分區投籃後增加的分數
            aud.PlayOneShot(soundThree, 1.5f);   // 播放音效 x1.5
        }
        else
        {
            score += 10;                         //被判斷不是在三分區進籃後增加的分數
            aud.PlayOneShot(soundTwo);
        }
       
        //分數增加後並更新文字
        textScore.text = "分數:" + score;


    }

    public void Replay()
    {
        //刪除 (玩家.遊戲物件)
        Destroy(FindObjectOfType<Player>().gameObject);
        //場景管理器.重新載入場景("場景名稱需完全一樣")
        SceneManager.LoadScene("VR場景");
    }

    public void Quit()
    {
        //應用程式.離開遊戲()   -  適用於EXE、手機
        Application.Quit();
    }

}

