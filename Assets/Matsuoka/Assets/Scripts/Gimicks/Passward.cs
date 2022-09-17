using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passward : MonoBehaviour
{
    [SerializeField] int[] correctNumbers;
    [SerializeField] PasswardButton[] passwardButtons;
    [SerializeField] GameObject appearItem;

    void Start()
    {
        if (appearItem != null) appearItem.SetActive(false);
    }
    public void CheckClear()
    {
        if (IsClear())
        {
            Debug.Log("クリア");
            SoundManager.instance.PlaySE(SESoundData.SE.CORRECT);
            Debug.Log(passwardButtons[0].number);
            Debug.Log(passwardButtons[1].number);
            PasswardAppearItem();
        }
    }

    public void PasswardAppearItem()
    {
        if (appearItem != null) appearItem.SetActive(true);
    }

    public bool IsClear()
    {
        for (int i = 0; i < passwardButtons.Length; i++)
        {
            if (passwardButtons[i].number != correctNumbers[i])
            {
                return false;
            }
        }
        return true;
    }
}
