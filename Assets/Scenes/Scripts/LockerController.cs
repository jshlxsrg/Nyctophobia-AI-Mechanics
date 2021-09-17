using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JU
{
    public class LockerController : MonoBehaviour
    {
        public GameObject txtToDisplay;

        private bool playerInZone;
        private bool lockerOpened;

        private Animator lockerAnimator;
        

       enum LockerState
        {
            Closed,
            Opened
        }

        LockerState lockerState = new LockerState();
        private void Start()
        {
            lockerOpened = false;
            playerInZone = false;
            lockerState = LockerState.Closed;
            txtToDisplay.SetActive(false);
            

            lockerAnimator = transform.parent.gameObject.GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            txtToDisplay.SetActive(true);
            playerInZone = true;
            if (other.CompareTag("Hiding Enemy"))
            {
                lockerAnimator.SetTrigger("Activate");
                txtToDisplay.SetActive(false);
            }
            if (other.CompareTag("Hiding Enemy"))
            {
                lockerAnimator.SetTrigger("Activate");
                txtToDisplay.SetActive(false);
            }

        }

        private void OnTriggerExit(Collider other)
        {
            txtToDisplay.SetActive(false);
            playerInZone = false;
            if (other.CompareTag("Hiding Enemy"))
            {
                lockerAnimator.SetTrigger("Activate");
                txtToDisplay.SetActive(false);

            }
            if (other.CompareTag("Enemy"))
            {
                lockerAnimator.SetTrigger("Activate");
                txtToDisplay.SetActive(false);
            }
        }

        private void Update()
        {
            if (playerInZone)
            {
                if (lockerState == LockerState.Opened)
                {
                   txtToDisplay.GetComponent<Text>().text = "Press 'E' to Close";
                }
                else if (lockerState == LockerState.Closed)
                {
                   txtToDisplay.GetComponent<Text>().text = "Press 'E' to Open";
                }

            }
            if (Input.GetKeyDown(KeyCode.E) && playerInZone)
            {
                lockerOpened = !lockerOpened;           //The toggle function of door to open/close
                if (lockerState == LockerState.Closed)
                {
                    lockerAnimator.SetTrigger("Activate");
                    lockerState = LockerState.Opened;
                }
                else if (lockerState == LockerState.Opened)
                {
                    lockerAnimator.SetTrigger("Activate");
                    lockerState = LockerState.Closed;
                }
            }
        }
    }
}
