using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateFieldScript : MonoBehaviour
{
    private CrateTask ct;
    public GameObject Crate;
    // Start is called before the first frame update
    void Start()
    {
        ct = this.transform.parent.GetComponent<CrateTask>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject == Crate){
            ct.correctCrateEntered(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if(other.gameObject == Crate){
            ct.correctCrateRemoved(this.gameObject);
        }
    }
}
