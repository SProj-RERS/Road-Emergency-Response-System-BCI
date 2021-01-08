using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camswitch : MonoBehaviour
{
    public Camera FpsCam;
    public Camera TpsCam;
    bool fpsswitch = true;
    // Start is called before the first frame update
    void Start()
    {
        FpsCam.enabled = fpsswitch;
        TpsCam.enabled = !fpsswitch;
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.G)){
           fpsswitch = !fpsswitch;
           FpsCam.enabled = fpsswitch;
           TpsCam.enabled = !fpsswitch;
       } 
    }
}
