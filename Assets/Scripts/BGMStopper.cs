using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMStopper : MonoBehaviour
{
    void Start()
    {
        SoundManager.instance.StopBGM();
    }
}
