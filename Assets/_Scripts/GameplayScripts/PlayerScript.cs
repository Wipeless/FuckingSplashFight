using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerScript : HumanBaseScript {

    //HUD variables
    public HUD_Gameplay HUD;

    //Gameplay variables
    private bool _attack = false;   public bool Attack {  get { return _attack;  } }
    private bool _inPuddle = false;
    public float DamageAmount = 25;   //amount of damage the player takes when hit

    //Animation variables
    private Vector3 m_Move;
    const float k_Half = 0.5f;
    public float MoveRate = 10;
    public float ForcePower = 200;

    public Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;             // The current forward direction of the camera

    bool m_Damaged;
    bool m_Dead;
    bool m_Attacking;
    float m_TurnAmount;
    Vector3 m_GroundNormal;
    float m_ForwardAmount;


    [SerializeField] float m_MovingTurnSpeed = 360;
    [SerializeField] float m_StationaryTurnSpeed = 180;
    [SerializeField] float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others


    // Use this for initialization
    void Start () {

        if (m_Cam == null)
            Debug.LogWarning("You forgot to set the camera for the Player!");

        m_Animator = GetComponent<Animator>();
        m_RigidBody = GetComponent<Rigidbody>();

        m_RigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("enemy collision");
            health -= DamageAmount;
            m_Damaged = true;

            if (health < 0)
            {
                health = 0;
                m_Dead = true;
                CurrentHealthState = EnumHealthState.DEAD;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
//            Debug.Log("exit enemy collision");
            m_Damaged = false;

        }
    }

    void OnTriggerEnter(Collider collision)
    {
        //create splash
        if (collision.gameObject.tag == "Puddle")
        {
            Debug.Log("player is colliding with puddle");
            _inPuddle = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        _inPuddle = false;
    }

    // Update is called once per frame
    void Update () {

        _attack = false;
        m_Attacking = false;

        if(HUD.CurrentHUDState == HUD_Gameplay.EnumCurrentHUDState.NOTDISPLAYED ||
            CurrentHealthState == EnumHealthState.ALIVE)
            HandleInput();
    }

    private void HandleInput()
    {
        Vector3 inputForce = Vector3.zero;

        if (!_attack && _inPuddle)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Attack!");
                _attack = true;
                m_Attacking = true;
            }
        }

        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        // calculate move direction to pass to character
        if (m_Cam != null)
        {
            // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;

            //Debug.Log("cam forward: " + m_CamForward);
            m_Move = v * m_CamForward + h * m_Cam.right;

            //Debug.Log("m move: " + m_Move);

            inputForce = (v * m_CamForward + h * m_Cam.right) * MoveRate;
            //m_Move = (v * m_CamForward + h * m_Cam.right) * MoveRate;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            m_Move = (h * Vector3.forward) + (v * Vector3.right);
        }

        GetComponent<Rigidbody>().AddForce(inputForce);

        m_Move = (-h * Vector3.forward) + (v * Vector3.right);
       // m_Move = (h * Vector3.forward) + (-v * Vector3.right);      //this works for the gameplay scene

        if (m_Move.magnitude > 1f) m_Move.Normalize();
        m_Move = transform.InverseTransformDirection(m_Move);
        m_Move = Vector3.ProjectOnPlane(m_Move, m_GroundNormal);
        m_TurnAmount = Mathf.Atan2(m_Move.x, m_Move.z);
        m_ForwardAmount = m_Move.z;

        ApplyExtraTurnRotation();

        UpdateAnimator(m_Move);
    }

    void ApplyExtraTurnRotation()
    {
        // help the character turn faster (this is in addition to root rotation in the animation)
        float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
        transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
    }

    void UpdateAnimator(Vector3 move)
    {
        // update the animator parameters
        m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
        m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
        m_Animator.SetBool("Damaged", m_Damaged);
        m_Animator.SetBool("Dead", m_Dead);
        m_Animator.SetBool("Attacking", m_Attacking);

        // calculate which leg is behind, so as to leave that leg trailing in the jump animation
        // (This code is reliant on the specific run cycle offset in our animations,
        // and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
        float runCycle =
            Mathf.Repeat(
                m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime + m_RunCycleLegOffset, 1);
        float jumpLeg = (runCycle < k_Half ? 1 : -1) * m_ForwardAmount;


        // the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
        // which affects the movement speed because of the root motion.


        // don't use that while airborne
        m_Animator.speed = 1;
    }

    public void OnAnimatorMove()
    {
        // we implement this function to override the default root motion.
        // this allows us to modify the positional speed before it's applied.
      /*  if (Time.deltaTime > 0)
        {

            // Debug.Log("move delta: " + m_Animator.deltaPosition);

            Vector3 v = (m_Animator.deltaPosition * 1) / Time.deltaTime;

            // we preserve the existing y part of the current velocity.
            v.y = m_RigidBody.velocity.y;
            // Debug.Log("v: " + v);
            m_RigidBody.velocity = v;
        }*/
    }
}
