using UnityEngine;

public class SceneManager : MonoBehaviour {

    public PlayerScript Player;
    public DoorScript Door;

    bool areAllEnemiesDead = true;

    const int maxNumSFX_enemy = 2;
    public static int numSFX_enemy = 0;  
    public static bool doSFX_enemy = true;

    public static float SFXTimer;
    const float SFXTimerLimit = 2;

    void Update()
    {
        HandleQuit();
        HandlePlayer();
        HandleDoors();
    }

    public static bool IncrementSFX()
    {
        bool result;

        if (!doSFX_enemy)
        {
            if (Time.time - SFXTimer > SFXTimerLimit)
            {
                doSFX_enemy = true;
                numSFX_enemy = 0;
            }
            result = false;
        }
        else
        {
            numSFX_enemy++;

            if (numSFX_enemy >= maxNumSFX_enemy)
            {
                SFXTimer = Time.time;
                doSFX_enemy = false;
                result = false;
            }
            else
                result = true;
        }
        return result;
    }

    private void HandleQuit()
    {
        if (Input.GetKey(KeyCode.Escape) && Application.loadedLevel == 0)
        {
            //only quit on esc for the main menu.  otherwise, use the pause menu.
            Application.Quit();
        }
    }

    private void HandlePlayer()
    {
        if (Player.AttackExecuted)
        {
            areAllEnemiesDead = true;
            //apply force to the entire scene of bad guys

            GameObject[] enemiesHit = (GameObject.FindGameObjectsWithTag("EnemyDead"));
            GameObject[] remainingEnemies = (GameObject.FindGameObjectsWithTag("Enemy"));
            //check to see if all enemies are dead
            if (remainingEnemies.Length > 0)
            {
                areAllEnemiesDead = false;
            }
            Debug.Log("remaining Enemies: " + remainingEnemies.Length);

            foreach (GameObject e in enemiesHit)
            {
                e.GetComponent<EnemyScript>().ReceiveDamage(Player.ForcePower, Player.transform.position);
            }

            if (areAllEnemiesDead)
            {
                Door.OpenDoor();
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
