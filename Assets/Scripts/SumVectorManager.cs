using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XRTools.Rendering;

public class SumVectorManager : MonoBehaviour
{

    public static SumVectorManager Instance { get; private set; }

    private XRLineRenderer xr_renderer;
    private Vector3 startingPosition, endingPosition;
    private bool firstVectorPlaced = false;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this); 
        }
        else
        {
            Instance = this;
        }
    }


    private void Start()
    {
        xr_renderer = this.GetComponent<XRLineRenderer>();
    }



    public void SetStartingPoint (Vector3 pos)
    {
        startingPosition = pos;
    }

    public void SetEndingPoint(Vector3 arrowHeadPos)
    {
        if (!firstVectorPlaced)
        {
            firstVectorPlaced = true;
        }
        else
        {
            endingPosition = arrowHeadPos;

            //Pfeilspitze instantiaten? --> object anlegen, da nur eine Pfeilspitze da sein darf
        }
    }

    public void Draw()
    {
        if (endingPosition != Vector3.zero)
        {
            xr_renderer.enabled = true;
            xr_renderer.SetVertexCount(2);
            xr_renderer.SetPosition(0, startingPosition);
            xr_renderer.SetPosition(1, endingPosition);
        }

    }

    public void Hide()
    {
        xr_renderer.enabled = false;
    }



}
