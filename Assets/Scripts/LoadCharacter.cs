using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public struct CharacterSpawnData
{
    public int id;
    public Transform targetPos;
}
public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public List<CharacterSpawnData> spawnDataPoints = new List<CharacterSpawnData>();
    public TMP_Text label;

    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];

        Vector3 targetPos = Vector3.zero;
        foreach (CharacterSpawnData spawnData in spawnDataPoints)
        {
            if (spawnData.id == LoadSceneBehaviour.targetID)
            {
                targetPos = spawnData.targetPos.position;
            }
        }
        GameObject clone = Instantiate(prefab, targetPos, Quaternion.identity);

        label.text = prefab.name;
        StartCoroutine(HideTextAfterDelay(10f)); // Memulai coroutine untuk menyembunyikan teks setelah 10 detik

    }

    IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Menunggu selama delay

        label.text = ""; // Mengosongkan teks
    }
}