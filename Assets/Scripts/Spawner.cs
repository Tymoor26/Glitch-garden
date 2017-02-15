using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;
    private Spawner[] spawnPoints;

    // Use this for initialization
    void Start () {
        spawnPoints = GameObject.FindObjectsOfType<Spawner>();

    }

    // Update is called once per frame
    void Update () {
	    foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if (isTimeToSpawn(thisAttacker)){
                Spawn(thisAttacker);
                Debug.Log("Spawning " + thisAttacker + " at lane " + transform.position.y);
            }
        }
	}

    bool isTimeToSpawn(GameObject thisAttacker)
    {
        float meanSpawnDelay = thisAttacker.GetComponent<Attacker>().seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;
        if (Time.deltaTime>meanSpawnDelay) { Debug.LogWarning("Spawn rate capped by frame rate"); }

        float threshold = spawnsPerSecond * Time.deltaTime /5;

        if (Random.value < threshold) { return true;  }
        else                          { return false; }
    }

    void Spawn(GameObject thisAttacker) {
        float xPos = transform.position.x;
        float yPos = transform.position.y;
        Vector2 spawn = new Vector2(xPos, yPos);
        Quaternion zeroRot = Quaternion.identity;
        GameObject newAtk = Instantiate(thisAttacker,spawn,zeroRot) as GameObject;
        newAtk.transform.parent = transform;
    }
}
