using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace JU
{

    public class EnemyHidingInWall : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;


        public Transform wallWaypoint;
        public Transform wallOutWaypoint;


        private void Awake()
        {
            navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        }


        public void WallHide()
        {
            navMeshAgent.destination = wallWaypoint.position;

        }
        public void WallOut()
        {
            navMeshAgent.destination = wallOutWaypoint.position;
        }
    }
}
