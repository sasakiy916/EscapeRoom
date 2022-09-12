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
    private void Start() {
        appearItem.SetActive(false);
        appearItem2.SetActive(false);
        GetComponent<AudioSource>().enabled=false;
        effect.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }
    public void OnClickObj()
    {
        Debug.Log("click");
        bool clear = ItemBox.instance.TryUseItem(clearItem);
        if (clear == true)
        {
            appearItem.SetActive(true);
            appearItem2.SetActive(true);
            GetComponent<AudioSource>().enabled=true;
            audioSource.Play();
            effect.SetActive(true);
        }
    }
}
