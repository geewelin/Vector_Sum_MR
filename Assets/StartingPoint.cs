using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPoint : MonoBehaviour
{

    private GameObject pfArrowObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnVector()
    {
        pfArrowObject = Resources.Load("Prefabs/ArrowObject") as GameObject;
        Instantiate(pfArrowObject, this.transform.position, Quaternion.identity);
        this.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().enabled = false;
    }
}
