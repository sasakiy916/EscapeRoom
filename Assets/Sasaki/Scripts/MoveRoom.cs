using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveRoom : MonoBehaviour, IPointerClickHandler
{
    enum MovedRoom
    {
        NorthRoom,
        SouthRoom,
        Main,
        WestRoom,
        CentralRoom,
        GameClear
    }
    enum ClearCheckName
    {
        Matsuoka,
        Nagatsu,
        Nagano,
        Sasaki,
        GameClear
    }
    [SerializeField] MovedRoom nextRoom;
    [SerializeField] protected Board door;
    [SerializeField] protected Light doorLight;
    [SerializeField] protected MeshRenderer doorSphere;
    [SerializeField] protected Material lightOff;
    [SerializeField] protected Material lightOn;
    [SerializeField] ClearCheckName clearCheckKey;
    [SerializeField] Text NowLoadingText;
    void Start()
    {
        if (NowLoadingText != null) NowLoadingText.gameObject.SetActive(false);
        if (door != null && doorLight != null && doorSphere != null)
        {
            if (PlayerPrefs.GetInt(clearCheckKey.ToString()) == 1)
            {
                doorLight.enabled = true;
                doorSphere.material = lightOn;
                door.canOpen = false;
            }
            else
            {
                doorLight.enabled = false;
                doorSphere.material = lightOff;
                door.canOpen = true;
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        string roomName = nextRoom.ToString();
        if (roomName != SceneManager.GetActiveScene().name)
        {
            NowLoadingText.gameObject.SetActive(true);
            SceneManager.LoadScene(roomName);
            Debug.Log(roomName);
        }
    }
}
