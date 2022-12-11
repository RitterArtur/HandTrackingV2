using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMaterialScript : MonoBehaviour
{
    SkinnedMeshRenderer meshRenderer;
    Material ocMaterial;
    Material iceMaterial;
    Material copperMaterial;
    float frostStr;
    float timeElapsed;
    private bool copperGrabbed;
    private bool cold;
    private bool inUse;
    // Start is called before the first frame update
    void Start()
    {
        inUse = GlobalFunctions.Instance.areVHsInUse();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        if (this.name.Contains("Left"))
            ocMaterial = (Material)Resources.Load("Materials/LeftOculusHand");
        else
            ocMaterial = (Material)Resources.Load("Materials/RightOculusHand");

        iceMaterial = (Material)Resources.Load("Materials/IceMat");
        copperMaterial = (Material)Resources.Load("Materials/Copper");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(frostStr>0.001f){
            frostStr = Mathf.Lerp(0.0001f, frostStr, Time.deltaTime /100f);
            timeElapsed += Time.deltaTime;
            GlobalFunctions.Instance.WriteDebugText(frostStr.ToString());
            iceMaterial.SetFloat("Vector1_Fresnel",frostStr);
        }
        */
    }

    void updateMaterials()
    {
        if (!inUse)
            return;

        Material[] mats;
        if (copperGrabbed)
        {
            if (cold)
            {
                mats = new Material[] { ocMaterial, copperMaterial, iceMaterial };
                frostStr=0.6f;
            }
            else
            {
                mats = new Material[] { ocMaterial, copperMaterial };
            }
        }
        else
        {
            if (cold)
            {
                mats = new Material[] { ocMaterial,iceMaterial };
                frostStr=0.6f;
            }
            else
            {
                mats = new Material[] { ocMaterial };
            }
        }

        meshRenderer.materials = mats;
    }

    public void copperGrab(bool t)
    {
        copperGrabbed = t;
        updateMaterials();
    }
    public void handCold(bool b)
    {
        cold = b;
        updateMaterials();
    }


}
