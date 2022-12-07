using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDEffectTrigger : HUDEffects
{
    public Material stoneMaterial;

    // Start is called before the first frame update
    void Start()
    {
        children = new List<GameObject>();
        lHand = GlobalFunctions.Instance.getOVRHands()[0];
        rHand = GlobalFunctions.Instance.getOVRHands()[1];
        foreach (Transform child in itemParent.transform)
        {
            children.Add(child.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (inArea)
        {
            foreach (GameObject child in children)
            {
                float a = Vector3.Distance(child.transform.position, lHand.transform.position);
                float b = Vector3.Distance(child.transform.position, rHand.transform.position);
                if (a < triggerDistance|| b < triggerDistance)
                {
                    stoneMaterial.SetFloat("Size", 0.7f);
                    return;
                }
            }
            stoneMaterial.SetFloat("Size", 0.0f);
        }

    }
    public override bool isDone()
    {
        return inArea;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent.parent.parent.name.Contains("Left") || other.gameObject.transform.parent.parent.parent.name.Contains("Right"))
        {
            inArea = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.parent.parent.parent.name.Contains("Left") || other.gameObject.transform.parent.parent.parent.name.Contains("Right"))
        {
            inArea = false;
        }

    }
}
