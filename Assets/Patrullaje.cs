using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrullaje : MonoBehaviour
{
    public Transform Patrulla;
    public List<Transform> waypoint;

    private int locationIndex = 0;
    public NavMeshAgent agente;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agente.GetComponent<NavMeshAgent>();
        inicializaPatrulla();
        animator = GetComponent<Animator>();
    }

    void inicializaPatrulla()
    {
        foreach (Transform wp in Patrulla)
        {
            waypoint.Add(wp);
        }
    }

    void moveToNextPoint()
    {
        if(waypoint.Count==0)
        {
            return;
        }
        agente.SetDestination(waypoint[locationIndex].position);
        animator.CrossFadeInFixedTime("Walk", 0.1f);
        locationIndex = (locationIndex+1) % waypoint.Count;

    }
    // Update is called once per frame
    void Update()
    {
        if(agente.remainingDistance < 0.5f && ! agente.pathPending)
        {
            moveToNextPoint();
        }
    }
}
