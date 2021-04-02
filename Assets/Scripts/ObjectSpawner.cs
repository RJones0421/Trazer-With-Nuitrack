using UnityEngine;

public abstract class ObjectSpawner : MonoBehaviour
{
    //fields that need to be filled through the editor
    [SerializeField] [Range(1, 15)] protected int numberOfTests = 5;
    [SerializeField] protected GameObject[] spawners = new GameObject[8];
    [SerializeField] protected HitTester target;
    
    //fields that will be found through code
    protected CollisionTester[] colliders;
    protected bool targetHit;
    protected Timer timer;
    protected DistanceCalculator distance;

    //make all the colliders know the target to hit
    protected void InstantiateColliders() {
        timer = FindObjectOfType<Timer>();
        distance = FindObjectOfType<DistanceCalculator>();
        timer.InstantiateTimes(numberOfTests);
        timer.InstantiateSpeeds(numberOfTests);
        colliders = GameObject.FindObjectsOfType<CollisionTester>();
        foreach (var collider in colliders)
        {
            collider.SetTarget(target);
        }
    }

    //method to be called when object has been hit
    public void TargetHit()
    {
        targetHit = true;
    }

}
