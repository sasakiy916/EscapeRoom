using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MoveRoom : MonoBehaviour,IPointerClickHandler
{
    enum MovedRoom{
        NorthRoom,
        SouthRoom,
        Main,
        WestRoom,
        CentralRoom,
        GameClear
    }
    enum ClearCheckName{
        Matsuoka,
        Nagatsu,
        Nagano,
        Sasaki,
        GameClear
    }
    [SerializeField]MovedRoom nextRoom;
    [SerializeField]protected Board door;
    [SerializeField]protected Light doorLight;
    [SerializeField]protected MeshRenderer doorSphere;
    [SerializeField]protected Material lightOff;
    [SerializeField]protected Material lightOn;
    [SerializeField]ClearCheckName clearCheckKey;
    void Start()
    {
        if(door != null && doorLight !=null && doorSphere != null){
            if(PlayerPrefs.GetInt(clearCheckKey.ToString()) == 1){
                doorLight.enabled = true;
                doorSphere.material = lightOn;
                door.canOpen = false;
            }else{
                doorLight.enabled = false;
                doorSphere.material = lightOff;
                door.canOpen = true;
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData){
        string roomName = nextRoom.ToString();
        if(roomName != SceneManager.GetActiveScene().name){
            SceneManager.LoadScene(roomName);
            Debug.Log(roomName);
        }
    }
}
