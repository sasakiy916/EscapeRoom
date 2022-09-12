using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public string loadScene;//遷移先シーンの名前

    void Start()
    {
        //BGM再生
        SoundManager.instance.PlayBGM(BGMSoundData.BGM.TITLE);
    }
    void Update()
    {
        //デバッグ用の処理
        if (Input.GetKeyDown("a")) SoundManager.instance.PlaySE(SESoundData.SE.ClickStart);
        if (Input.GetKeyDown("b")) SoundManager.instance.PlaySE(SESoundData.SE.CORRECT);
    }

    //シーン遷移 関数
    public void MoveScene()
    {
        StartCoroutine(SECoroutine());
    }

    //画面クリックで音鳴らした後シーン遷移 コルーチン
    IEnumerator SECoroutine()
    {
        SoundManager.instance.PlaySE(SESoundData.SE.ClickStart);//SE再生
        // audioSource.PlayOneShot(clickSE);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(loadScene);//シーン遷移
    }
}
