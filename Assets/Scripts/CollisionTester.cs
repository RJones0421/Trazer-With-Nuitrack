using UnityEngine;

public class CollisionTester : MonoBehaviour
{
    [SerializeField] ObjectSpawner spawner;

    HitTester target;
    private void OnCollisionEnter(Collision other) {
        Debug.Log("Hit");
        target.WasHit();
        spawner.TargetHit();
    }

    public void SetTarget(HitTester target) {
        this.target = target;
        Debug.Log(target);
    }
}
