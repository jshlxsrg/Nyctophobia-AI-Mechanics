using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace JU
{
    public class WallHidingTrigger : MonoBehaviour
    {
        EnemyHidingInWall enemyHidingInWall;
        Renderer render;

        public Transform wallHidingEnemy;

        private Color origColor = Color.white;

        private void Awake()
        {
            render = GetComponent<Renderer>();
            enemyHidingInWall = GetComponentInChildren<EnemyHidingInWall>();
        }
        private void OnTriggerEnter(Collider other)
        {
            origColor = render.material.color;
            render.material.color = Color.red;
            if (other.CompareTag("Player"))
            {
                enemyHidingInWall.WallHide();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            render.material.color = origColor;
            if (other.CompareTag("Player"))
            {
                enemyHidingInWall.WallOut();
            }
        }

    }
}
