using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedObjectSpawner : MonoBehaviour
{
    [SerializeField] [Range(1, 15)] int numberOfTests = 5;
    [SerializeField] HitTester[] targets = new HitTester[5];

    System.Random rnd = new System.Random();
    private CollisionTester[] colliders;
    public bool wasConeHit = false;

    // Start is called before the first frame update
    void Start()
    {
        colliders = GameObject.FindObjectsOfType<CollisionTester>();
        StartCoroutine(RandomSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator RandomSpawn() {
        for (int i = 1; i <= numberOfTests; i++) {
            int num = rnd.Next(0, targets.Length);
            HitTester target = targets[num];

            target.gameObject.SetActive(true);
            foreach (var collider in colliders) {
                collider.SetTarget(target);
            }

            while (!wasConeHit) {
                yield return 0;
            }

            target.gameObject.SetActive(false);
            wasConeHit = false;

            yield return new WaitForSeconds(2);
        }
        Debug.Log("Done");
    }

    public void ConeHit() {
        wasConeHit = true;
    }
}
