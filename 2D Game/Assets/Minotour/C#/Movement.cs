using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    Animator animator;
    public float moveSpeed = 300;
    public GameObject character;

    private Rigidbody2D characterBody;
    private float ScreenWidth;

   
    void Start()
    {
        animator = character.GetComponent<Animator>();
        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        int i = 0;
        
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                
                RunCharacter(1.0f);
                
            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                
                RunCharacter(-1.0f);
                
            }
            ++i;
        }
    }
    void FixedUpdate()
    {
        RunCharacter(Input.GetAxis("Horizontal"));
        /*#if UNITY_EDITOR
		;
#endif*/
    }

    private void RunCharacter(float horizontalInput)
    {
              
        characterBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.fixedDeltaTime, 0));
        
        animator.SetFloat("Speed", horizontalInput);
    }
}