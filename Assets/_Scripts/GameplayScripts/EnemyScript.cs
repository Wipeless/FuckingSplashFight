using UnityEngine;


public class EnemyScript : HumanBaseScript {

    public enum EnumEnemyStates
    {
        NEUTRAL = 0,
        AGGRESS,
    }

    public EnumEnemyStates CurrentEnemyState = EnumEnemyStates.NEUTRAL;

    public Transform AggressTarget;
    private float aggressionTimer;
    private float aggressionTimerLimit;
    private const float aggressionTimerLimitMin = 1f;
    private const float aggressionTimerLimitMax = 2f;
    private const float pursueRate = 0.05f;

    // Use this for initialization
    void Start () {
        m_Animator = GetComponent<Animator>();
        m_RigidBody = GetComponent<Rigidbody>();

        m_RigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        aggressionTimer = Random.Range(aggressionTimerLimitMin, aggressionTimerLimitMax);
        aggressionTimer = Time.time;

    }

    // Update is called once per frame
    void Update () {
        HandleAggressionBehavior();
	}

    void HandleAggressionBehavior()
    {
        switch (CurrentEnemyState)
        {
            case EnumEnemyStates.NEUTRAL:
                if (Time.time - aggressionTimer > aggressionTimerLimit)
                {
                    //aggress player
                    CurrentEnemyState = EnumEnemyStates.AGGRESS;
                }
                break;
            case EnumEnemyStates.AGGRESS:
                transform.LookAt(AggressTarget);
                transform.Rotate(Vector3.up, 90f);
                transform.position = Vector3.MoveTowards(transform.position, AggressTarget.position, pursueRate);
                break;
        }
    }


    public void ReceiveDamage(float damageValue, Vector3 orginPosition)
    {
        health -= damageValue;

        health = 0;    //TODO: watch out for this.  handle if we want enemies to handle some damage (like bosses);

        if (health <= 0)
        {
            health = 0;
            CurrentHealthState = EnumHealthState.DEAD;
            m_RigidBody.constraints = RigidbodyConstraints.None;

            GetComponent<Rigidbody>().AddForceAtPosition(Vector3.Normalize(transform.position - orginPosition) * damageValue, orginPosition);
            tag = "Untagged";
        }
    }
}
