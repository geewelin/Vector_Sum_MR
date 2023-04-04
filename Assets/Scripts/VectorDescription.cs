using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class VectorDescription : MonoBehaviour
{

    private TextMeshProUGUI textComponent;


    private float RoundToDecimal(int dec, float f)
    {
        float res = f;
        float teiler = Mathf.Pow(10f, (float)dec);

        res *= teiler;
        res = Mathf.Round(res);
        res /= teiler;

        return res;

    }
    
    
    private Vector3 VecRounded(int dec, Vector3 vec)
    {
        Vector3 res = vec;

        res.x = RoundToDecimal(dec, res.x);
        res.y = RoundToDecimal(dec, res.y);
        res.z = RoundToDecimal(dec, res.z);

        return res;
    }

    public void Set(string vname, Vector3 pos, bool length = false)
    {
        textComponent = this.GetComponentInChildren<TextMeshProUGUI>();
        Vector3 res = VecRounded(2, pos);
        ToggleInformationManager.Instance.AddPlacedVectorPosition(res);
        textComponent.text = vname + ": (x = " + res.x + "m, y = " + res.y + "m, z = " + res.z + "m)";
        if (length)
        {
            textComponent.text += ", length = " + RoundToDecimal(2, res.magnitude) + "m";
        }
    }

    public void SetTextColor(Color c)
    {
        textComponent.color = c;
    }


}
