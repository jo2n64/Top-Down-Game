using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawn : MonoBehaviour
{
    public GameObject log;
    public Transform logPos;
    public float spawnDiff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("Spawn", spawnDiff);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CancelInvoke();
    }

    void Spawn() {
        Instantiate(log, logPos.position, Quaternion.identity);
    }
}
