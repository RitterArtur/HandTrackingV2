using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneHapticCollider : MonoBehaviour
{
    public Material stoneMaterial;
    // Start is called before the first frame update
    void Start()
    {
        //stoneMaterial = (Material)Resources.Load("Materials/StoneVig");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
        private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.transform.parent.parent.parent.name.Contains("Left") || other.gameObject.transform.parent.parent.parent.name.Contains("Right") )
            {
                stoneMaterial.SetFloat("Size",0.7f);
            }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.parent.parent.parent.name.Contains("Left") || other.gameObject.transform.parent.parent.parent.name.Contains("Right") )
            {
                stoneMaterial.SetFloat("Size",0.0f);
            }

    }
}
