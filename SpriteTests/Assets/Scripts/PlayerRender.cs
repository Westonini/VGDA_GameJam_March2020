using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRender : MonoBehaviour
{
    public int chosenChar;
    private SpriteRenderer sr;

    private bool facingRight = true;
    private bool facingDown = true;

    public PlayerMovement PM;
    public Characters characters;

    private Characters.SpriteList currentCharacter;

    private PlayerAnimations playerAnim;

    public bool getFacingRight() { return facingRight; }
    public bool getFacingDown() { return facingDown; }

    private void Awake()
    {
        playerAnim = GetComponent<PlayerAnimations>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        currentCharacter = characters.playerCharacters[chosenChar];
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !playerAnim.anim.GetBool("Jumping"))
        {
            playerAnim.PlayJumpAnim();
        }

        if ((PM.getHorizontalInput() != 0 || PM.getVerticalInput() != 0) && !playerAnim.anim.GetBool("Jumping"))
            playerAnim.PlayWalkAnim();
        else
            playerAnim.StopWalkAnim();


        //FLIP PLAYER
        if (!facingRight && PM.getHorizontalInput() > 0)      //HORIZONTALLY
        {
            FlipHoriz();
        }
        else if (facingRight && PM.getHorizontalInput() < 0)
        {
            FlipHoriz();
        }
        if (!facingDown && PM.getVerticalInput() < 0)         //VERTICALLY
        {
            FlipVert();
        }
        else if (facingDown && PM.getVerticalInput() > 0)
        {
            FlipVert();
        }

        //SPRITE CHANGES
        if (facingDown)
            sr.sprite = currentCharacter.front;
        else
            sr.sprite = currentCharacter.back;
    }

    void FlipHoriz()
    {
        //Flip function used if the player looks the other direction (horizontally).
        facingRight = !facingRight;

        //Flip the player
        transform.Rotate(0f, 180f, 0f);
    }

    void FlipVert()
    {
        //Flip function used if the player looks the other direction (vertically).
        facingDown = !facingDown;

        //Flip function used if the player looks the other direction (horizontally).
        facingRight = !facingRight;
    }
}
