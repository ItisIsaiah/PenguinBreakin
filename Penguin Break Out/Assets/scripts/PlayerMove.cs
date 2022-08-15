using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{
  //  bool running;
   
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float smoothTurn = .5f;
    Animator animator;
  

    PlayerControls controls;
   
    public Transform cam;
    float turnSmoothVelocity;
    Vector2 move;
    Rigidbody rb;
    public Transform swingPoint;
    public float swingRange;
    public LayerMask enemyLayers;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        controls.Controller.Walk.performed += ctx => move = ctx.ReadValue<Vector2>(); ;
        controls.Controller.Walk.canceled += ctx => move = Vector2.zero;
        controls.Controller.Swing.performed += Swing;
    }

    // Update is called once per frame
    void Awake()
    {

        controls = new PlayerControls();
        animator = GetComponentInChildren<Animator>();
        controls.Enable();

    }

    private void FixedUpdate()
    {
        animator.SetFloat("Speed", rb.velocity.x+rb.velocity.z);
        // controls.Movement.Sprint.performed += Sprint;
        Vector3 direction = new Vector3(move.x, 0f, move.y).normalized;
        float runAnim = Mathf.Abs(move.x + move.y);
        if (move.magnitude != 0)
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
      
        animator.SetTrigger("Swing");
       Collider[] hitPen= Physics.OverlapSphere(swingPoint.position,swingRange,enemyLayers);
        foreach(Collider penguin in hitPen)
        {
            PenguinBase pen = penguin.GetComponent<PenguinBase>();
            pen.gotHit();
            
        }
    }


    void OnEnable()
    {
        controls.Enable();
    }
    void OnDisable()
    {
        controls.Disable();
    }


   


    void Sprint(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed)
        {
            speed *= 1.4f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        if (swingPoint == null)
            return;
        Gizmos.DrawWireSphere(swingPoint.position,swingRange);
    }
}
