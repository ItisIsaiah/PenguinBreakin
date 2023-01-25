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
    private void Update()
    {
         
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

    IEnumerator SwingAction()
    {
        Debug.Log("Told to swing");
        speed /= 10;
        animator.SetTrigger("Swing");
        GameObject ball=Instantiate(captureBall, swingPoint.position, Quaternion.identity,transform);
        
        Collider[] hitPen = Physics.OverlapSphere(swingPoint.position, swingRange, enemyLayers);
        foreach (Collider penguin in hitPen)
        {
            if (penguin.tag == "Penguin")
            {
                Debug.Log("Swinging");
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
        speed *= 10;
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

   /* void Sprint(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed)
        {
            speed *= 1.4f;
        }
    }
   */
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        if (swingPoint == null)
            return;
        Gizmos.DrawWireSphere(swingPoint.position,swingRange);
    }
}
