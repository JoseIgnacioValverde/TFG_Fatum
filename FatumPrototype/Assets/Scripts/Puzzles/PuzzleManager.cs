using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<PressurePlate> switches;
    public Transform platform;
    public int puzzleType;
    public float timer, movingDistance1, movingDistance2, lowerDistance, modifier;
    public float speed =5f, timeToMove = 2f;
    private bool allPressurePlatesPressed;
    // Start is called before the first frame update
    void Start()
    {
        allPressurePlatesPressed = false;
        switch(puzzleType){
            case 0:
                movingDistance1 = platform.position.y;
                movingDistance2 = platform.position.y -lowerDistance*modifier;
            break;
            case 1:
                movingDistance1 = platform.position.x;
                movingDistance2 = platform.position.x -lowerDistance*modifier;
            break;
            case 2:
                movingDistance1 = platform.position.z;
                movingDistance2 = platform.position.z -lowerDistance*modifier;
            break;
            default:
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(puzzleType){
            case 0:
            if(!allPressurePlatesPressed){
                CheckAllPlates();
                
            }
            else{
                if(platform.position.y >= movingDistance2){
                    LowerDoor();
                }
            }
            break;
            case 1:
                if(!allPressurePlatesPressed){
                    CheckAllPlates();
                }
                else{
                    if(platform.position.x >= movingDistance2){
                        LowerDoor();
                    }
                }
            break;
            case 2:
                if(!allPressurePlatesPressed){
                    CheckAllPlates();
                }
                else{
                    if(platform.position.z >= movingDistance2){
                        LowerDoor();
                    }
                }
            break;
            default:
            break;
        }
    }
    private void CheckAllPlates(){
        bool allPressed = true;
        foreach(PressurePlate plate in switches){
            if(plate.activated == false)
                allPressed = false;
        }
        allPressurePlatesPressed = allPressed;
        
    }
    private void LowerDoor(){
         switch(puzzleType){
            case 0:
                Vector3 a = platform.position;
                Vector3 b = new Vector3(platform.position.x, movingDistance2, platform.position.z);
                platform.position = Vector3.MoveTowards(a, Vector3.Lerp(a,b,timeToMove), speed);
            break;
            case 1:
                Vector3 c = platform.position;
                Vector3 d = new Vector3(movingDistance2, platform.position.y, platform.position.z);
                platform.position = Vector3.MoveTowards(c, Vector3.Lerp(c,d,timeToMove), speed);
            break;
            case 2:
                Vector3 e = platform.position;
                Vector3 f = new Vector3(platform.position.x, platform.position.y, movingDistance2);
                platform.position = Vector3.MoveTowards(e, Vector3.Lerp(e,f,timeToMove), speed);
            break;
            default:
            break;
        }
    }
}


