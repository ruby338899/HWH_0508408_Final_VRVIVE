using UnityEngine;

public class ThreePoint : MonoBehaviour
{

    //判定進入三分區域時: true進入  false離開
    public bool inThreePoint;


    //Enter  物件進入時
    private void OnTriggerEnter(Collider other)
    {
        //如果碰到物件名稱為"xxxxxx"
        if (other.name == "HeadCollider")
        {
            inThreePoint = true;
        }
    }


    //Exit 物件離開時判定
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "HeadCollider")
        {
            inThreePoint = false;
        }
    }
}
