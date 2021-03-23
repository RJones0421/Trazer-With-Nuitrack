using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCalculator : MonoBehaviour
{
    private enum Distance
    {
        Space,
        XZPlane
    }

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cone;
    [SerializeField] private Distance distanceType;
    
    private float distance;
    private LineRenderer line;

    void Start(){
        line = GetComponent<LineRenderer>();
    }

    void Update(){

        line.SetPosition(0, player.transform.position);
        line.SetPosition(1, cone.transform.position);

        switch(distanceType)
        {
            case Distance.Space:
                distance = CalculateDistanceInSpace();
                Debug.Log("Distance in Space: " + distance.ToString());
                break;
            case Distance.XZPlane:
                distance = CalculateDistanceXZPlane();
                Debug.Log("Distance in XZ Plane: " + distance.ToString());
                break;
        }
    }

    //3D
    private float CalculateDistanceInSpace(){
        return Vector3.Distance(player.transform.position, cone.transform.position);
    }
    //2D
    public float CalculateDistanceXZPlane(){
        Vector2 v1 = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 v2 = new Vector2(cone.transform.position.x, cone.transform.position.z);
        return Vector2.Distance(v1,v2);
    }

}
