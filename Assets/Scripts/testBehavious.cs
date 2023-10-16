using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBehavious : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("testing start");
    }
     void Awake()
    {
        Debug.Log("testing awake");

    }
    private void OnEnable()
    {
        Debug.Log("testing enable");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
