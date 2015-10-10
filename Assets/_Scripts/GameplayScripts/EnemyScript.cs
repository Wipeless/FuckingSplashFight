using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public enum EnumEnemyState
    {
        ALIVE = 0,
        DEAD,
    }

    public EnumEnemyState CurrentEnemyState = EnumEnemyState.ALIVE;

    private float _health = 100;  public float Health { get { return _health; } }

	// Use this for initialization
	void Start () {
	
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
            GetComponent<Rigidbody>().AddForceAtPosition(Vector3.Normalize(transform.position - orginPosition) * damageValue, orginPosition);
        }
    }
}
