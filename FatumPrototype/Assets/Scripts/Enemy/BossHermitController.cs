using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHermitController : MonoBehaviour
{
    public List<Transform> TeleportZones = new List<Transform>();
    public Transform playerTransform, groundTransform, projectileCreator;
    private Transform Attack;
    public int hits = 3;
    public int maxShots = 1;
    private int remainingShots;
    private float AttackToExecute = -1f, TimeBetweenAttacks = 5f, TimeBetweenTeleports = 15f, TimerTeleport = 0, TimerAttack =0, TeleportingTime = 0.5f, TimerOnAttack = 0, TimeAttacking = 1f;
    private bool Teleporting, Attacking, AttackSecuence, TeleportOnCooldown, AttacksOnCooldown;
    private int TeleportIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        TeleportOnCooldown = true;
        AttacksOnCooldown = true;
        Teleporting = false;
        Attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerTransform);
        if(!Attacking){
            if(TeleportOnCooldown){
                TimerTeleport += Time.deltaTime;
            if(TimerTeleport >=TimeBetweenTeleports){
                TimerTeleport = 0f;
                TeleportOnCooldown = false;
            }
            

        }
            else{
                Teleporting = true;
                Teleport();
            }
        }
        if(!Teleporting){
            if(AttacksOnCooldown){
                TimerAttack +=Time.deltaTime;
                if(TimerAttack >= TimeBetweenAttacks)
                {
                    TimerAttack = 0f;
                    AttacksOnCooldown = false;
                    remainingShots = maxShots;
                    Attacking = true;
                }
            }
            if(Attacking){
                TimerOnAttack += Time.deltaTime;
                if(TimerOnAttack >= TimeAttacking){
                    float rng = Random.Range(0f,1f);
                    if(rng <=0.1){
                        AttackBall();
                    }
                    else{
                        AttackLightning();
                    }
                    
                    TimerOnAttack = 0;
                }
                if(remainingShots < 1){
                    Attacking = false;
                    AttacksOnCooldown = true;
                }
            }
        }
        


    }
    public void Teleport(){
        int index;
        do{
            index = Random.Range(0, TeleportZones.Count);
        }while(index == TeleportIndex);

        transform.position = TeleportZones[index].position;
        TeleportIndex = index;
        TeleportOnCooldown = true;
        Teleporting = false;
    }
    public void AttackLightning(){
        
        Vector3 realPosition = new Vector3(0,0,0);
        Attack = playerTransform;
        realPosition = new Vector3(Attack.position.x, groundTransform.position.y, Attack.position.z);
        Instantiate(Resources.Load("LightningCombo") as GameObject, realPosition, Quaternion.identity);
        //Attacking = false;
        remainingShots --;
    }
    public void AttackBall(){
        Instantiate(Resources.Load("BossBall") as GameObject, projectileCreator.position, Quaternion.identity);
        remainingShots = 0;
    }
    public void TakeHit(){
        if(hits >0){
            hits--;
        }
    }
        
}
