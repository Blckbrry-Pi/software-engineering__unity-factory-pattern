using UnityEngine;

public class ScrollStateSingleton : MonoBehaviour
{
    private readonly static SingletonBase<ScrollStateSingleton> _instance = new();
    public static ScrollStateSingleton Instance => _instance.Instance;

    // What percentage of the distance to the target should be covered in one second
    private const float SCROLL_SPEED = 0.9f;

    [SerializeField]
    public Vector2 Scroll { get; set; } = Vector2.zero;

    [SerializeField]
    public Vector2 SmoothScroll { get; private set; } = Vector2.zero;

    void Awake()
    {
        if (_instance.GetOrInitInstance(this) == this)
        {
            SyncSmoothScroll();
        }
    }

    // Update is called once per frame
    void Update()
    {
        _instance.GetOrInitInstance(this);

        float lerpVal = 1 - Mathf.Pow(1 - SCROLL_SPEED, Time.deltaTime);
        SmoothScroll = Vector2.Lerp(SmoothScroll, Scroll, lerpVal);

        // Scroll += new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime;
    }

    public void SyncSmoothScroll()
    {
        SmoothScroll = Scroll;
    }
}
