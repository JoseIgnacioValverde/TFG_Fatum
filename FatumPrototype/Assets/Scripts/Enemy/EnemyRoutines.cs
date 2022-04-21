using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRoutines : MonoBehaviour
{
    public NavMeshAgent agent;
    public EnemyView POV;
    public List<Transform> patrolPoints;
    public Transform playerTransform, projectileStart, BackWards;
    private Transform lastWayPoint;
    private Rigidbody selfBody;
    public ResourcesManager resources;
    public float timeBetweenPatrols = 5f, timeToReturnPatrol = 2f, timerPatrol = 0, timerSearch = 0, reloadTimer = 0, reloadSpeed = 3f, shotingDistance = 10f, maxRange = 20f;
    public bool miniStop = false, patroling = false, chasing = false, searching = false, playerDetected = false, shootReady = false, posibleShot = false;
    private int index = 0;
    public LayerMask obstacle;
    // Start is called before the first frame update
    void Start()
    {
        patroling = true;
        agent.SetDestination(patrolPoints[index].position);
        selfBody = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, playerTransform.position, Color.blue);
        DetectPlayer();
        if(playerDetected){
            FollowPlayer();
        }
        else if(patroling)
            Patrol();

        posibleShot = playerDetected && CheckAttackRange();
        if(posibleShot)
            Shoot();
        ManageTimers();
    }
    private void ChangeFocus(){
        if(!miniStop){
            
            if(agent.remainingDistance < agent.stoppingDistance){
            index ++;
            miniStop = true;
            if(index >= patrolPoints.Count)
                index = 0;
            
            }
            //UnityEngine.Debug.Log("index: "+index);
        }
        if(playerDetected){
            //UnityEngine.Debug.Log(agent.remainingDistance);
            //UnityEngine.Debug.Log(agent.remainingDistance <= shotingDistance*5.5f);
            if(agent.remainingDistance <= shotingDistance*5.5f/* && agent.remainingDistance > maxRange*5.5f*/){
                agent.isStopped = true;
                posibleShot = true;
                patroling = false;
                selfBody.velocity = Vector3.zero;
            }
                
            else{
                agent.isStopped = false;
                posibleShot = false;
                patroling = true;
            }
                
        }
    }
    private void DetectPlayer(){
        if(POV.playerDetected){
            //UnityEngine.Debug.Log(Physics.Raycast(transform.position, playerTransform.position, 100f, obstacle));
            RaycastHit hit = new RaycastHit();
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            Physics.Raycast(transform.position, playerTransform.position, out hit, distance);
            //if(hit.collider.gameObject.tag == "Player"){
                playerDetected = true;
                
            //}    
        }
        else{
            playerDetected = false;
            miniStop = true;
        }  
    }
    private void Shoot(){
        if(shootReady){
            Instantiate(Resources.Load("Projectile") as GameObject, projectileStart.position, Quaternion.identity);
            shootReady = false;
        }
        
    }
    private void Patrol(){
        agent.isStopped = false;
        if(!miniStop){
            if(agent.remainingDistance < agent.stoppingDistance){
            index ++;
            miniStop = true;
            if(index >= patrolPoints.Count)
                index = 0;
            
            }
        }
    }
    private void FollowPlayer(){
        lastWayPoint = patrolPoints[index];
        patroling = false;
        chasing = true;
        transform.LookAt(playerTransform);
        agent.SetDestination(playerTransform.position);
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if(distance < shotingDistance){
            agent.SetDestination(BackWards.position);
            agent.isStopped = false;
            selfBody.isKinematic = false;
        }
        if(distance >= shotingDistance && distance < maxRange){
            agent.isStopped = true;
            selfBody.isKinematic = true;
        }
        else
            agent.isStopped = false;
            selfBody.isKinematic = false;

    }
    private void ReturnToPatrol(){
        
        agent.SetDestination(lastWayPoint.position);
    }
    private bool CheckAttackRange(){
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        return (distance < maxRange && distance >= shotingDistance);
    }
    private void ManageTimers(){

        if(miniStop){
            timerPatrol+=Time.deltaTime;
            if(timerPatrol >timeBetweenPatrols){
                timerPatrol = 0f;
                miniStop = false;
                agent.SetDestination(patrolPoints[index].position);
                transform.LookAt(patrolPoints[index]);
            }
        }
        if(!playerDetected && chasing){
            timerSearch += Time.deltaTime;
            if(timerSearch > timeToReturnPatrol){
                timerSearch = 0f;
                chasing = false;
                agent.SetDestination(lastWayPoint.position);
            }
        }
        if(!shootReady){
            if(reloadTimer >= reloadSpeed){
                reloadTimer = 0f;
                shootReady = true;
            }
            else
                reloadTimer += Time.deltaTime;
        }
    }
}
