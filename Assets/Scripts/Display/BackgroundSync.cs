using UnityEngine;

public class BackgroundSync : MonoBehaviour
{
    public bool DoSmoothScroll = true;

    // Update is called once per frame
    void Update()
    {
        float xOff = ScrollStateSingleton.Instance.SmoothScroll.x / 2 % 1;
        float yOff = ScrollStateSingleton.Instance.SmoothScroll.y / 2 % (16f / 33f);
        Vector2 offset = new(xOff, yOff);
        Vector2 newPos = ScrollStateSingleton.Instance.SmoothScroll - offset;
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }
}
