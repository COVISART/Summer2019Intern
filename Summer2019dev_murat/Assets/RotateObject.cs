using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public GameObject cube;
    public int size;
    public void changePosition()
    {
        cube.transform.localPosition = new Vector3(0, size, 0);
    }

    void FixedUpdate()
    {
        cube.transform.localPosition = new Vector3(0, 0, size);
    }
}
