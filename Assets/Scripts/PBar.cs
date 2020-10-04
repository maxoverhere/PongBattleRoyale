using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBar : MonoBehaviour
{

    public bool     bLocal      = true;
    public float    speed       = 10.0f;
    public float    range       = 10.0f;
    public Vector3  vecCenter;
    public Vector3  vecDirection;

    private Vector3 vecMaxR;
    private Vector3 vecMinR;

    // Start is called before the first frame update
    void Start()
    {
        // Center object to its axis
        transform.position = vecCenter;

        // Rotate by vec direction
        this.transform.Rotate(0.0f, -Mathf.Rad2Deg * Mathf.Atan(vecDirection.z / vecDirection.x), 0.0f, Space.Self);

        // Calculate the upper and lower vecs
        Vector3 vecUnit = vecDirection / vecDirection.magnitude * range;
        vecMaxR = vecCenter + vecUnit;
        vecMinR = vecCenter - vecUnit;
    }

    // Update is called once per frame
    void Update()
    {
        if(bLocal){
            // use keyboard input
            float x = Input.GetAxis("Horizontal");
            

            transform.position = transform.position + x * speed * vecDirection * Time.deltaTime;

            // Check boundary with range
            float fMag = (transform.position - vecCenter).magnitude;
            
            if (fMag > range){
              if ((transform.position - vecMaxR).magnitude - (transform.position - vecMinR).magnitude < 0){
                  transform.position = vecMaxR;
              }else{
                  transform.position = vecMinR;
              }
            }

            // Push our location 
        }else{
            // Network position retreive 
        }
    }
}
