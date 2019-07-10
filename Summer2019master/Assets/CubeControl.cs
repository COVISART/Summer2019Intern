using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeControl : MonoBehaviour
{
    public GameObject targetObject;

    public Transform currentPos;
    public Transform targetPosistion;
    public Text presenText;
    public float speed;

    public void changePositoin(Transform targetPos)
    {
        currentPos = targetPos;
    }

    // Update is called once per frame
    void Update()
    {
        targetObject.transform.localPosition = Vector3.Lerp(targetObject.transform.localPosition, currentPos.localPosition, speed);
        targetObject.transform.localScale = Vector3.Lerp(targetObject.transform.localScale, currentPos.localScale, speed);
        targetObject.transform.rotation = Quaternion.Slerp(targetObject.transform.rotation, currentPos.rotation, speed);
    }
    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        yield return new WaitForSeconds(2);
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        currentPos = targetPosistion;
        StartCoroutine(FadeTextToFullAlpha(1f, presenText));
    }

    void FixedUpdate()
    {

    }
}
