using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    public GameObject TargetObject;
    public Vector3 TargetPosition;
    public Quaternion TargetRotation;
    public Transform CurrentPos;
    public Transform CurrentRot;
    public Transform CurrentSca;
    public Vector3 TargetScale;
    public float Speed;

    public Text info;

    //public void ChangePosition()
    //{
    //    TargetObject.transform.localPosition = TargetPosition;
    //}

    public void ChangePosition()
    {
        float x = Random.Range(-15, 15);
        float y = Random.Range(-6, 6);

        float a = Random.Range(0, 360);
        float b = Random.Range(0, 360);

        float scaleA = Random.Range(0.5f, 3);
        float scaleB = Random.Range(0.5f, 3);
        float scaleC = Random.Range(0.5f, 3);

        TargetRotation = new Quaternion(a, b, 0, 0);
        TargetPosition = new Vector3(x, y);
        TargetScale = new Vector3(scaleA, scaleB, scaleC);

        //CurrentPos = TargetPos;
    }

    //public void ChangePosition(Transform TargetPos)
    //{
    //    CurrentPos = TargetPos;
    //}

    // Start is called before the first frame update
    void Start()
    {
        TargetScale = new Vector3(1, 1, 1);
    }

    void Update()
    {

        TargetObject.transform.localPosition = Vector3.Lerp(CurrentPos.position, TargetPosition, Speed);
        TargetObject.transform.rotation = Quaternion.Slerp(CurrentRot.rotation, TargetRotation, Speed);
        TargetObject.transform.localScale = Vector3.Lerp(CurrentSca.localScale, TargetScale, Speed);

        info.text = TargetPosition.ToString() + "\n" + TargetRotation.ToString() + "\n" + TargetScale.ToString();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    TargetObject.transform.localPosition = Vector3.Lerp(TargetObject.transform.position, CurrentPos.position, Speed);
    //    TargetObject.transform.rotation = Quaternion.Slerp(TargetObject.transform.rotation, CurrentPos.rotation, Speed);
    //    TargetObject.transform.localScale = Vector3.Slerp(TargetObject.transform.localScale, CurrentPos.localScale, Speed);
    //}


}
