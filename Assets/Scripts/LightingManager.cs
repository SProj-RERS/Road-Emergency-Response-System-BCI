using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    public List<Light> lights;

    public virtual void ToggleHeadLights()
    {
        foreach(Light light in lights)
        {
            light.intensity = light.intensity == 0 ? 20 : 0; 
        }
    }
}
