using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public TMP_Text displayText;

    void Start()
    {
        displayText.text = ""; // Mengosongkan teks pada awalnya
    }

    void Update()
    {
        if (Input.anyKeyDown) // Memeriksa apakah tombol apa pun ditekan
        {
            string inputText = GetInputText(); // Mendapatkan teks input

            if (!string.IsNullOrEmpty(inputText))
            {
                displayText.text = inputText; // Menampilkan teks input terbaru
            }
        }
    }

    string GetInputText()
    {
        string inputText = "Menekan Tombol" + "\n";

        // Tombol Keyboard
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                inputText = keyCode.ToString();
                break;
            }
        }

        // Tombol Mouse
        if (Input.GetMouseButtonDown(0))
        {
            inputText = "Mouse Button 0";
        }
        else if (Input.GetMouseButtonDown(1))
        {
            inputText = "Mouse Button 1";
        }
        else if (Input.GetMouseButtonDown(2))
        {
            inputText = "Mouse Button 2";
        }

        return inputText;
    }
}