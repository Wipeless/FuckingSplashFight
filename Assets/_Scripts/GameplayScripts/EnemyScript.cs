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
    private const float persueRate = 0.01f;

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
                    CurrentEnemyState = EnumEnemyStates.AGGRESS;
                    Debug.Log("I'm pissed");

                }
                break;
            case EnumEnemyStates.AGGRESS:
                transform.position = Vector3.Lerp(transform.position, AggressTarget.position, persueRate);
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
