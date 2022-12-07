using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrateTask : Tasks
{
    private bool b1;
    private bool b2;
    private bool b3;
    public override bool call()
    {
        if(b1 && b2 && b3){
            GetComponentInChildren<TextMeshProUGUI>().text = "CORRECT";
            return true;
        }
        return false;
    }

    public override void init()
    {
        /*
        fieldOne = GameObject.Find("Field 1");
        fieldTwo = GameObject.Find("Field 2");
        fieldThree = GameObject.Find("Field 3");

        crateOne = GameObject.Find("Crate 1");
        crateTwo = GameObject.Find("Crate 2");
        crateThree = GameObject.Find("Crate 3");
        */
    }

    public void correctCrateEntered(GameObject caller){
        if(caller.name.Contains("1")){
            b1=true;
        }
        else if(caller.name.Contains("2"))
            b2=true;
        else if(caller.name.Contains("3"))
            b3=true;

    }

       public void correctCrateRemoved(GameObject caller){
        if(caller.name.Contains("1")){
            b1=false;
        }
        else if(caller.name.Contains("2"))
            b2=false;
        else if(caller.name.Contains("3"))
            b3=false;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


}
