using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
public class EnemyScript : MonoBehaviour {

    public enum EnumEnemyState
    {
        ALIVE = 0,
        DEAD,
    }

    public EnumEnemyState CurrentEnemyState = EnumEnemyState.ALIVE;

    private float _health = 100;  public float Health { get { return _health; } }

    Animator m_Animator;
    Rigidbody m_RigidBody;

    // Use this for initialization
    void Start () {

        m_Animator = GetComponent<Animator>();
        m_RigidBody = GetComponent<Rigidbody>();

        m_RigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void ReceiveDamage(float damageValue, Vector3 orginPosition)
    {
        _health -= damageValue;

        _health = 0;    //TODO: watch out for this.  handle if we want enemies to handle some damage (like bosses);

        if (_health <= 0)
        {
            _health = 0;
            CurrentEnemyState = EnumEnemyState.DEAD;
            m_RigidBody.constraints = RigidbodyConstraints.None;

            GetComponent<Rigidbody>().AddForceAtPosition(Vector3.Normalize(transform.position - orginPosition) * damageValue, orginPosition);
            tag = "Untagged";
        }
    }
}
