using UnityEngine;

public class HitTester : MonoBehaviour
{
    public void WasHit()
    {
        gameObject.SetActive(false);
    }
}
