using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TableController : MonoBehaviour
{

    public GameObject txtToDisplay;

    private bool playerInZone;
    private bool tableAvailable;


    private MeshCollider tableMeshCollider;


    private void Start()
    {
        tableAvailable = false;
        playerInZone = false;
        tableMeshCollider = GetComponent<MeshCollider>();
        txtToDisplay.SetActive(false);



    }

    enum TableState
    {
        Unavailable,
        Available
    }

    TableState tableState = new TableState();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            txtToDisplay.SetActive(true);
            playerInZone = true;
        }
        if (other.CompareTag("Hiding Enemy"))
        {
            GameObject.FindGameObjectWithTag("Hiding Enemy").GetComponentInChildren<MeshRenderer>().enabled = false;
        }
        if (other.CompareTag("Enemy"))
        {
            GameObject.FindGameObjectWithTag("Enemy").GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            txtToDisplay.SetActive(false);
            playerInZone = false;
        }
        if (other.CompareTag("Hiding Enemy"))
        {
            GameObject.FindGameObjectWithTag("Hiding Enemy").GetComponentInChildren<MeshRenderer>().enabled = true;
        }
        if (other.CompareTag("Enemy"))
        {
            GameObject.FindGameObjectWithTag("Enemy").GetComponentInChildren<MeshRenderer>().enabled = true;
        }
    }

   private void Update()
    {
        if (playerInZone)
        {
            if (tableState == TableState.Available)
            {
                txtToDisplay.GetComponent<Text>().text = "Press 'E' to Exit";
                tableMeshCollider.enabled = true;
            }
            else if (tableState == TableState.Unavailable)
            {
                txtToDisplay.GetComponent<Text>().text = "Press 'E' to Hide";
                tableMeshCollider.enabled = false;
            }

        }

        if (Input.GetKeyDown(KeyCode.E) && playerInZone)
        {
            tableAvailable = !tableAvailable;           

            if (tableState == TableState.Unavailable)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<MeshRenderer>().enabled = false;
                tableState = TableState.Available;
            }
            else if (tableState == TableState.Available)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<MeshRenderer>().enabled = true;
                tableState = TableState.Unavailable;

            }
        }
    }

}
