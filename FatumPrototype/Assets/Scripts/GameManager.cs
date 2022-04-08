using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InventoryManager _manager;
    public PlayerResources _resources;
    public string currentMap;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
}
