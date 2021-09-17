using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace JU
{
    public class EnemyAI : MonoBehaviour
    {
        public Transform[] waypoints;
        public int speed;
        NavMeshAgent navMeshAgent;

        public int waypointIndex;
        private float distance;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        void Start()
        {
            waypointIndex = Random.Range(0, 8);
            navMeshAgent.transform.LookAt(waypoints[waypointIndex].position);
        }

        void Update()
        {
            distance = Vector3.Distance(navMeshAgent.transform.position, waypoints[waypointIndex].position);
            if (distance < 1f)
            {
                IncreaseIndex();
            }
            Patrol();
        }
        void Patrol()
        {
            navMeshAgent.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        void IncreaseIndex()
        {
            waypointIndex++;
        }
    }
}
