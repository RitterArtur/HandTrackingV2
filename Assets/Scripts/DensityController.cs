using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DensityController : MonoBehaviour
{

    private GameObject area;
    private Transform actualPosition;
    private Vector3 offset;
    private Transform HandTransform;
    private Vector3 insertionPoint;
    private bool firstTick = false;
    private BoxCollider coll;
    private SkinnedMeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        area = GameObject.Find("Slowfield");
        actualPosition = this.transform;
        HandTransform = actualPosition.GetChild(0);
        coll = area.GetComponent<BoxCollider>();
        mesh = GameObject.Find("OculusHand_R").GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void applyDensity(){
        if(coll.bounds.Contains(mesh.bounds.center) ){
            if(!firstTick){
                firstTick = true;
                insertionPoint = actualPosition.position;
            }
            //offset.position = Vector3.Distance(insertionPoint,actualPosition.position);

            offset = actualPosition.position - insertionPoint ;
            HandTransform.position = actualPosition.position - offset;
            GlobalFunctions.Instance.WriteDebugText("Im in");

        }else{
            firstTick = false;
            HandTransform.position = actualPosition.position;
        }
    }


}
