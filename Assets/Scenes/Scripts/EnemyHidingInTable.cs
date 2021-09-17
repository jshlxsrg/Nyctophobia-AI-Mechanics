using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace JU
{
    public class EnemyHidingInTable : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;


        public Transform tableWaypoint;
        public Transform tableOutWaypoint;


        private void Awake()
        {
            navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        }


        public void TableHide()
        {
            navMeshAgent.destination = tableWaypoint.position;

        }
        public void TableOut()
        {
            navMeshAgent.destination = tableOutWaypoint.position;
        }
    }
}
