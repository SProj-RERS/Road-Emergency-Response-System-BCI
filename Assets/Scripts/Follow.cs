using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject player;
    private Vector3 offset = new Vector3(-45, 10,0);
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
