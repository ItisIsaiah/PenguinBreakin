using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{
  //  bool running;
   
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float smoothTurn = .5f;
    public Animator animator;
  

    PlayerControls controls;
   
    public Transform cam;
    float turnSmoothVelocity;
    Vector2 move;
    Rigidbody rb;
    public Transform swingPoint;
    public float swingRange;
    public LayerMask enemyLayers;
    GameManager gm;
    Vector3 direction;
    public float health=100;

    public GameObject captureBall;


    public CinemachineFreeLook thirdP;
    public CinemachineFreeLook spinView;

    public Transform[] groundPoints;
    public float jumpVelocity = 2f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier=2;
    public float groundRadius=.5f;
    bool isJumpPressed;
    bool isGrounded;
    public LayerMask ground;
    // Start is called before the first frame update
    
    void OnEnable()
    {
        CameraSwitcher.Register(thirdP);
        CameraSwitcher.Register(spinView);
        controls.Enable();
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        CameraSwitcher.SwitchCamera(thirdP);
        //controls.Controller.Walk.performed += ctx => { move = ctx.action.IsPressed() ? ctx.ReadValue<Vector2>() : Vector2.zero; Debug.Log(ctx.action.IsPressed()); };
        controls.Controller.Walk.performed += ctx => move= ctx.ReadValue<Vector2>();
        controls.Controller.Walk.canceled += ctx => move = Vector3.zero;
        controls.Controller.Swing.performed += Swing;
        controls.Controller.Jump.performed += Jump;
        controls.Controller.Jump.canceled += Jump;


    }

    // Update is called once per frame
    void Awake()
    {

        controls = new PlayerControls();
        animator = GetComponentInChildren<Animator>();
        controls.Enable();

        
    }
    private void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y*(fallMultiplier-1)*Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !isJumpPressed)
        {
            rb.velocity -= Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        isGrounded = GroundCheck();
    }
    private void FixedUpdate()
    {
        


        //Debug.Log("WHY THE FUCK AM I MOVING "+move.x+" ON THE X and "+move.y+"ON THE Y");
        animator.SetFloat("Speed", move.magnitude);
       
        // controls.Movement.Sprint.performed += Sprint;

        direction = new Vector3(move.x, 0f, move.y);
        float runAnim = Mathf.Abs(move.x + move.y);
        if (move.magnitude >= .3)
        {
           

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTurn);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.position += moveDir.normalized * speed * Time.deltaTime;
            
        }
        

    }
    void Swing(InputAction.CallbackContext context)
    {
        StartCoroutine(SwingAction());
        Debug.Log("Swung the net");

    }

    bool GroundCheck()
    {
        if (animator.GetBool("isJumping") == false)
        {
            foreach (Transform g in groundPoints)
            {
                Collider[] c = Physics.OverlapSphere(g.position, groundRadius, ground);
                if (c.Length > 0)
                {
                    animator.SetBool("isGrounded", true);
                    animator.SetBool("isJumping", false);
                    animator.SetBool("isFalling", false);
                    return true;
                }
            }
        }
        
        if ((animator.GetBool("isJumping") == true && rb.velocity.y < 0) || rb.velocity.y < -2)
        {
            animator.SetBool("isGrounded", false);
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
        }
        return false;
    }
    void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Pressed Jump");
        isGrounded = GroundCheck();
        if (isGrounded) {
            animator.SetBool("isJumping", true);

            isJumpPressed = context.ReadValueAsButton();
            Debug.Log(isJumpPressed);
            rb.velocity = Vector3.up * jumpVelocity;
            isGrounded = true;

        }
        
            
        
    }
   
    IEnumerator SwingAction()
    {
      //  Debug.Log("Told to swing");
      
        animator.SetTrigger("Swing");
        GameObject ball=Instantiate(captureBall, swingPoint.position, Quaternion.identity,transform);
        
        Collider[] hitPen = Physics.OverlapSphere(swingPoint.position, swingRange, enemyLayers);
      
        
        
        Collider[] test = Physics.OverlapSphere(swingPoint.position, swingRange);
        foreach (Collider c in test)
        {
            Debug.Log(c.name);
        }


        foreach (Collider penguin in hitPen)
        {
           // Debug.Log("hit something");
            if (penguin.tag == "Penguin")
            {
                
                PenguinBase pen = penguin.GetComponent<PenguinBase>();
                GameManager.Instance.mCaught++;

                GameManager.Instance.UpdateUI();
                pen.agent.speed = 0f;

                ball.transform.parent = penguin.gameObject.transform;
                ball.transform.localPosition = Vector3.zero;
              
               // Time.timeScale = 0;
                CameraSwitcher.SwitchCamera(spinView);
                spinView.LookAt = penguin.transform;
                spinView.Follow = penguin.transform;
                for (int i = 0; i <200 ; i++)
                  {
                spinView.m_XAxis.Value += 1;
                yield return new WaitForSeconds(.01f);
                  }
                Time.timeScale = 1;
                pen.gotHit();
            }
        }
        yield return new WaitForSeconds(.2f);
        CameraSwitcher.SwitchCamera(thirdP);
      
        Destroy(ball);
    }


    void OnDisable()
    {
        controls.Disable();
    }


   
    public void takeHit(float damage)
    {
        health-=damage;
        gm.UpdateUI();
        Debug.Log("I took"+damage +"damage");
    }

   
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        if (swingPoint == null)
            return;
        Gizmos.DrawWireSphere(swingPoint.position,swingRange);
        Gizmos.color = Color.yellow;
        foreach (Transform t in groundPoints)
        {
            Gizmos.DrawWireSphere(t.position, groundRadius);
        }

    }
}
