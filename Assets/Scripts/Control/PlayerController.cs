using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public PlayerStateSingleton.PlayerState.PlayerType type;

    private Rigidbody2D PlayerRigidBody;
    private Collider2D TriggerCollider;

    private const float HANDLING_RATE = 0.05f;

    void InitLifetimeValues()
    {
        TriggerCollider = GetComponents<Collider2D>().First(c => c.isTrigger);
        PlayerRigidBody = GetComponent<Rigidbody2D>();   
    }

    void Start()
    {
        InitLifetimeValues();
        InvokeRepeating(nameof(UpdateIsColliding), 0, 1.0f);
    }



    private int CountMatchingContactingColliders(Func<Collider2D, bool> ColliderMatches) {
        List<Collider2D> colliders = new();
        ContactFilter2D contactFilter = new();
        TriggerCollider.OverlapCollider(contactFilter, colliders);

        return colliders.Where(ColliderMatches).Count();
    }

    private bool IsCollidingWithGround() {
        return CountMatchingContactingColliders(c => !c.isTrigger && GroundFlag.HasGround(c.gameObject)) > 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            if (other.isTrigger)
            {
                Physics2D.IgnoreCollision(other, TriggerCollider);
                return;
            }
            PlayerStateSingleton.Instance.Get(type).IsGrounded = IsCollidingWithGround();
        } catch
        {
            InitLifetimeValues();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        try
        {
            PlayerStateSingleton.Instance.Get(type).IsGrounded = IsCollidingWithGround();
        } catch
        {
            InitLifetimeValues();
        }
    }

    void Update()
    {
        PlayerStateSingleton.PlayerState state = PlayerStateSingleton.Instance.Get(type);
        try
        {
            if (state.PlayerInput.y > 0)
            {
                if (state.CanJump)
                {
                    state.RecordJump();

                    PlayerRigidBody.velocity = new(PlayerRigidBody.velocity.x, 0);
                    PlayerRigidBody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
                }
            }
            
            float targetSpeed = Mathf.Clamp(state.PlayerInput.x, -1, 1) * 5;
            UpdateSpeed(targetSpeed);
        } catch
        {
            InitLifetimeValues();
        }
    }


    private void UpdateIsColliding()
    {
        try
        {
            PlayerStateSingleton.Instance.Get(type).IsGrounded = IsCollidingWithGround();
        } catch
        {
            InitLifetimeValues();
        }
    }

    private void UpdateSpeed(float targetSpeed) {
        float targetDiff = targetSpeed - PlayerRigidBody.velocity.x;
        float multiplier = 1 - Mathf.Pow(HANDLING_RATE, Time.deltaTime);
        float rawForce = targetDiff * multiplier;

        Debug.Log(PlayerRigidBody.velocity);
        Debug.Log($"Target velocity diff: {targetDiff}; force applied: {rawForce}");

        PlayerRigidBody.AddForce(new(rawForce, 0), ForceMode2D.Impulse);
    }
}
