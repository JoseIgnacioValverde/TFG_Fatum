using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 2f;
    public float jumpForce;
    public Cinemachine.CinemachineFreeLook _camera;
    [Space(15)]
    public float checkDistance;
    public Transform GroundCheck;
    public LayerMask GroundMask;
    public Transform playerTransform;
    public bool canJump;
    public bool canMove =true;
    public bool onInventorySlate;
    public SkillsLogic tempLogic;
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
            UnityEngine.Debug.Log("Movement = "+canMove);
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
                tempLogic.HermitSkill();
            }
        }
        

    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(GroundCheck.transform.position, checkDistance);
    }
    public void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "SaveSlot"){
            UnityEngine.Debug.Log("Check");
            onInventorySlate = true;
        }
        else{
            onInventorySlate = false;
        }
        UnityEngine.Debug.Log("On Inventory Slate = "+onInventorySlate.ToString());
    }
    public void DisableCamera(){
        if(canMove){
            _camera.m_YAxis.m_MaxSpeed = 8f;
            _camera.m_XAxis.m_MaxSpeed = 800f;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else{
            _camera.m_YAxis.m_MaxSpeed = 0;
            _camera.m_XAxis.m_MaxSpeed = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
}
