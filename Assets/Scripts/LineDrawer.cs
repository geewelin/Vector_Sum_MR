using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XRTools.Rendering;

public class LineDrawer : MonoBehaviour
{
    private XRLineRenderer xr_renderer;
    private bool grabbed;

    [SerializeField] public GameObject ArrowHead;


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
            xr_renderer.SetPosition(1, ArrowHead.transform.position);
        }
    }


    //Setze StartingPoint; wird beim Grab aufgerufen
    public void SetStartingPoint()
    {

        grabbed = true;
        xr_renderer.SetVertexCount(2);
        xr_renderer.SetPosition(0, ArrowHead.transform.position);

    }


    public void SetEndingPoint()
    {
        grabbed = false;
    }





}
