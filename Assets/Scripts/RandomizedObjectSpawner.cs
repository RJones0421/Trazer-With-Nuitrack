using System.Collections;
using UnityEngine;

public class RandomizedObjectSpawner : ObjectSpawner
{
    System.Random rnd = new System.Random();

    // start the gamemode
    void Start()
    {
        InstantiateColliders();
        StartCoroutine(RandomSpawn());
    }

    //randomly choose which location to go to for the set amount of tests
    private IEnumerator RandomSpawn() {
        for (int i = 1; i <= numberOfTests; i++) {
            //get random spawn location
            int num = rnd.Next(0, spawners.Length);
            GameObject spawner = spawners[num];

            //move and activate the cone
            target.transform.position = spawner.transform.position;
            target.gameObject.SetActive(true);
            timer.distanceInMeters = distance.CalculateDistanceXZPlane();
            timer.StartTime();

            //wait until the target is hit
            while (!targetHit) {
                yield return 0;
            }

            //disable the target
            target.gameObject.SetActive(false);
            targetHit = false;
            timer.StopTime();

            //wait 2 seconds for the next spawn
            yield return new WaitForSeconds(2);
        }
        Debug.Log("Done");
        timer.AverageTime();
        timer.AverageSpeed();
        timer.Save();
        timer.GameOver();
    }

    public void Restart(){
        timer.Clear();
        Start();
    }
}
