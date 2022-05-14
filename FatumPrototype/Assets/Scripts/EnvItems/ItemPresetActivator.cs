using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPresetActivator : MonoBehaviour
{
    public GameObject itemToActivate;
    public List<GameObject> itemsToGetActive;
    public GameObject platform;
    public bool activateItem;
    // Start is called before the first frame update
    void Start()
    {
        itemToActivate.SetActive(false);
        platform.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckItemActive();
        itemToActivate.SetActive(activateItem);
    }
    private void CheckItemActive(){
        foreach(GameObject objeto in itemsToGetActive){
            if(objeto.active == false){
                return;
            }
        }
        activateItem = true;
        platform.SetActive(true);
    }
}
