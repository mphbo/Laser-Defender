using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    bool hasFired;
    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;

    void Awake() 
    {
        shooter = GetComponent<Shooter>();    
    }

    void Start()
    {
        InitBounds();
    }
    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        StartCoroutine(FireSlowly(value));
    }
    IEnumerator FireSlowly(InputValue value)
    {
        while (true)
        {
        if (shooter != null)        
        {
            Debug.Log(value.isPressed);
            shooter.isFiring = value.isPressed;
            // shooter.isFiring = false;
            // shooter.isFiring = hasFired;
        }
            // if (shooter.isFiring || !hasFired) 
            // {
            //     shooter.isFiring = false;
            // }
            yield return new WaitForSeconds(1f);
        }
    }
}