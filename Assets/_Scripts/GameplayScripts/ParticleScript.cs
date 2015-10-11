using UnityEngine;
using System.Collections;


public class ParticleScript : MonoBehaviour {

    public GameObject particle;
    public Transform player;
    //public PuddleScript puddleScript = GetComponent<PuddleScript>();
    GameObject newParticle;


    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {

        if (player.GetComponent<PlayerScript>().AttackInit)
        {
            if (GetComponent<PuddleScript>().IsCollidingWithPlayer)
            {

                if (newParticle == null)
                {
                    //newParticle = new GameObject();
                    GameObject tempParticle = new GameObject();
                    tempParticle.transform.rotation = new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w);
                    tempParticle.transform.Rotate(0, -90, 0);
                    Quaternion particleRotation = new Quaternion(tempParticle.transform.rotation.x, tempParticle.transform.rotation.y, tempParticle.transform.rotation.z, tempParticle.transform.rotation.w);
                    //newParticle = new GameObject();
                    newParticle = (GameObject)Instantiate(particle, transform.position, particleRotation);
                    Destroy(newParticle.gameObject, .5f);
                    Destroy(tempParticle.gameObject, .5f);
                    //Destroy(particleRotation, .5f);
                }
            }

        }

    }
}
