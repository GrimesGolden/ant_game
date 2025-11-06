using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    [SerializeField] Transform target; 
    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); 
    }
    void Start()
    {
        agent.SetDestination(target.position); 
    }
    void Update()
    {
        agent.SetDestination(target.position); 
    }
}
