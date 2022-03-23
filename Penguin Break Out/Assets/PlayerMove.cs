using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    bool running;
    float horizontal;
    float vertical;
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float smoothTurn = .5f;
    Animator animator;
    // InputAction move;

    PlayerControls controls;
    InputAction playerControls;
    public Transform cam;
    float turnSmoothVelocity;
    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        controls.Movement.Walk.performed += ctx => move = ctx.ReadValue<Vector2>(); ;
        controls.Movement.Walk.canceled += ctx => move = Vector2.zero;
        controls.Movement.Attack.performed += Attack;
    }

    // Update is called once per frame
    void Awake()
    {

        controls = new PlayerControls();
        animator = GetComponent<Animator>();
        controls.Enable();

    }

    private void FixedUpdate()
    {
        // controls.Movement.Sprint.performed += Sprint;
        Vector3 direction = new Vector3(move.x, 0f, move.y).normalized;
        float runAnim = Mathf.Abs(move.x + move.y);
        if (move.magnitude != 0)
        {
            animator.SetFloat("speed", runAnim);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTurn);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.position += moveDir.normalized * speed * Time.deltaTime;
        }


    }
    void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("I attacked");
        animator.SetTrigger("attack");
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
}
