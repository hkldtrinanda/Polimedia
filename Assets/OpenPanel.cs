using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameObject panel; // Reference to the panel you want to open

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // You can modify the tag as needed
        {
            panel.SetActive(true); // Open the panel when collision occurs with an object tagged as "Player"
        }
    }
}
