using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Map : MonoBehaviour
{
    public StarterAssets.ThirdPersonController player;
    public StarterAssets.StarterAssetsInputs inputs;
    public GameObject map;

    public List<TravelPoint> travelPoints = new List<TravelPoint>();

    private void Start()
    {
        foreach (TravelPoint point in travelPoints)
        {
            point.travelEvent.triggers[0].callback.AddListener((BaseEventData e) => { Travel(point); });
        }
        player = GameObject.FindWithTag("Player").GetComponent<StarterAssets.ThirdPersonController>();
        inputs = player.gameObject.GetComponent<StarterAssets.StarterAssetsInputs>();
    }

    public void OpenMap()
    {
        map.SetActive(true);
    }

    public void CloseMap()
    {
        map.SetActive(false);
    }

    public void Travel(TravelPoint point)
    {
        player.enabled = false;
        player.transform.position = point.positionTravel.position;
        player.enabled = true;
    }
}
