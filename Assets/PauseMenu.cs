using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    private void Start()
    {
        // Sembunyikan menu saat permainan dimulai
        pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        // Cek apakah tombol ESC ditekan
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                // Unpause permainan
                ResumeGame();
            }
            else
            {
                // Jeda permainan
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        // Tampilkan menu jeda
        pauseMenuUI.SetActive(true);
        // Set timescale menjadi 0 untuk menghentikan permainan
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame()
    {
        // Sembunyikan menu jeda
        pauseMenuUI.SetActive(false);
        // Set timescale menjadi 1 untuk melanjutkan permainan
        Time.timeScale = 1f;
        isPaused = false;
    }
}