using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class Rotates : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector3 RotationSpeed = new Vector3(0, 36, 0);

    // Update is called once per frame
    
    void Update()
    {
        this.transform.Rotate(RotationSpeed * Time.deltaTime);
    }
}
