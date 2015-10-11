using UnityEngine;

public class LevelManagerScript : MonoBehaviour {

    public GameObject Room1;
    public GameObject Room2;
    public GameObject Room3;

    public GameObject Doorway1;
    public GameObject Doorway2;
    public GameObject Doorway3;
 
    public GameObject Door1_2_entry;
    public GameObject Door1_2_exit;
    public GameObject Door2_3_entry;
    public GameObject Door2_3_exit;
    public GameObject Door3_final;

    public GameObject TriggerBox_Level1_2;
    public GameObject TriggerBox_Level2_3;
    public GameObject TriggerBox_Level3_final;

    public enum EnumLevels
    {
        LEVEL1,
        LEVEL2,
        LEVEL3,
    }

    public EnumLevels CurrentLevel = EnumLevels.LEVEL1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
