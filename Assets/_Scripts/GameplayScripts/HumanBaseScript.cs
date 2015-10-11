using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class HumanBaseScript : MonoBehaviour {

    public enum EnumHealthState
    {
        ALIVE = 0,
        DEAD,
    }

    public EnumHealthState CurrentHealthState = EnumHealthState.ALIVE;

    protected Animator m_Animator;
    protected Rigidbody m_RigidBody;

    protected float health = 100; public float Health { get { return health; } }

    protected AudioSource audio;

    //Animation parameters
    protected bool m_Damaged;
    protected bool m_Dead;
    protected bool m_Attacking;
    protected float m_TurnAmount;
    protected float m_ForwardAmount;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
