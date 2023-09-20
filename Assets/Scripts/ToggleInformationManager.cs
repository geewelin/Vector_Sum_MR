using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XRTools.Rendering;

public class ToggleInformationManager : MonoBehaviour
{

    public static ToggleInformationManager Instance { get; private set; }

    private XRLineRenderer xr_renderer;
    private Vector3 startingPosition, endingPosition;
    private bool firstVectorPlaced = false;

    //Liste von platzierten Vektoren
    private List<Vector3> vectorPositions;

    //Liste von Vector labels zum togglen
    private List<GameObject> vectorDescriptions;

    private GameObject pfVectorDescription, description;


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
        xr_renderer = this.GetComponentInChildren<XRLineRenderer>();
        vectorPositions = new();
        vectorDescriptions = new();

        pfVectorDescription = Resources.Load("Prefabs/VectorDescription") as GameObject;
        description = Instantiate(pfVectorDescription, this.transform);
        description.SetActive(false);
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


    public void AddPlacedVectorDescription(GameObject vecDescription)
    {

        vectorDescriptions.Add(vecDescription);

    }

    public void AddPlacedVectorPosition(Vector3 vecPosition)
    {
        vectorPositions.Add(vecPosition);
    }



    private void UpdateLine()
    {           
        //Vector
        xr_renderer.enabled = true;
        xr_renderer.SetVertexCount(2);
        xr_renderer.useWorldSpace = true;
        xr_renderer.SetPosition(0, startingPosition);
        xr_renderer.SetPosition(1, endingPosition);

    }


    public void Draw()
    {
        //Sum Vector
        if (endingPosition != Vector3.zero)
        {

            UpdateLine();

            //Vector Description

            description.SetActive(true);
            description.transform.position = (endingPosition + startingPosition) / 2f;
            description.transform.LookAt(endingPosition);
            Vector3 vecTranslation = new(0f, -0.01f, 0f);
            description.transform.Translate(vecTranslation); //Position leicht unter Vector schieben

            description.GetComponent<VectorDescription>().Set("vsum", endingPosition - startingPosition, true);
            description.GetComponent<VectorDescription>().SetTextColor(new Color(0.172549f, 0.9333333f, 0.9098039f));
            
        }

        //Single Vector Descriptions
        foreach (GameObject des in vectorDescriptions)
        {
            des.SetActive(true);
        }

    }

    public void Hide()
    {
        xr_renderer.enabled = false;

        foreach (GameObject des in vectorDescriptions)
        {
            des.SetActive(false);
        }

        description.SetActive(false);

        //TODO: destroy earlier description object
    }

    public void Reset()
    {
        
    }




}
