using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balance : MonoBehaviour
{
    
    protected Timer timer;

    void Start(){
        timer = FindObjectOfType<Timer>();
        StartCoroutine(BalanceTest());
    }
    
    IEnumerator BalanceTest(){
        yield return new WaitForSeconds(3);
        timer.StartTime();
    }


}
