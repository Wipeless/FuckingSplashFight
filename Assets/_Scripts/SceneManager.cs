using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    public Player Player;

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Player.Attack)
        {
            //apply force to the entire scene of bad guys
            Debug.Log("hi ya!");

            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject e in allEnemies)
                e.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.Normalize(e.transform.position - Player.transform.position) *Player.ForcePower, Player.transform.position);
        } 
    }

    public void OnClickMainMenu()
    {
        Application.LoadLevel(1);
    }
}
