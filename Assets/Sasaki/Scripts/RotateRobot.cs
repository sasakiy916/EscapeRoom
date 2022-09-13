using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRobot : MonoBehaviour
{
    public float rotSpeed;
    public bool isClear;
    public GameObject hintItem;
    public Transform hintItemStartPos;
    public Transform hintItemEndPos;
    // [Range(0, 1)] public float t;
    float time = 0;
    float distance;
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
        distance = Vector3.Distance(hintItemStartPos.position, hintItemEndPos.position);
    }

    void Update()
    {
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
    public void ClearCheck()
    {
        isClear = true;
    }
}
