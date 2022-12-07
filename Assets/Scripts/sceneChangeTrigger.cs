using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChangeTrigger : MonoBehaviour
{
    public string nextScence;
    Material fadeMat ;
    float transpVal= .0f;
    // Start is called before the first frame update
    void Start()
    {
        fadeMat = (Material)Resources.Load("Materials/BackScreen");
    }

    // Update is called once per frame
    void Update()
    {
        fadeMat.color = new UnityEngine.Color(fadeMat.color.r, fadeMat.color.g, fadeMat.color.b, Mathf.Lerp(fadeMat.color.a, transpVal, Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.name.Equals("RigTrigger"))
        {
             GlobalFunctions.Instance.WriteDebugText("Im in");
            if(nextScence.Equals("Last")){
                transpVal = 1.5f;
            }else
                loadNextScene();
        }

    }


    void loadNextScene(){
        

        SceneManager.LoadScene(nextScence);
    }
}
