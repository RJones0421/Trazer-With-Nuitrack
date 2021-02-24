using UnityEngine;

public class CollisionTester : MonoBehaviour
{
    [SerializeField] HitTester target;
    [SerializeField] RandomizedObjectSpawner spawner;
    private void OnCollisionEnter(Collision other) {
        Debug.Log("Hit");
        target.WasHit();
        spawner.wasConeHit = true;
    }

    public void SetTarget(HitTester target) {
        this.target = target;
        Debug.Log(target);
    }
}
