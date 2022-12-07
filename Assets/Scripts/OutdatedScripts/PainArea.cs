using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainArea : MonoBehaviour
{
    public ParticleSystem pain;
    bool leftHandIn;
    bool rightHandIn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

            private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.transform.parent.parent.parent.name.Contains("Right") )
            {
                rightHandIn = true;
                if(pain.isPaused || pain.isStopped){
                   pain.Play();
               }
            }
            else if(other.gameObject.transform.parent.parent.parent.name.Contains("Left") ){
                leftHandIn = true;
                if(pain.isPaused || pain.isStopped){
                   pain.Play();
               }
            }


    }

    private void OnTriggerExit(Collider other)
    {
        if ( other.gameObject.transform.parent.parent.parent.name.Contains("Right") )
            {
                rightHandIn = false;
            }
            else if(other.gameObject.transform.parent.parent.parent.name.Contains("Left") ){
                leftHandIn = false;
            }

        if(!rightHandIn && !leftHandIn)
            pain.Stop();

    }
}
