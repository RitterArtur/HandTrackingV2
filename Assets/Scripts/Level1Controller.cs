using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class Level1Controller : abstractLevelController
{
    GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        taskOrder[currentTaskNumber].init();
        GameObject.Find("OculusInteractionRig").transform.position = new Vector3(0f,0f,0f);
        key = GameObject.Find("Key");
        key.GetComponent<Grabbable>().enabled = false;
    }



    protected override void handleSequence(){
        if(currentTaskNumber == 0){
            Destroy(GameObject.Find("Lid"));
            SoundManager.instance.Play("Ding");
            key.GetComponent<Grabbable>().enabled =true;
        }
        else if(currentTaskNumber == 1){
            GameObject.Find("DoorLeft").GetComponent<BoxCollider>().enabled = true;
            GameObject.Find("DoorRight").GetComponent<BoxCollider>().enabled = true;
            Destroy(GameObject.Find("DoorLock"));
            GameObject.Find("EndTrigger").GetComponent<BoxCollider>().enabled = true;
        }
    }


}
