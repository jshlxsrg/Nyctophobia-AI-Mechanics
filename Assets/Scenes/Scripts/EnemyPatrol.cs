using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace JU
{


    public class EnemyPatrol : MonoBehaviour
    {

        [SerializeField] private Transform[] movePositionTransform;
        private int destinationPoint;

        NavMeshAgent navMeshAgent;
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            destinationPoint = Random.Range(0, 8);
            Patrol();
        }

        private void Update()
        {

            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            {
                Patrol();
            }
            
        }

        public void Patrol()
        {
            if (movePositionTransform.Length == 0)
            {
                return;
            }

            navMeshAgent.destination = movePositionTransform[destinationPoint].position;

            destinationPoint = (destinationPoint + 1) % movePositionTransform.Length;
            
        }
    }
}

