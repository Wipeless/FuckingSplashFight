using UnityEngine;

public class SceneManager : MonoBehaviour {

    public PlayerScript Player;
    public DoorScript Door;

    bool areAllEnemiesDead = true;

    void Update()
    {
        HandleQuit();
        HandlePlayer();
        HandleDoors();
    }

    private void HandleQuit()
    {
        if (Input.GetKey(KeyCode.Escape) && Application.loadedLevel == 0)
        {
            //only quit on esc for the main menu.  otherwise, use the pause menu.
            Debug.Log("trying to quit");
            Application.Quit();
        }
    }

    private void HandlePlayer()
    {
        if (Player.Attack)
        {
            //apply force to the entire scene of bad guys
            Debug.Log("hi ya!");

            GameObject[] allEnemies = (GameObject.FindGameObjectsWithTag("Enemy"));

            foreach (GameObject e in allEnemies)
            {
                e.GetComponent<EnemyScript>().ReceiveDamage(Player.ForcePower, Player.transform.position);

                //check to see if all enemies are dead
                if (e.GetComponent<EnemyScript>().CurrentEnemyState == EnemyScript.EnumEnemyState.ALIVE)
                    areAllEnemiesDead = false;
            }
        }
    }

    private void HandleDoors()
    {
        if (areAllEnemiesDead)
        {
            //open the scene door
        }
    }

    public void OnClickMainMenu()
    {
        Application.LoadLevel(1);
    }
}
