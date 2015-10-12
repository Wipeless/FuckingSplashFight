using UnityEngine;

public class SceneManager : MonoBehaviour {

    public PlayerScript Player;
    public LevelManagerScript LevelManger;
    public DoorScript Door1_Entry;
    public DoorScript Door1_Exit;
    public DoorScript Door2_Entry;
    public DoorScript Door2_Exit;
    public DoorScript Door3_Entry;
    public DoorScript Door3_Exit;

    static bool startNewLevel = false;      public static void ResetSceneState() { startNewLevel = true; } 
    static bool areAllEnemiesDead = false; 
    static bool playerDead = false;

    public static bool IsPlayerDead { get { return playerDead; } }

    private float playerDeadTimer;              //timer upon the player's death. once done, go to game over scene
    private float playerDeadTimerLimit = 5;

    private bool prepareWin = false;
    private float playerWinTimer;              //timer upon the player's victory. once done, go to game over scene
    private float playerWinTimerLimit = 5;

    const int maxNumSFX_enemy = 10;
    public static int numSFX_enemy = 0;  
    public static bool doSFX_enemy = true;

    public static float SFXTimer;
    const float SFXTimerLimit = 1;

    public float TimeScale = 1f;

    void Start()
    {
        startNewLevel = true;
    }

    void Update()
    {
        HandleQuit();
        if(Player != null)
           HandlePlayer();
        HandleDoors();
        HandleSceneState();
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

    private void HandleSceneState()
    {
        if (startNewLevel)
        {
            Debug.Log("SceneManager: the level has started");
            startNewLevel = false;
            areAllEnemiesDead = false;
        }
        else if (LevelManger != null)
        {
            if (LevelManger.CurrentLevel == LevelManagerScript.EnumLevels.LEVEL3)
            {
                if (areAllEnemiesDead)
                {
                    if (!prepareWin)
                    {
                        prepareWin = true;
                        playerWinTimer = Time.time;
                    }

                    if (Time.time - playerWinTimer > playerWinTimerLimit)
                        GoToGameOver_Won();
                }
                else
                    prepareWin = false;
            }
        }
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
                areAllEnemiesDead = false;

            foreach (GameObject e in enemiesHit)
                e.GetComponent<EnemyScript>().ReceiveDamage(Player.ForcePower, Player.transform.position);

        }

        if (Player.CurrentHealthState == HumanBaseScript.EnumHealthState.DEAD)
        {
            if (!playerDead)
            {
                //mark the player dead for the scene manager
                playerDead = true;
                playerDeadTimer = Time.time;

                GameObject[] remainingEnemies = (GameObject.FindGameObjectsWithTag("Enemy"));
                foreach (GameObject o in remainingEnemies)
                    o.GetComponent<EnemyScript>().CurrentEnemyState = EnemyScript.EnumEnemyStates.ROAM;
            }
            else
            {
                //after the player has been dead for a bit, transition to gameover loss
                if(Time.time - playerDeadTimer > playerDeadTimerLimit)
                    GoToGameOver_Lost();
            }
        }
    }

    private void HandleDoors()
    {
        if (areAllEnemiesDead)
        {
            //Debug.Log("all enemies dead");
            //open the exit scene doors
            if (Door1_Exit != null)
                Door1_Exit.OpenDoor();
            if (Door2_Exit != null)
                Door2_Exit.OpenDoor();
            if (Door3_Exit != null)
                Door3_Exit.OpenDoor();
        }
        else if (startNewLevel)
        {
            Debug.Log("start new level");

            //close all doors
            if (Door1_Exit != null)
                Door1_Exit.CloseDoor();
            if (Door2_Exit != null)
                Door2_Exit.CloseDoor();
            if (Door3_Exit != null)
                Door3_Exit.CloseDoor();

            if (Door1_Entry != null)
                Door1_Entry.CloseDoor();
            if (Door2_Entry != null)
                Door2_Entry.CloseDoor();
            if (Door3_Entry != null)
                Door3_Entry.CloseDoor();
        }
    }

    public void OnClickMainMenu()
    {
        Application.LoadLevel(4);       //4 is the intro scene (1 is the gameplay
    }
    public void OnClickGameOver()
    {
        Application.LoadLevel(0);
    }

    private void GoToGameOver_Won()
    {
        Application.LoadLevel(3);
    }

    private void GoToGameOver_Lost()
    {
        Application.LoadLevel(2);
    }
}
