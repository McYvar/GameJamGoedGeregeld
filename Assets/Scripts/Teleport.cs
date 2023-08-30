using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

    public Transform player, destination;
    public GameObject playerg;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerg.SetActive(false);
            player.position = destination.position;
            playerg.SetActive(true);

        }
    }
}
