using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private bool _attack = false;   public bool Attack {  get { return _attack;  } }
    private bool _inPuddle = false;

    public float MoveRate = 10;
    public float ForcePower = 200;

    // Use this for initialization
    void Start () {
	
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

	    if(Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, MoveRate));
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-MoveRate, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -MoveRate));
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(MoveRate, 0, 0));
        }

        if (!_attack && _inPuddle)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _attack = true;
            }
        }
    }
}
