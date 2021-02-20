using UnityEngine;

public class CollisionTester : MonoBehaviour
{
    [SerializeField] HitTester hitTester;
    private void OnCollisionEnter(Collision other) {
        Debug.Log("Hit");
        hitTester.WasHit();
    }
}
