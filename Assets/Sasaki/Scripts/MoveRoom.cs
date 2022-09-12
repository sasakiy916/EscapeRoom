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
        EastRoom,
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
    [SerializeField]Board door;
    [SerializeField]Light doorLight;
    [SerializeField]MeshRenderer doorSphere;
    [SerializeField]Material lightOff;
    [SerializeField]Material lightOn;
    [SerializeField]ClearCheckName clearCheckKey;
    void Start()
    {
        if(door != null && doorLight !=null && doorSphere != null){
            if(
                PlayerPrefs.GetInt("Nagano") == 1 &&
                PlayerPrefs.GetInt("Nagatsu") == 1 &&
                PlayerPrefs.GetInt("Sasaki") == 1 &&
                PlayerPrefs.GetInt("Matsuoka") == 1
                ){
                    Debug.Log("クリアしたよーーーーｊ");
                    doorLight.enabled = true;
                    doorSphere.material = lightOn;
                    door.canOpen = true;
                    return;
            }else{
                    Debug.Log("まだ開かないンゴ");
                    doorLight.enabled = false;
                    doorSphere.material = lightOff;
                    door.canOpen = false;
                    return;
            }
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
