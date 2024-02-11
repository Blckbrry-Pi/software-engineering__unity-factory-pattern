using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject Target;

    void Start()
    {
        if (Target == null)
        {
            Target = GameObject.Find("Player");
        }
    }

    void Update()
    {
        // Debug.Log(ScrollStateSingleton.Instance.Scroll);
        // Debug.Log(Target.transform.position);
        ScrollStateSingleton.Instance.Scroll = Target.transform.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(
            ScrollStateSingleton.Instance.SmoothScroll.x,
            ScrollStateSingleton.Instance.SmoothScroll.y,
            transform.position.z);
    }
}
