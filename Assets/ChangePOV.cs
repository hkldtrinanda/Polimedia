using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePOV : MonoBehaviour
{
    public GameObject firstPersonCamera, thirdPersonCamera,  firstPersonPlayer, thirdPersonPlayer;

    private bool isFirstPerson = true; // Menyimpan status POV saat ini

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // Ganti POV ketika tombol "C" ditekan
        {
            ChangePOVMode();
        }
    }

    public void ChangePOVMode()
    {
        isFirstPerson = !isFirstPerson; // Toggle antara mode orang pertama dan orang ketiga

        // Mengaktifkan atau menonaktifkan GameObject sesuai dengan mode POV yang aktif
        firstPersonCamera.SetActive(isFirstPerson);
        thirdPersonCamera.SetActive(!isFirstPerson);
        firstPersonPlayer.SetActive(isFirstPerson);
        thirdPersonPlayer.SetActive(!isFirstPerson);
        
    }
}