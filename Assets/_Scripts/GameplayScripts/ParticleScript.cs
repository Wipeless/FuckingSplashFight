using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ParticleScript : MonoBehaviour {

    public GameObject particle;
    public Transform player;


    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {

        if (player.GetComponent<PlayerScript>().AttackInit)
        {
            GameObject tempParticle = new GameObject();
            tempParticle.transform.rotation = new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w);
            tempParticle.transform.Rotate(0, -90, 0);
            Quaternion particleRotation = new Quaternion(tempParticle.transform.rotation.x, tempParticle.transform.rotation.y, tempParticle.transform.rotation.z, tempParticle.transform.rotation.w);

            GameObject newParticle = (GameObject)Instantiate(particle, transform.position, particleRotation);
            Destroy(newParticle, .5f);

        }

    }
}
