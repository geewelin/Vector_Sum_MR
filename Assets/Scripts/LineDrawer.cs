using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XRTools.Rendering;

public class LineDrawer : MonoBehaviour
{
    private XRLineRenderer xr_renderer;
    private bool grabbed;

    [SerializeField] public GameObject ArrowGrab;

    private GameObject pfArrowObject, pfArrowHead;


    // Start is called before the first frame update
    void Start()
    {
        xr_renderer = this.GetComponentInChildren<XRLineRenderer>();
        grabbed = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed)
        {

            xr_renderer.SetPosition(1, ArrowGrab.transform.position - this.transform.position);
        }
    }


    //Setze StartingPoint; wird beim Grab aufgerufen
    public void SetStartingPoint()
    {

        grabbed = true;
        xr_renderer.SetVertexCount(2);
        xr_renderer.useWorldSpace = true;
        xr_renderer.SetPosition(0, Vector3.zero);

    }


    public void SetEndingPoint()
    {

        pfArrowHead = Resources.Load("Prefabs/Pfeilspitze") as GameObject;
        GameObject ArrowHead = Instantiate(pfArrowHead, this.transform);
        ArrowHead.transform.localPosition = ArrowGrab.transform.position - this.transform.position;
        ArrowHead.transform.localRotation = Quaternion.LookRotation(ArrowHead.transform.localPosition);

        pfArrowObject = Resources.Load("Prefabs/ArrowObject") as GameObject;
        Instantiate(pfArrowObject, ArrowGrab.transform.position, Quaternion.identity);


        grabbed = false;
        ArrowGrab.SetActive(false);


    }





}
