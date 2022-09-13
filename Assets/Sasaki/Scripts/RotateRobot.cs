using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRobot : MonoBehaviour
{
    [Header("回転速度")]
    public float rotSpeed;
    [Header("ヒントアイテム")]
    public GameObject hintItem;
    public Transform hintItemStartPos;
    public Transform hintItemEndPos;
    [Header("デバッグ用表記")]
    [SerializeField] bool isClear;//クリア判定

    //ヒントアイテムのアニメーション用
    float time = 0;
    float distance;

    //シングルトン化
    public static RotateRobot instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        //ヒントアイテムの移動開始→終了位置の距離計算
        distance = Vector3.Distance(hintItemStartPos.position, hintItemEndPos.position);
    }

    void Update()
    {
        //謎をクリアするまで回転する(止まる時に正面向いて止まるようにしてる)
        if (!isClear || Mathf.Abs(transform.eulerAngles.y) > 0.1f)
        {
            transform.Rotate(0, rotSpeed, 0);
        }
        else
        {
            //特定の謎クリアでヌルっとヒントアイテムが出てくる
            float t = (time * 1.0f);
            hintItem.transform.position = Vector3.Lerp(hintItemStartPos.position, hintItemEndPos.position, time);
            time += Time.deltaTime;
        }
    }

    //関数
    //クリア判定
    public void ClearCheck()
    {
        isClear = true;
    }
}
