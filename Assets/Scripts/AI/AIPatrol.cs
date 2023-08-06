using System.Collections;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    [System.Serializable]
    public class PatrolPoint
    {
        public Transform point;
        public Quaternion rotation;
    }

    public PatrolPoint[] patrolPoints; // Array of patrol points
    public float patrolSpeed = 5f; // Patrol speed in units per second
    public float patrolDelay = 2f; // Delay between patrols in seconds

    private int currentPatrolPointIndex = 0;
    private bool isPatrolling = false;

    private string[] patrolTransforms = {
        "Mengubah warna menjadi merah",
        "Berputar 360 derajat",
        "Melompat tinggi",
        "Berteriak 'Patrol! Patrol!'",
        "Membalik badan",
        "Melakukan loncatan tiga kali",
        "Mengubah ukuran menjadi dua kali lipat",
        "Berjalan mundur",
        "Membentuk lingkaran dengan tangannya",
        "Menendang kaki",
        "Menyanyikan lagu kecil"
    };

    void Start()
    {
        // Start patrolling when the game starts
        StartPatrol();
    }

    void Update()
    {
        if (isPatrolling)
        {
            // Move towards the current patrol point
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPatrolPointIndex].point.position, patrolSpeed * Time.deltaTime);

            // Check if the AI has reached the current patrol point
            if (transform.position == patrolPoints[currentPatrolPointIndex].point.position)
            {
                // Perform a patrol transform
                PerformTransform();

                // Move to the next patrol point
                currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;

                // Delay before moving to the next patrol point
                StartCoroutine(DelayPatrol());
            }
        }
    }

    void StartPatrol()
    {
        // Start the patrol process
        isPatrolling = true;

        // Perform initial patrol transform
        PerformTransform();
    }

    void PerformTransform()
    {
        // Choose a random transform from the list
        string transformText = patrolTransforms[Random.Range(0, patrolTransforms.Length)];

        // Perform the transform
        Debug.Log("Performing transform: " + transformText);

        // Implement the logic for each transform here
        switch (transformText)
        {
            case "Mengubah warna menjadi merah":
                // Code to change color to red
                break;
            case "Berputar 360 derajat":
                // Code to rotate 360 degrees
                break;
            case "Melompat tinggi":
                // Code to perform high jump
                break;
            // Add more cases for other transforms
        }

        // Rotate the character to face the patrol point
        Vector3 lookAtPosition = patrolPoints[currentPatrolPointIndex].point.position;
        lookAtPosition.y = transform.position.y; // Keep the same y position
        transform.LookAt(lookAtPosition);
    

    }

    IEnumerator DelayPatrol()
    {
        // Delay before moving to the next patrol point
        yield return new WaitForSeconds(patrolDelay);

        // Resume patrolling
        isPatrolling = true;
    }
}
