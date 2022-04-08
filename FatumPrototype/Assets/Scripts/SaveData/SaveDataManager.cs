using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class SaveDataManager : MonoBehaviour
{
    static  string path = "";
    static string fileName = "";
    static string fullPath = "";
    public string confirmPath = "";
    public InventoryManager _manager;
    public PlayerResources _resources;
    public string currentMap;
    public Vector3 spawnPosition;
    void Start(){
        path = Application.persistentDataPath;
        fileName = "/mainSaveFile.txt";
        fullPath = path + fileName;
        confirmPath = fullPath;
    }
    public static bool GameDataFileExists()
    {
        return File.Exists(fullPath);
    }
    public static void DeleteDataFile()
    {
        File.Delete(fullPath);
    }
    public void SaveData(){
        UnityEngine.Debug.Log("Saving Game");
        File.WriteAllText(fullPath, string.Empty);
        StreamWriter writer = new StreamWriter(fullPath, false);

        string currentLevel = "CurrentLevel:" + currentMap;
        string playerHealth = "PlayerHealth:"+ _resources.health;
        string playerMana = "PlayerMana:"+ _resources.mana;
        string Coords = "Coords:"+_resources.self.position.x+","+_resources.self.position.y+","+_resources.self.position.z;
        string itemsState = "Items:";
        string mainSkills = "MainSkillEquiped:"+_manager.mainSkill1.skillName+","+_manager.mainSkill2.skillName+","+_manager.mainSkill3.skillName+","+_manager.mainSkill4.skillName
        +","+_manager.mainSkill5.skillName;
        string pasiveSkillsEquiped = "PasiveSkillsEquiped:"+_manager.pasiveSkill1.skillName+","+_manager.pasiveSkill2.skillName;
        string maskEquiped = "MaskEquiped:"+_manager.maskSkill.skillName;
        string movEquiped = "MovementEquiped:"+_manager.movSkill.skillName;
        
        List<InventorySlot> tempSlot = _manager.allSlots;
        for(int i = 0; i< tempSlot.Count; i++){
            itemsState += tempSlot[i].skillName + "," + tempSlot[i].unlocked +",";
        }
        if(itemsState[itemsState.Length-1].ToString().Equals(","))
            itemsState = itemsState.Substring(0, itemsState.Length - 1);

        writer.WriteLine(currentLevel);
        writer.WriteLine(playerHealth);
        writer.WriteLine(playerMana);
        writer.WriteLine(Coords);
        writer.WriteLine(itemsState);
        writer.WriteLine(mainSkills);
        writer.WriteLine(pasiveSkillsEquiped);
        writer.WriteLine(maskEquiped);
        writer.WriteLine(movEquiped);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadInventory(){
        //unlocked skills and skills in positions
        string line;
        List<string> itemName = new List<string>();
        List<string> itemUnlocked = new List<string>();
        string _mainSkill1 = "";
        string _mainSkill2 = "";
        string _mainSkill3= "";
        string _mainSkill4= "";
        string _mainSkill5= "";
        string _passiveSkill1= "";
        string _passiveSkill2= "";
        string _mask= "";
        string _movement= "";
        StreamReader file = new StreamReader(fullPath);
        while((line = file.ReadLine())!= null){
            string[] word = line.Split(':');
            if(word[0]== "Items"){
                string [] auxiliar = word[1].Split(',');
                for(int i = 0; i< auxiliar.Length; i++){
                    //Cero o par deberian ser las posiciones de los nombres de los objetos
                    if(i == 0 || i%2 == 0){
                        itemName.Add(auxiliar[i]);
                    }
                    else{
                        itemUnlocked.Add(auxiliar[i]);
                    }
                }
            }
            if(word[0] =="MainSkillEquiped"){
                string[] auxiliar = word[1].Split(',');
                _mainSkill1 = auxiliar[0];
                _mainSkill2 = auxiliar[1];
                _mainSkill3 = auxiliar[2];
                _mainSkill4 = auxiliar[3];
                _mainSkill5 = auxiliar[4];
            }
            if(word[0] == "PasiveSkillsEquiped"){
                string[] auxiliar = word[1].Split(',');
                _passiveSkill1 = auxiliar[0];
                _passiveSkill2 = auxiliar[1];
            }
            if(word[0] == "MaskEquiped"){
                _mask = word[1];
            }
            if(word[0] == "MovementEquiped"){
                _movement = word[1];
            }
        }
        _manager.maskSkill.skillName = _mask;
        _manager.movSkill.skillName = _movement;
        _manager.mainSkill1.skillName =_mainSkill1;
        _manager.mainSkill2.skillName=_mainSkill2;
        _manager.mainSkill3.skillName=_mainSkill3;
        _manager.mainSkill4.skillName=_mainSkill4;
        _manager.mainSkill5.skillName=_mainSkill5;
        for(int i = 0; i< _manager.allSlots.Count; i++){
            int index = itemName.IndexOf(_manager.allSlots[i].skillName);
            _manager.allSlots[i].skillName = itemName[index];
            _manager.allSlots[i].unlocked = bool.Parse(itemUnlocked[index]);
        }
        
    }
    public void LoadPlayer(){
        string line;
        string pHealth = "";
        string pMana = "";
        string xCoord = "";
        string yCoord = "";
        string zCoord = "";
        StreamReader file = new StreamReader(fullPath);
        while((line = file.ReadLine())!=null){
            string[] word = line.Split(':');
            if(word[0]=="PlayerHealth"){
                pHealth = word[1];
                break;
            }
            if(word[0] == "PlayerMana"){
                pMana = word[1];
            }
            if(word[0] == "Coords"){
                string[] coordinates = word[1].Split(',');
                xCoord = coordinates[0];
                yCoord = coordinates[1];
                zCoord = coordinates[2];
            }
        }
        file.Close();
        //para asegurar que los floats están en el formato que queremos usamos el System.Globalization.NumberStyles
        _resources.health = float.Parse(pHealth, System.Globalization.NumberStyles.Float, new System.Globalization.CultureInfo("en-US"));
        _resources.mana = float.Parse(pMana, System.Globalization.NumberStyles.Float, new System.Globalization.CultureInfo("en-US"));
        float x = float.Parse(xCoord, System.Globalization.NumberStyles.Float, new System.Globalization.CultureInfo("en-US"));
        float y = float.Parse(yCoord, System.Globalization.NumberStyles.Float, new System.Globalization.CultureInfo("en-US"));
        float z = float.Parse(zCoord, System.Globalization.NumberStyles.Float, new System.Globalization.CultureInfo("en-US"));
        _resources.self.position = new Vector3(x,y,z);
    }
    public void LoadActualLevel(){
        string line;
        string stage = "";
        StreamReader file = new StreamReader(fullPath);
        while((line = file.ReadLine())!= null){
            string[] word = line.Split(':');
            if(word[0]=="CurrentLevel"){
                stage = word[1];
                break;
            }
        }
        file.Close();
    }
}