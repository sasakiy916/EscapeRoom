using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingText : MonoBehaviour
{
    Text textComponent;//Textコンポーネント
    [SerializeField] float flashingSpeed = 1;//点滅スピード
    float time;//経過時間
    void Start()
    {
        textComponent = GetComponent<Text>();
    }
    void Update()
    {
        //TextのColorプロバティのalpha値を0~1の間で変化させる
        float a = Mathf.Sin(flashingSpeed * time);
        time += Time.deltaTime;
        Debug.Log("alpha:" + a);
        textComponent.color = new Color(textComponent.color.r, textComponent.color.b, textComponent.color.g, Mathf.Abs(a));
    }
}
