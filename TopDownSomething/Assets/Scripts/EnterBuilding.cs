using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnterBuilding : MonoBehaviour
{
    public GameObject tilemap;
    private bool isEntered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tilemap.SetActive(false);
        isEntered = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        tilemap.SetActive(true);
    }

}


