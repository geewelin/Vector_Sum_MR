using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceLine : MonoBehaviour
{

    [SerializeField] GameObject StartPoint, EndPoint;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = (EndPoint.transform.localPosition - StartPoint.transform.localPosition)*0.5f + StartPoint.transform.localPosition;
        gameObject.transform.LookAt(EndPoint.transform);
        gameObject.transform.Rotate(90f, 0f, 0f);
    }
}
