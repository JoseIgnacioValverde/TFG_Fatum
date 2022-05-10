using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<PressurePlate> switches;
    public Transform platform;
    public float timer, movingDistance1, movingDistance2, puzzleType, lowerDistance, modifier;
    public float speed =5f, timeToMove = 2f;
    private bool allPressurePlatesPressed;
    // Start is called before the first frame update
    void Start()
    {
        allPressurePlatesPressed = false;
        movingDistance1 = platform.position.y;
        movingDistance2 = platform.position.y -lowerDistance*modifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(!allPressurePlatesPressed){
            CheckAllPlates();
        }
        else{
            if(platform.position.y >= movingDistance2){
                LowerDoor();
            }
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
        Vector3 a = platform.position;
        Vector3 b = new Vector3(platform.position.x, movingDistance2, platform.position.z);
        platform.position = Vector3.MoveTowards(a, Vector3.Lerp(a,b,timeToMove), speed);
    }
}
