using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //BGM,SEのオーディオソース
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;

    //各種AudioClip登録用リスト
    [SerializeField] List<BGMSoundData> bgmSoundDatas;
    [SerializeField] List<SESoundData> seSoundDatas;

    //各種オーディオボリューム
    public float masterVolume = 1;
    public float bgmMasterVolume = 1;
    public float seMasterVolume = 1;

    //シングルトン化
    public static SoundManager instance { get; private set; }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (SoundManager.instance.bgmAudioSource.isPlaying) SoundManager.instance.StopBGM();
            //既に別のサウンドマネージャーが存在する場合は消す
            Destroy(gameObject);
        }
    }

    //デバッグ用表記
    void Update()
    {
        if (Input.GetKeyDown("a")) SoundManager.instance.PlaySE("正解");
    }
    //デバッグここまで

    //音源再生 関数
    //BGM
    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);//リストから指定BGMを取得
        bgmAudioSource.clip = data.audioClip;//AudioSourceにAudioClip設定
        bgmAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;//音量設定
        bgmAudioSource.Play();//BGM再生
    }
    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }
    //SE
    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.se == se);//リストから指定SEを取得
        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;//音量設定
        seAudioSource.PlayOneShot(data.audioClip);//SEを一回再生
    }

    //テスト中(enum型の代わりにstring型でリストから探す)
    public void PlaySE(string se)
    {
        SESoundData data = seSoundDatas.Find(data => data.name == se);//リストから指定SEを取得
        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;//音量設定
        seAudioSource.PlayOneShot(data.audioClip);//SEを一回再生
    }
}

//BGMデータのクラス
[System.Serializable]
public class BGMSoundData
{
    public enum BGM
    {
        TITLE,
    }
    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)] public float volume = 1.0f;
}

//SEデータのクラス
[System.Serializable]
public class SESoundData
{
    public enum SE
    {
        CORRECT,
        ClickStart,
    }
    public string name;
    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)] public float volume = 1.0f;
}
