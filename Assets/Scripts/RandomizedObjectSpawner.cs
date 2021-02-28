using System.Collections;
using UnityEngine;

public class RandomizedObjectSpawner : ObjectSpawner
{
    System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        InstantiateColliders();
        StartCoroutine(RandomSpawn());
    }

    private IEnumerator RandomSpawn() {
        for (int i = 1; i <= numberOfTests; i++) {
            int num = rnd.Next(0, spawners.Length);
            GameObject spawner = spawners[num];

            target.transform.position = spawner.transform.position;
            target.gameObject.SetActive(true);

            while (!targetHit) {
                yield return 0;
            }

            target.gameObject.SetActive(false);
            targetHit = false;

            yield return new WaitForSeconds(2);
        }
        Debug.Log("Done");
    }
}
