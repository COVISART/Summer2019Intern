using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
    public GameObject targetObject;

    public Transform currentPos;
    public float speed;
    public void changePosition(Transform targetPos)
    {
        currentPos = targetPos;

    }

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetObject.transform.localPosition = Vector3.Lerp(transform.localPosition, currentPos.localPosition, speed);
        targetObject.transform.rotation = Quaternion.Lerp(targetObject.transform.rotation,currentPos.rotation,speed);
        targetObject.transform.rotation = Quaternion.Lerp(targetObject.transform.rotation,currentPos.rotation,speed);
    }

    void FixedUpdate()
    {

    }
}
