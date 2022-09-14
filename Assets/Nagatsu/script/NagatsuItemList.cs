using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NagatsuItemList : MonoBehaviour
{
    [SerializeField] NagatsuItem.Type itemtype;
    NagatsuItem nagatsuItem;
    void Start()
    {
        nagatsuItem = NagatsuItemGenerator.instance.Spawn(itemtype);
    }
    public void OnClickObj()
    {
        NagatsuItemBox.instance.SetItem(nagatsuItem);
        GetComponent<BoxCollider>().enabled = false;
    }
    public void OnClickObjSetActive()
    {
        gameObject.SetActive(false);
        OnClickObj();
    }


}
