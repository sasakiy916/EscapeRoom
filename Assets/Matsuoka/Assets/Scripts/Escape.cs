using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    [SerializeField] ClearKeys clearKeys;
    public void OnclickEscape()
    {
        //set
        PlayerPrefs.SetInt("Matsuoka", 1);
        Debug.Log("Main" + PlayerPrefs.GetInt("Matsuoka"));
        SceneManager.LoadScene("CentralRoom");
    }
}
