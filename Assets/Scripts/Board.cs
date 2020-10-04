using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public PBar playerBar;

    public int      nPlayers = 3;
    public float    fGoalSize = 40;

    // Start is called before the first frame update
    void Start()
    {
        float fTheta = 360/nPlayers;

        float fPerpendicularDist = (float)(0.5 * fGoalSize / (Mathf.Tan( Mathf.Deg2Rad * fTheta/2  )));

        // Creating player
        Vector3 vecCenter = new Vector3(0.0f, 0.0f, -fPerpendicularDist);
        
        for (int i = 0; i < nPlayers; i++){
            // Rotate by theta around center
            
            PBar temp = Instantiate(playerBar) as PBar;
            temp.Init(vecCenter);
            vecCenter = Quaternion.Euler(0, fTheta, 0) * vecCenter;    
        }

    }
 

    // Update is called once per frame
    void Update()
    {
        
    }
}
