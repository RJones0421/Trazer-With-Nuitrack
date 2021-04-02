using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balance : MonoBehaviour
{
    
    private enum BalanceType
    {
        tPose,
        oneLeg,
        footInFront
    };

    [Header("General")]
    [SerializeField] BalanceType balanceType = BalanceType.tPose;

    [Header("Control")]
    [SerializeField] TPoseCalibration poseCalibration;

    bool isBalancing = false;
    protected Timer timer;

    void Start(){
        poseCalibration.onSuccess += PoseCalibration_onSuccess;

        timer = FindObjectOfType<Timer>();
        StartCoroutine(BalanceTest());
    }

    //Unsubscribe from the T-Pose calibration completion event
    private void OnDestroy(){
        poseCalibration.onSuccess -= PoseCalibration_onSuccess;
    }

    //Process the beginning and ending of calibration
    private void PoseCalibration_onSuccess(Quaternion rotation){
        if(!isBalancing)
        {

        }
        else
        {
            Debug.Log("Not Balancing");
            isBalancing = false;
        }
    }
    IEnumerator BalanceTest(){
        yield return new WaitForSeconds(3);
        timer.StartTime();
    }


}
