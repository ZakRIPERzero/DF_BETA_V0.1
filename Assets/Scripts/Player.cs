using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }


    [SerializeField] private float moveSpeed = 5f;

    

    private Rigidbody2D rb;

    private float  minMoveSpeed = 0.1f;
    private bool isRun  = false;

    private void Awake()
    {

        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        
    }

    
    private void FixedUpdate()
    {
        HandleMovement();

    }
  
   private void HandleMovement()
   {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
       
        rb.MovePosition(rb.position + inputVector * (moveSpeed * Time.fixedDeltaTime));


        if (Mathf.Abs(inputVector.x) > minMoveSpeed || Mathf.Abs(inputVector.y) > minMoveSpeed)
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }
   }

    public bool IsRun()
    {
        return isRun;
    }
    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPos;
    }
}
