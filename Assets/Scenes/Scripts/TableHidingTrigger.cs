using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace JU
{

    public class TableHidingTrigger : MonoBehaviour
    {
        EnemyHidingInTable enemyHidingInTable;
        Renderer render;

        public Transform tableHidingEnemy;

        private Color origColor = Color.white;

        private void Awake()
        {
            render = GetComponent<Renderer>();
            enemyHidingInTable = GetComponentInChildren<EnemyHidingInTable>();
        }
        private void OnTriggerEnter(Collider other)
        {
            origColor = render.material.color;
            render.material.color = Color.red;
            if (other.CompareTag("Player"))
            {
                enemyHidingInTable.TableHide();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            render.material.color = origColor;
            if (other.CompareTag("Player"))
            {
                enemyHidingInTable.TableOut();
            }
        }

    }
}
