using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDeviceCheck : MonoBehaviour
{
    public GameObject canvas;
    void Start()
    {
#if UNITY_WEBGL_API
        canvas.SetActive(false);
#else
        canvas.SetActive(true);
#endif
    }

    void Update()
    {

    }
}
