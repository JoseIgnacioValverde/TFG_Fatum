using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InventoryManager _manager;
    public PlayerResources _resources;
    public SaveDataManager _dataManager;
    public string currentMap;
    private float gravity = -9.8f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _dataManager.LoadInventory();
//        _dataManager.LoadPlayer();
        _manager.SetAllImages();
    }
    void Awake(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveGameData(){
        SaveDataManager.SaveData(currentMap, _resources.health.ToString(), _resources.mana.ToString(), 
        _resources.self.position.x,_resources.self.position.y,_resources.self.position.z, _manager.allSlots, 
        _manager.mainSkill1.skillName, _manager.mainSkill2.skillName, _manager.mainSkill3.skillName, _manager.mainSkill4.skillName, _manager.mainSkill5.skillName, 
        _manager.pasiveSkill1.skillName, _manager.pasiveSkill2.skillName, _manager.maskSkill.skillName, _manager.movSkill.skillName);
    }
    public static Vector3 CalculateVelocityForParabola(Transform bola, float height){
        float gravity = -9.8f;
        //Transform playerTransform = GameObject.Find("Player").transform.GetChild(0).GetComponent<Transform>();
        Transform playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        float movementY = playerTransform.position.y - bola.position.y;
        if(movementY<0){
            movementY = 1-movementY;
        }
        //UnityEngine.Debug.Log("VelocityH: "+movementY);
        Vector3 movementXZ = new Vector3(playerTransform.position.x - bola.position.x, 0, playerTransform.position.z - bola.position.z);
        //UnityEngine.Debug.Log("VelocityMov: "+movementXZ);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2*gravity*height);
        //UnityEngine.Debug.Log("VelocityY: "+velocityY);
        Vector3 velocityXZ = movementXZ / (Mathf.Sqrt(-2*height/gravity) + Mathf.Sqrt(2*(movementY - height)/gravity));
        //UnityEngine.Debug.Log("VelocityBoom: "+movementXZ / (Mathf.Sqrt(-2*height/gravity)));
        //UnityEngine.Debug.Log("VelocityBoom2: "+Mathf.Sqrt(2*movementY - height)/gravity);
        //UnityEngine.Debug.Log("VelocityXZ: "+velocityXZ);
        return (velocityXZ + velocityY);
    }
}
