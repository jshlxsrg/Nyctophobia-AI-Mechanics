using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace JU
{
    public class LockerHidingTrigger: MonoBehaviour
    {
        EnemyHidingInLocker enemyHidingInLocker;
        Renderer render;

        public Transform lockerHidingEnemy;

        private Color origColor = Color.white;

        private void Awake()
        {
            render = GetComponent<Renderer>();
            enemyHidingInLocker = GetComponentInChildren<EnemyHidingInLocker>();
        }
        private void OnTriggerEnter(Collider other)
        {
            origColor = render.material.color;
            render.material.color = Color.red;
            if (other.CompareTag("Player"))
            {
                enemyHidingInLocker.LockerHide();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            render.material.color = origColor;
           if (other.CompareTag("Player"))
            {
                enemyHidingInLocker.LockerOut();
            }
        }


    }
}
