using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JU
{
    public class WallController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Hiding Enemy"))
            {
                GameObject.FindGameObjectWithTag("Hiding Enemy").GetComponentInChildren<MeshRenderer>().enabled = false;
            }
            if (other.CompareTag("Hiding Enemy"))
            {
                GameObject.FindGameObjectWithTag("Hiding Enemy").GetComponentInChildren<MeshRenderer>().enabled = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Hiding Enemy"))
            {
                GameObject.FindGameObjectWithTag("Hiding Enemy").GetComponentInChildren<MeshRenderer>().enabled = true;
            }
            if (other.CompareTag("Hiding Enemy"))
            {
                GameObject.FindGameObjectWithTag("Hiding Enemy").GetComponentInChildren<MeshRenderer>().enabled = true;
            }
        }

    }
}
