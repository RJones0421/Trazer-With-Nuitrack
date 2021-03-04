using UnityEngine;

public abstract class ObjectSpawner : MonoBehaviour
{
    [SerializeField] [Range(1, 15)] protected int numberOfTests = 5;
    [SerializeField] protected GameObject[] spawners = new GameObject[8];
    [SerializeField] protected HitTester target;
    
    protected CollisionTester[] colliders;
    protected bool targetHit;

    protected void InstantiateColliders() {
        colliders = GameObject.FindObjectsOfType<CollisionTester>();
        foreach (var collider in colliders)
        {
            collider.SetTarget(target);
        }
    }

    public void TargetHit()
    {
        targetHit = true;
    }
}
