using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XRTools.Rendering;

public class LineDrawer : MonoBehaviour
{
    private XRLineRenderer xr_renderer;
    private bool grabbed;
    private static int arrowCount = 0;

    [SerializeField] public GameObject ArrowGrab;

    private GameObject pfArrowObject, pfArrowHead, pfVecDescription;


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
        LineDrawer.arrowCount += 1;

        pfArrowHead = Resources.Load("Prefabs/Pfeilspitze") as GameObject;
        GameObject ArrowHead = Instantiate(pfArrowHead, this.transform);
        ArrowHead.transform.localPosition = ArrowGrab.transform.position - this.transform.position;
        ArrowHead.transform.localRotation = Quaternion.LookRotation(ArrowHead.transform.localPosition);

        pfArrowObject = Resources.Load("Prefabs/ArrowObject") as GameObject;
        Instantiate(pfArrowObject, ArrowGrab.transform.position, Quaternion.identity);


        //SumVector Endpunkt updaten
        ToggleInformationManager.Instance.SetEndingPoint(ArrowHead.transform.position);




        //VectorDescription erstellen
        pfVecDescription = Resources.Load("Prefabs/VectorDescription") as GameObject;
        GameObject vecDescription = Instantiate(pfVecDescription, this.transform);
        vecDescription.transform.localPosition = (ArrowGrab.transform.position - this.transform.position) / 2f; //In die Mitte des Vectors positionieren
        vecDescription.transform.localRotation = Quaternion.LookRotation(ArrowHead.transform.localPosition); //Ausrichtung zur Vectorspitze
        Vector3 vecTranslation = new(0f, -0.01f, 0f);
        vecDescription.transform.Translate(vecTranslation); //Position leicht unter Vector schieben
        vecDescription.GetComponent<VectorDescription>().Set("v"+LineDrawer.arrowCount, ArrowGrab.transform.position - this.transform.position); //Parameter setzen
        vecDescription.SetActive(false);


        //platzierten Vector Manager hinzufügen
        ToggleInformationManager.Instance.AddPlacedVectorDescription(vecDescription);
        

        grabbed = false;
        ArrowGrab.SetActive(false);


    }





}
