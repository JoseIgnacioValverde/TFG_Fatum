using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform startPoint;
    public Transform endPoint;
    private Rigidbody selfBody;
    public float speed = 0.01f;
    public float height = 2f;
    private float BulletMaxLife = 15f;
    private float timer = 0;
    private LayerMask groundMask;

    void Start(){
        selfBody = transform.GetComponent<Rigidbody>();
        startPoint = transform;
        endPoint = GameObject.Find("Player").GetComponent<Transform>();
        UnityEngine.Debug.Log("endPoint"+endPoint.position);
        groundMask = LayerMask.GetMask("Ground");
        Launch();
    }
    void Awake(){

    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= BulletMaxLife){
            Destroy(this.gameObject);
        }
        //Explode();
        
        //transform.position = ParabolicShot.Parabola(startPoint.position, endPoint.position, height,speed);
    }
    void OnDrawGizmos(){
        //Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position,2.5f);
    }
    void Launch(){
        UnityEngine.Debug.Log("¡FIRE!");
        selfBody.velocity = GameManager.CalculateVelocityForParabola(transform,10f);
    }
    void Explode(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2.5f);
        for(int i = 0; i<colliders.Length; i++){
            if(colliders[i].GetComponent<PlayerResources>()){
                PlayerResources playerCont = colliders[i].GetComponent<PlayerResources>();
                UnityEngine.Debug.Log("KABOOM!");
                playerCont.TakeDamage(15f);
                Destroy(this.gameObject);
            }
        }
    }
    void OnTriggerEnter(Collider collider){
        UnityEngine.Debug.Log("COLLISION!");
        PlayerResources playerCont = GameObject.Find("Player").GetComponent<PlayerResources>();
        if(collider.gameObject.tag == "Player"){
            playerCont.TakeDamage(15f);
            UnityEngine.Debug.Log("PLAYER!");
            Destroy(this.gameObject);
        }
        else if(collider.gameObject.tag == "Ground"){
            //playerCont.TakeDamage(15f);
            //UnityEngine.Debug.Log("KABOOM!");
            Explode();
        }
    }

}
