using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Controller : abstractLevelController
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("OculusInteractionRig").transform.position = new Vector3(0f,0f,0f);
    }

        protected override void handleSequence(){
        if(currentTaskNumber == 0){
           
            GlobalFunctions.Instance.WriteDebugText( "Task fully completed");
            GameObject.Find("Key").transform.position = GameObject.Find("KeyPosition").transform.position;
        }
        else if(currentTaskNumber == 1){
            GameObject.Find("DoorLeft").GetComponent<BoxCollider>().enabled = true;
            GameObject.Find("DoorRight").GetComponent<BoxCollider>().enabled = true;
            Destroy(GameObject.Find("DoorLock"));
            GameObject.Find("EndTrigger").GetComponent<BoxCollider>().enabled = true;

        }
    }
}
