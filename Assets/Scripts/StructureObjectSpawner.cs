using System.Collections;
using UnityEngine;

public class StructureObjectSpawner : ObjectSpawner
{
    // Start is called before the first frame update
    void Start()
    {
        InstantiateColliders();
        StartCoroutine(StructuredSpawn());
    }

    private IEnumerator StructuredSpawn() {
        int count = 0;
        for (int i = 1; i <= numberOfTests; i++)
        {
            timer.distanceInMeters = distance.CalculateDistanceXZPlane();
            timer.StartTime();
            while (count < spawners.Length) {
                target.transform.position = spawners[count].transform.position;
                target.gameObject.SetActive(true);

                while (!targetHit) {
                    yield return 0;
                }

                target.gameObject.SetActive(false);
                targetHit = false;
                count++;
            }

            timer.StopTime();
            timer.Speed();
            count = 0;
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