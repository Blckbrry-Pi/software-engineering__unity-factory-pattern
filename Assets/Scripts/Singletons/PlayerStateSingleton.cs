using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateSingleton : MonoBehaviour
{
    public class PlayerState
    {
        public enum PlayerType { FIRE, WATER }

        private const float JUMP_COOLDOWN = 0.1f;

        public PlayerType Type;
        public bool IsGrounded = false;
        public float LastJumpTime = 0;
        
        public PlayerState(PlayerType type) => Type = type;

        public bool CanJump => IsGrounded && Time.time - LastJumpTime > JUMP_COOLDOWN;

        public void RecordJump()
        {
            if (CanJump)
            {
                LastJumpTime = Time.time;
            }
        }

        public Vector2 PlayerInput {
            get
            {
                int w = Input.GetKey(KeyCode.W) ? 1 : 0;
                int a = Input.GetKey(KeyCode.A) ? 1 : 0;
                int s = Input.GetKey(KeyCode.S) ? 1 : 0;
                int d = Input.GetKey(KeyCode.D) ? 1 : 0;

                int up = Input.GetKey(KeyCode.UpArrow) ? 1 : 0;
                int left = Input.GetKey(KeyCode.LeftArrow) ? 1 : 0;
                int down = Input.GetKey(KeyCode.DownArrow) ? 1 : 0;
                int right = Input.GetKey(KeyCode.RightArrow) ? 1 : 0;

                int fireX = d - a;
                int fireY = w - s;

                int waterX = right - left;
                int waterY = up - down;

                return Type switch
                {
                    PlayerType.FIRE => new Vector2(fireX, fireY),
                    PlayerType.WATER => new Vector2(waterX, waterY),
                    _ => Vector2.zero
                };
            }
        }
    }

    private readonly static SingletonBase<PlayerStateSingleton> _instance = new();
    public static PlayerStateSingleton Instance => _instance.Instance;

    public PlayerState fire = new(PlayerState.PlayerType.FIRE);
    public PlayerState water = new(PlayerState.PlayerType.WATER);

    void Awake()
    {
        _instance.GetOrInitInstance(this);
    }

    void Update()
    {
        _instance.GetOrInitInstance(this);
    }

    public PlayerState Get(PlayerState.PlayerType type) => type switch
    {
        PlayerState.PlayerType.FIRE => fire,
        PlayerState.PlayerType.WATER => water,
        _ => null
    };
}
