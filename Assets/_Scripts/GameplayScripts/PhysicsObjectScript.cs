using UnityEngine;
using System.Collections;

public class PhysicsObjectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnParticleCollision(GameObject other)
    {
        //Collider collider = other.GetComponent<Collider>();

        //GameObject g = collider.gameObject;
        //Debug.Log("Collision Detected, " + other.name + ".  GameObject: ");// + g.tag);
        if (tag == "PhysicsObject")
        {
            tag = "PhysicsObjectHit";
            objectsHit();
        }

    }

    void objectsHit()
    {
        try
        {
            GameObject.Find("SceneManager").GetComponent<sceneManager2>().objectsHitbool = true;
        }

        catch
        {
            Debug.Log("didn't find SceneManager");
        }
    }
}
