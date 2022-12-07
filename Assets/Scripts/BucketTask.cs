using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketTask : Tasks
{
    private  GameObject Key;
    private bool keyEntered = false;
    private bool useVH;

    // Start is called before the first frame update
    void Start()
    {
        Key = GameObject.Find("Key");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool call(){

        if(keyEntered){
            return true;
        }
        return false;
    }

    public override void init()
    {
        useVH = GlobalFunctions.Instance.areVHsInUse();
    }

        private void OnTriggerEnter(Collider other)
    {
        
        if(other.name.Contains("Key")){
            Debug.Log("entered");
            keyEntered = true;
            return;
        }

            if (other.gameObject.transform.parent.parent.parent.name.Contains("Left"))
            {
                GlobalFunctions.Instance.getHandVisuals("left").GetComponent<HandMaterialScript>().handCold(true);
            }
            else if (other.gameObject.transform.parent.parent.parent.name.Contains("Right"))
            {
                GlobalFunctions.Instance.getHandVisuals("right").GetComponent<HandMaterialScript>().handCold(true);
            }

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject + " entered");
        if(other.name.Contains("Key")){
            keyEntered = false;
            return;
        }

    }

}
