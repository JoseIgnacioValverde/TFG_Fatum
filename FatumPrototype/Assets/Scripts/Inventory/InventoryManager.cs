using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public PlayerController controller;
    public Transform inventory;
    private bool inventoryOpen, canMove;
    public Transform itemSelectedTransform;
    public InventorySlot itemSelected;
    private float delayOnOpen = 0.3f, delayOnMoving = 0.2f;
    private bool delayPassed = true, delayMovePassed = true;
    private float timeDelay1 = 0f, timeDelay2 = 0f;
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
    void Start(){
        itemSelectedTransform = inventory.transform.GetChild(2).transform.GetChild(0);
        itemSelected = itemSelectedTransform.GetComponent<InventorySlot>();
        itemSelected.active = true;
        UnityEngine.Debug.Log(inventory.transform.GetChild(2).transform.GetChild(0));
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
                        canMove = false;
                        //Time.timeScale = 1f;
                    }
                    else{
                        UnityEngine.Debug.Log("Check4");
                        inventory.gameObject.SetActive(true);
                        inventoryOpen = true;
                        delayPassed = false;
                        controller.canMove = false;
                        canMove = true;
                        //Time.timeScale = 0f;
                    }
                }
                controller.DisableCamera();
            }
        }
        if(!delayPassed){
            if(delayOnOpen <= timeDelay1){
                timeDelay1 = 0f;
                delayPassed = true;
            }
            else{
                timeDelay1+= Time.deltaTime;
            }
        }
        if(!delayMovePassed){
            if(delayOnMoving <= timeDelay2){
                timeDelay2 = 0f;
                delayMovePassed = true;
            }
            else{
                timeDelay2+= Time.deltaTime;
            }
        }
    }
    void FixedUpdate(){
        if(canMove && delayMovePassed){
            if(Input.GetKey(KeyCode.W)){
                MoveUp();
                delayMovePassed = false;
            }
            if(Input.GetKey(KeyCode.A)){
                MoveLeft();
                delayMovePassed = false;
            }
            if(Input.GetKey(KeyCode.S)){
                MoveDown();
                delayMovePassed = false;
            }
            if(Input.GetKey(KeyCode.D)){
                MoveRight();
                delayMovePassed = false;
            }
        }
    }
    public void MoveLeft(){
        itemSelected.active = false;
        itemSelectedTransform = itemSelected.itemLeft;
        itemSelected = itemSelectedTransform.GetComponent<InventorySlot>();
        itemSelected.active = true;
    }
    public void MoveRight(){
        itemSelected.active = false;
        itemSelectedTransform = itemSelected.itemRight;
        itemSelected = itemSelectedTransform.GetComponent<InventorySlot>();
        itemSelected.active = true;
    }
    public void MoveUp(){
        itemSelected.active = false;
        itemSelectedTransform = itemSelected.itemUp;
        itemSelected = itemSelectedTransform.GetComponent<InventorySlot>();
        itemSelected.active = true;
    }
    public void MoveDown(){
        itemSelected.active = false;
        itemSelectedTransform = itemSelected.itemDown;
        itemSelected = itemSelectedTransform.GetComponent<InventorySlot>();
        itemSelected.active = true;
    }
}
