using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passward : MonoBehaviour
{
    [SerializeField] int[] correctNumbers;
    [SerializeField] PasswardButton[] passwardButtons;
    public void CheckClear()
    {
        if (IsClear())
        {
            Debug.Log("クリア");
            Debug.Log(passwardButtons[0].number);
            Debug.Log(passwardButtons[1].number);
        }
    }

    bool IsClear()
    {
        if (passwardButtons[0].number == correctNumbers[0] &&
            passwardButtons[1].number == correctNumbers[1] &&
            passwardButtons[2].number == correctNumbers[2] &&
            passwardButtons[3].number == correctNumbers[3])
        {
            return true;
        }
        return false;
    }
}
