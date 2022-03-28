using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public PlayerController controller;
    public Transform inventory;
    private bool inventoryOpen;
    private float delayOnOpen = 0.3f;
    private bool delayPassed = true;
    private float timeDelay = 0f;
    public Image maskImage;
    public Image [] skillImages;
    public Image [] passiveImages;
    public Image moveImage;
    // Start is called before the first frame update
    void Awake()
    {
        //controller = transform.Find("Player").GetComponent<PlayerController>();
        UnityEngine.Debug.Log(controller);
        inventory.gameObject.SetActive(false);
        inventoryOpen = false;
        delayPassed = true;
        //
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("OpenInventory")){
            UnityEngine.Debug.Log("Check1");
            if(controller.onInventorySlate){
                UnityEngine.Debug.Log("Check2");
                if(delayPassed){
                    if(inventoryOpen){
                        UnityEngine.Debug.Log("Check3");
                        inventory.gameObject.SetActive(false);
                        inventoryOpen = false;
                        delayPassed = false;
                        controller.canMove = true;
                        //Time.timeScale = 1f;
                    }
                    else{
                        UnityEngine.Debug.Log("Check4");
                        inventory.gameObject.SetActive(true);
                        inventoryOpen = true;
                        delayPassed = false;
                        controller.canMove = false;
                        //Time.timeScale = 0f;
                    }
                }
                controller.DisableCamera();
            }
        }
        if(!delayPassed){
            if(delayOnOpen <= timeDelay){
                timeDelay = 0f;
                delayPassed = true;
            }
            else{
                timeDelay+= Time.deltaTime;
            }
        }
    }
}
