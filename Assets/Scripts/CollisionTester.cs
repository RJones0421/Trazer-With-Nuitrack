using UnityEngine;

public class CollisionTester : MonoBehaviour
{
    [SerializeField] RandomizedObjectSpawner spawner;
    [SerializeField] HitTester target;
    [SerializeField] Timer time;
    private void OnCollisionEnter(Collision other) {
        Debug.Log("Hit");
        target.WasHit();
        spawner.TargetHit();
        time.Add();
    }

    public void SetTarget(HitTester target){
        this.target = target;
        Debug.Log(target);
    }
}
