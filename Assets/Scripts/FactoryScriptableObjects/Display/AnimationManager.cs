using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D parentRigidBody;

    public PlayerStateSingleton.PlayerState.PlayerType type;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        parentRigidBody = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float yVel = parentRigidBody.velocity.y;
        float xInput = PlayerStateSingleton.Instance.Get(type).PlayerInput.x;

        animator.SetFloat("Y Vel", yVel);
        animator.SetFloat("X Input", xInput);
    }
}
