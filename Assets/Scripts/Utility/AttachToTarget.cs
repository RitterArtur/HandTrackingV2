using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToTarget : MonoBehaviour
{
    public GameObject GrabPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = GrabPoint.transform.position;
    }

    public void newGrabpoint(GameObject grab){
        GrabPoint = grab;
    }
}
