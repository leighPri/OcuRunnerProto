using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] obstacle;

    private int spawnLimitMin = 18; //fastest rate at which spawns can happen
    private int nextSpawnFrame;
    private int frameCounter;

    private SpeedMaster speedMaster;

    void Start() {
        frameCounter = 0;
        nextSpawnFrame = 50;
        speedMaster = FindObjectOfType<SpeedMaster>();
        //spawns an initial block to get things rolling
        SpawnObstacle(PickRandomObject());
    }

    void Update() {
        if (SpawnTime()) {
            SpawnObstacle(PickRandomObject());
            SetSpawn();
        }
        frameCounter++;
    }

    public void SetSpawn() {
        //picks a random number in the range of spawn possibilities
        nextSpawnFrame = frameCounter + Random.Range(spawnLimitMin, speedMaster.spawnSpeed);
    }

    public bool SpawnTime() {
        if (nextSpawnFrame == frameCounter) {
            return true;
        } else {
            return false;
        }
    }

    int PickRandomObject() {
        return Random.Range(0, obstacle.Length);
    }

    void SpawnObstacle(int picked) {
        if (obstacle[picked] != null) {
            Instantiate(obstacle[picked], transform.position, Quaternion.identity);
        }
    }
    
    //makes spawning faster up to the limit
    public void SetSpawnSpeed() {
       speedMaster.spawnSpeed -= 10;
       if (speedMaster.spawnSpeed <= spawnLimitMin) {
               speedMaster.spawnSpeed = spawnLimitMin;
       }
    }
}
    


