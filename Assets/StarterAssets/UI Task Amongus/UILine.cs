using UnityEngine;
using UnityEngine.UI;

public class UILine : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public RawImage lineImage;

    void Update()
    {
        // Calculate the midpoint between pointA and pointB
        Vector3 midpoint = (pointA.position + pointB.position) / 2f;

        // Set the Image's position to the midpoint
        lineImage.rectTransform.position = midpoint;

        // Calculate the direction and distance between pointA and pointB
        Vector3 direction = pointB.position - pointA.position;
        float distance = direction.magnitude;

        // Set the Image's size to match the line's length
        lineImage.rectTransform.sizeDelta = new Vector2(distance, lineImage.rectTransform.sizeDelta.y);

        // Calculate the angle between the line and the x-axis
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the Image to match the line's angle
        lineImage.rectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
