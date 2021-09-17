using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



namespace JU
{
    public class EnemyHidingInLocker : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;

        
        public Transform lockerWaypoint;
        public Transform lockerOutWaypoint;


        private void Awake()
        {
            navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        }


        public void LockerHide()
        {
            navMeshAgent.destination = lockerWaypoint.position;

        }
        public void LockerOut()
        {
            navMeshAgent.destination = lockerOutWaypoint.position;
        }


    }
}
