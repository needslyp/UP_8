using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class MovingScript : MonoBehaviour
{   
    public float speed = 1.0f;
    public Vector3[] vecs;
    
    private int currentTargetIndex;
    private bool forward = true;


    void Start()
    {
        transform.position = vecs[0];
        currentTargetIndex = 1;
        transform.LookAt(vecs[currentTargetIndex]);
    }

    void Update()
    {   
        transform.position = Vector3.MoveTowards(transform.position, vecs[currentTargetIndex], Time.deltaTime * speed);

        if (transform.position == vecs[currentTargetIndex])
        {
            if (0 >= currentTargetIndex || currentTargetIndex >= vecs.Length - 1)
            {
                forward = !forward;
            }
            
            currentTargetIndex = forward ? currentTargetIndex + 1 : currentTargetIndex - 1;
            transform.LookAt(vecs[currentTargetIndex]);
        }
        
    }
}
