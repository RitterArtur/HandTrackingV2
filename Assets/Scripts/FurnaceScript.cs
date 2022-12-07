using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceScript : Tasks
{
    private GameObject key;
    private GameObject copperBar;
    private bool barInPlace;
    private GameObject smoke;
    public GameObject lever;
    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.Find("Key");
        copperBar = GameObject.Find("CopperBar");
        smoke = GameObject.Find("Smoke");
    }

    public override bool call()
    {
        //Debug.Log(lever.transform.localRotation.x);
        if (lever.transform.localRotation.x > 0.95f)
        {
            return leverPulledDown();
        }
        smoke.GetComponent<ParticleSystem>().Stop(true);
        return false;
    }

    public override void init()
    {

    }

    private bool leverPulledDown()
    {
        if (smoke.GetComponent<ParticleSystem>().isPaused || smoke.GetComponent<ParticleSystem>().isStopped)
        {
            smoke.GetComponent<ParticleSystem>().Play();
        }

        if (barInPlace)
        {
            key.transform.position = copperBar.transform.position;
            Destroy(copperBar);
            return true;
        }

        return false;
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        if (other.gameObject == copperBar)
        {
            barInPlace = true;
            Debug.Log("Bar entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject == copperBar)
        {
            barInPlace = false;
            Debug.Log("Bar removed");
        }
    }
}
