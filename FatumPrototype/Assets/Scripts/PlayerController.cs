using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 2f;
    public float jumpForce;
    public PlayerResources resources;
    public Cinemachine.CinemachineFreeLook _camera;
    [Space(15)]
    public float checkDistance;
    public Transform GroundCheck;
    public LayerMask GroundMask;
    public Transform playerTransform;
    public bool canJump;
    public bool canMove =true, saved = false, mainSkillOnCooldown =false;
    public bool onInventorySlate;
    public SkillsLogic tempLogic;
    public SkillManager skillMan;
    public GameManager dataManager;
    public bool clone;
    private float innterTimmer, checkpassives = 5f, skillTimer, skillCooldown = 1f; 

    // Start is called before the first frame update
    void Awake(){
        tempLogic = GameObject.Find("SkillManager").GetComponent<SkillsLogic>();
    }
    void start(){
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb =GetComponent<Rigidbody>();
            //UnityEngine.Debug.Log("Movement = "+canMove);
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            //Movement
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0;
            forward.Normalize();
            Vector3 right = Camera.main.transform.right;
            right.y = 0;
            right.Normalize();
        if(canMove){
            Vector3 direction = forward * vertical + right * horizontal;

            rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z *speed);

            //Rotation
            if(direction != Vector3.zero){
                playerTransform.rotation = Quaternion.LookRotation(direction);
            }
        }
        

    }
    public void Update(){
        canJump = Physics.CheckSphere(GroundCheck.position, checkDistance, GroundMask);
        if(canJump && canMove && Input.GetButton("Jump")){
            rb.velocity = Vector3.up * jumpForce;
        }
        if(!onInventorySlate){
            if(Input.GetButton("Fire1")){
                if(!clone){
                    if(resources.mana >= resources.mainSkill.Cost&&!mainSkillOnCooldown){
                        skillMan.UsePrimarySkill(resources.mainSkill.Name);
                        resources.ConsumeMana(resources.mainSkill.Cost);
                        mainSkillOnCooldown = true;
                    }
                }
                else{
                    if(!mainSkillOnCooldown){
                        tempLogic.HermitSkill();
                        mainSkillOnCooldown = true;
                }
                    }
                       
            }
        }
        if(!clone){
            if(innterTimmer >= checkpassives){
                if(resources.passiveSkills[0].Name == "Lovers"||resources.passiveSkills[1].Name == "Lovers"){
                    skillMan.UsePassiveSkill("Lovers");
                }
                innterTimmer = 0f;
            }
            else{
                innterTimmer+= Time.deltaTime;
            }
        }
        if(mainSkillOnCooldown){
            if(skillTimer >= skillCooldown){
                mainSkillOnCooldown = false;
                skillTimer = 0;
            }
            else{
                skillTimer+= Time.deltaTime;
            }
        }
        

    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(GroundCheck.transform.position, checkDistance);
    }
    public void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "SaveSlot"){
            onInventorySlate = true;
        }
        else{
            onInventorySlate = false;
        }
    }
    public void DisableCamera(){
        if(canMove){
            _camera.m_YAxis.m_MaxSpeed = 8f;
            _camera.m_XAxis.m_MaxSpeed = 800f;
        }
        else{
            _camera.m_YAxis.m_MaxSpeed = 0;
            _camera.m_XAxis.m_MaxSpeed = 0;
        }
        
    }
    public void ChangeSkillsActive(Skill _moveSkill, Skill _mask, Skill[] pasives){
        resources.passiveSkills[0] = pasives[0];
        resources.passiveSkills[1] = pasives[1];
        resources.movementSkill = _moveSkill;
        resources.mask = _mask;
        
    }
    public void ChangeMainSkill(Skill _mainSkill){
        resources.mainSkill = _mainSkill;
    }
}
