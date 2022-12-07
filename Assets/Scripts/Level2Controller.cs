using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : abstractLevelController
{

    public Material keyMaterial;
    private Material copperMaterial;
    private HandMaterialScript lHand;
    private HandMaterialScript rHand;
    public GameObject handSmokeParent;


    // Start is called before the first frame update
    void Start()
    {
        taskOrder[currentTaskNumber].init();
        keyMaterial.SetColor("_EmissionColor", new Color(0.0f, 0.0f, 0.0f, 1.0f) * -10);
        keyMaterial.EnableKeyword("_EMISSION");
        lHand = GameObject.Find("LeftHand").GetComponent<HandMaterialScript>();
        rHand = GameObject.Find("RightHand").GetComponent<HandMaterialScript>();
        copperMaterial = (Material)Resources.Load("Materials/Copper");
        GameObject.Find("OculusInteractionRig").transform.position = new Vector3(2.27f,0f,0.2f);
    }



    protected override void handleSequence()
    {
        if (currentTaskNumber == 0)
        {

            //Emmision Color 255,54,0
            //keyMaterial.EnableKeyword("_EMISSION");
            keyMaterial.SetColor("_EmissionColor", new Color(1.0f, 0.2f, 0.0f, 1.0f) * 1.0f);
            keyMaterial.EnableKeyword("_EMISSION");

            copperMaterial.SetColor("_EmissionColor", new Color(0.72f, 0.1f, 0.04f, 1.0f));
            copperMaterial.EnableKeyword("_EMISSION");
            SoundManager.instance.Play("Ding");

        }
        else if (currentTaskNumber == 1)
        {
            keyMaterial.SetColor("_EmissionColor", new Color(0.0f, 0.0f, 0.0f, 1.0f) * -10.0f);
            handSmokeParent.SetActive(false);
            keyMaterial.DisableKeyword("_EMISSION");

            copperMaterial.SetColor("_EmissionColor", new Color(0.0f, 0.0f, 0.0f, 1.0f) * -10.0f);
            copperMaterial.DisableKeyword("_EMISSION");
            SoundManager.instance.Play("Ding");
        }
        else if(currentTaskNumber == 2){
            GameObject.Find("DoorLeft").GetComponent<BoxCollider>().enabled = true;
            GameObject.Find("DoorRight").GetComponent<BoxCollider>().enabled = true;
            Destroy(GameObject.Find("DoorLock"));
            GameObject.Find("EndTrigger").GetComponent<BoxCollider>().enabled = true;
        }

        
    }

    public void onGrabLevelEvent(GameObject caller, GameObject item)
    {


        if (item.name == "CopperBar" || item.name.Contains("Key"))
        {
            if(GlobalFunctions.Instance.areVHsInUse()){
            if (caller.name.Contains("Right"))
            {
                rHand.copperGrab(true);
            }
            else if (caller.name.Contains("Left"))
            {

                lHand.copperGrab(true);
            }
            }
        }

        if (item.name.Contains("Key") && currentTaskNumber == 1)
        {
            handSmokeParent.SetActive(true);
            handSmokeParent.GetComponent<AttachToTarget>().newGrabpoint(caller);
            return;
        }
    }



    public void onDropEvent(GameObject caller)
    {
        handSmokeParent.SetActive(false);
        if (caller.name.Contains("Right"))
        {
            rHand.copperGrab(false);
        }
        else if (caller.name.Contains("Left"))
        {
            lHand.copperGrab(false);
        }
    }
}
