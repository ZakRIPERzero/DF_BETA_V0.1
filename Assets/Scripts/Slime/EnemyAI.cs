using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using static DangeonForge.Utils.Utils;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private State startingState;
    [SerializeField] private float roamingDistanceMax = 7f;
    [SerializeField] private float roamingDistanceMin = 2f;
    [SerializeField] private float roamingTimeMax = 2f;

    private NavMeshAgent navMeshAgent;
    private State state;
    private float roamingTime;
    private Vector3 roanPosition;
    private Vector3 startingPosition;
    private enum State
    {
       
        Roaming
    }

   

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        state = startingState;
    }


    private void Update()
    {
        switch (state)
        {
            default:
            
            case State.Roaming:
                roamingTime -= Time.deltaTime;
                if (roamingTime < 0)
                {
                    Roaming();
                    roamingTime = roamingTimeMax;
                }

                break;
        }

    }
    private void Roaming() {
        startingPosition = transform.position;
        roanPosition = GetRoamingPosition();
        ChangeFacingDirection(startingPosition, roanPosition);
        navMeshAgent.SetDestination(roanPosition);
    }
    private Vector3 GetRoamingPosition(){
    return startingPosition + GetRandomDir() * UnityEngine.Random.Range(roamingDistanceMin, roamingDistanceMax);}

    private void ChangeFacingDirection(Vector3 sourcePosition, Vector3 targetPosition) { 
    if(sourcePosition.x > targetPosition.x) {transform.rotation = Quaternion.Euler(0, -180, 0); 
        }
        else { transform.rotation = Quaternion.Euler(0, 0, 0); }

    }


}
