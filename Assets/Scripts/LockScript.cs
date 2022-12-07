using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : Tasks
{
    public GameObject Key;
    private Bounds lockBounds;
    private Bounds KeyBounds;
    private bool open;
    public override bool call(){
        if(open){
            Destroy(Key);
            return true;
        }
        return false;
    }

    public override void init()
    {
        lockBounds = this.GetComponent<BoxCollider>().bounds;
        KeyBounds = Key.GetComponent<BoxCollider>().bounds;
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject == Key){
            open = true;
        }
    }
}
