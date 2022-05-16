using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBall : MonoBehaviour
{
    public float maxSpeed = 5f, time = 10f;
    public Rigidbody selfBody;
    public Transform player;
    public Transform boss;
    private Transform targetTransform;
    private bool TargetingPlayer, TargetingBoss;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        boss = GameObject.Find("Boss").GetComponent<Transform>();
        targetTransform = player;
        TargetingPlayer = true;
        TargetingBoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        //selfBody.MovePosition(player.position);
    }
    void FixedUpdate(){
        /*Vector3 f = player.position - transform.position;
        f = f.normalized;
        f = f*force;
        selfBody.AddForce(f);*/
        Vector3 a = transform.position;
        Vector3 b = targetTransform.position;
        transform.position = Vector3.MoveTowards(a, Vector3.Lerp(a,b,time), maxSpeed);
    }
    void OnCollisionEnter(Collision collision){
        if(collision.collider.transform.GetComponent<MirrorWall>()){
            targetTransform = boss;
            TargetingPlayer = false;
            TargetingBoss = true;
        }
        if(collision.collider.transform.GetComponent<PlayerResources>()){
            if(TargetingPlayer){
                collision.collider.transform.GetComponent<PlayerResources>().TakeDamage(10f);
                Destroy(this.gameObject);
            }
            
        }
        if(collision.collider.transform.GetComponent<BossHermitController>()){
            if(TargetingBoss){
                collision.collider.transform.GetComponent<BossHermitController>().TakeHit();
                Destroy(this.gameObject);
            }
            
        }
        else{
            if(TargetingPlayer)
                Destroy(this.gameObject);
        }
    }
}
