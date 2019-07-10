using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject TargetObject;
    //public Vector3 TargetPosition;
    public Transform CurrentPos;
    public float Speed;

    //public void ChangePosition()
    //{
    //    TargetObject.transform.localPosition = TargetPosition;
    //}

    public void ChangePosition(Transform TargetPos)
    {
        CurrentPos = TargetPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetObject.transform.localPosition = Vector3.Lerp(TargetObject.transform.position, CurrentPos.position, Speed);
        TargetObject.transform.rotation = Quaternion.Slerp(TargetObject.transform.rotation, CurrentPos.rotation, Speed);
        TargetObject.transform.localScale = Vector3.Slerp(TargetObject.transform.localScale, CurrentPos.localScale, Speed);
    }


}
