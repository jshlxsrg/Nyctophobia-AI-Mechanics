using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace JU
{
    public class EnemyWander : MonoBehaviour
    {
        public float wanderRadius;
        public float wanderTimer;

        private NavMeshAgent navMeshAgent;
        private float timer;

        // Use this for initialization
        void OnEnable()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            timer = wanderTimer;
        }

        // Update is called once per frame
        void Update()
        {
            
        }


        public void Wander() 
        {
            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                navMeshAgent.SetDestination(newPos);
                timer = 0;
            }

            static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
            {
                Vector3 randDirection = Random.insideUnitSphere * dist;

                randDirection += origin;

                NavMeshHit navHit;

                NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

                return navHit.position;
            }
        }
    }
}
