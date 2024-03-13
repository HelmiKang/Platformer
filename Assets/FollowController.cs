using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform target;
   
    [SerializeField]
    int offset = 0;

    void Update()
    {
        Vector2 offsetVector = new Vector2(target.position.x + offset, target.position.y);
        
        Vector3 newPos = new Vector3(offsetVector.x,offsetVector.y,transform.position.z);
        
        transform.position = Vector3.Slerp(transform.position,newPos,followSpeed);
    }
}
