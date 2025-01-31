using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public EntityBehavior playerBehavior;
    public Transform floorChecker;
    public LayerMask groundLayer;
    public SaveData saveData;
    public float acceleration;
    public int energy;
    public int maxEnergy;

    private float speed;
    private float jumpStrength;
    private float health;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private float xAxis = 0;
    private float maxAcceleration;
    private float accelerationRate;


    // Start is called before the first frame update
    void Start()
    {
        SetUpPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        Jump();
        saveData.playerData.playerEnergy = energy;
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(xAxis * speed + Accelerate(), rb.velocity.y);
    }

    void SetUpPlayer(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        saveData = GetComponent<SaveData>();

        speed = playerBehavior.SPEED;
        jumpStrength = playerBehavior.JUMP_STRENGTH;
        health = playerBehavior.HEALTH;
        spriteRenderer.sprite = playerBehavior.ENTITY_SPRITE;
        acceleration = 0f;
        maxAcceleration = playerBehavior.MAX_ACCELERATION;
        accelerationRate = playerBehavior.ACCELERATION_RATE;
        maxEnergy = playerBehavior.MAX_ENERGY;

        saveData.LoadFromJson();
        energy = saveData.playerData.playerEnergy;
    }

    bool IsGrounded(){
        return Physics2D.OverlapCircle(floorChecker.position, 0.1f, groundLayer);
    }

    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
        }
    }

    float Accelerate(){
        if (xAxis != 0 && acceleration <= maxAcceleration){
            if (xAxis > 0){
                acceleration += accelerationRate;
            }
            else{
                acceleration -= accelerationRate;
            }
        }
        else{
            if (acceleration > 0 ){
                acceleration -= accelerationRate*2;
            }
            if (acceleration < 0 ){
                acceleration += accelerationRate*2;
            }
        }
        return (speed * acceleration);
    }
}
