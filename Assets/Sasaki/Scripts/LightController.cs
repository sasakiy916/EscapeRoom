using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : ItemSlot
{
    [SerializeField] Light[] roomLights;
    [SerializeField] MeshRenderer text;
    [SerializeField] RotateDoorSA door;
    void Update()
    {
        text.enabled = door.isOpen;
    }
    public override void ClickEffect()
    {
        audioSource.PlayOneShot(effectSE);
        EyeLightChange.EmissionEye();
        foreach (Light roomLight in roomLights)
        {
            roomLight.enabled = !roomLight.enabled;
        }
    }
}
