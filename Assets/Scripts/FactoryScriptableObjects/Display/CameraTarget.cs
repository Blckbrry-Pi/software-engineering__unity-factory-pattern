using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public List<GameObject> Targets = new();

    void Start()
    {
        if (Targets.Count == 0)
        {
            GameObject parent = GameObject.Find("CharacterParent");
            foreach (Transform child in parent.transform)
            {
                Targets.Add(child.gameObject);
            }
        }
    }

    void Update()
    {

        Vector3 positionSum = new(0, 0, 0);
        foreach (GameObject target in Targets)
        {
            positionSum += target.transform.position;
        }
        Vector3 averagePosition = positionSum / Targets.Count;
        
        ScrollStateSingleton.Instance.Scroll = averagePosition;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(
            ScrollStateSingleton.Instance.SmoothScroll.x,
            ScrollStateSingleton.Instance.SmoothScroll.y,
            transform.position.z);
    }
}
