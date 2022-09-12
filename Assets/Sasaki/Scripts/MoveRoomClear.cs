using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoomClear : MoveRoom
{
    void Start()
    {
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

    }

    void Update()
    {

    }
}
