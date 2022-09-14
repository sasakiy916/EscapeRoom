using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGimick : MonoBehaviour
{
    [SerializeField] Item.Type clearItem;
    [SerializeField] GameObject appearItem;
    [SerializeField] GameObject appearItem2;
    [SerializeField] GameObject effect;
    AudioSource audioSource;
    private void Start()
    {
        if (appearItem != null) appearItem.SetActive(false);
        if (appearItem2 != null) appearItem2.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null) GetComponent<AudioSource>().enabled = false;
        if (effect != null) effect.SetActive(false);
    }
    public void OnClickObj()
    {
        Debug.Log("click");
        bool clear = ItemBox.instance.TryUseItem(clearItem);
        if (clear == true)
        {
            SoundManager.instance.PlaySE(SESoundData.SE.CORRECT);
            if (appearItem != null) appearItem.SetActive(true);
            if (appearItem2 != null) appearItem2.SetActive(true);
            if (audioSource != null)
            {
                audioSource.enabled = true;
                audioSource.Play();
            }
            if (effect != null) effect.SetActive(true);
        }
    }
}
