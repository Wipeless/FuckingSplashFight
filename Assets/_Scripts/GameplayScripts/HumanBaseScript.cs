using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
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


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
