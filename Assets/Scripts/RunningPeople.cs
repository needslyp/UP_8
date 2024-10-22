using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningPeople : MonoBehaviour
{
    public float speed = 5f;
    public GameObject[] people;

    public GameObject palka;

    private int currentPersonIndex;
    private int nextPersonIndex;


    void Start()
    {
        currentPersonIndex = 0;
        nextPersonIndex = 1;
        
        people[currentPersonIndex].transform.LookAt(people[nextPersonIndex].transform);
    }

    void Update()
    {
        people[currentPersonIndex].transform.position = Vector3.MoveTowards(people[currentPersonIndex].transform.position, 
                                                                            people[nextPersonIndex].transform.position, Time.deltaTime * speed);

        if (people[currentPersonIndex].transform.position == people[nextPersonIndex].transform.position)
        {
            currentPersonIndex = nextPersonIndex;
            nextPersonIndex = (nextPersonIndex + 1) % people.Length;

            people[currentPersonIndex].transform.LookAt(people[nextPersonIndex].transform);
            palka.transform.SetParent(people[currentPersonIndex].transform);
        }
    }
}
