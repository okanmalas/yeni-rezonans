using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// CharMovement.instance.Stun(1);
/// 
/// CharMovement.instance.stunned = true;
/// </summary>
public class CharMovement : MonoBehaviour
{
    static public CharMovement instance;

    [SerializeField] bool stunned;

    Rigidbody2D rb;

    [SerializeField] float walkSpeed = 1f;
    [SerializeField] float jumpSpeed = 1f;
    [SerializeField] float slamSpeed = 30;

    [SerializeField] LayerMask mask;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        instance = this;
    }

    [SerializeField] List<KeyCode> jumpKeycode;
    struct MovementData
    {
        public Vector2 sideJump;
        public float walk;
        public bool isJumped;
    }

    bool doubleJump = true;
    MovementData InputManager()
    {
        MovementData data = new MovementData();
        if (stunned)
        {
            data.isJumped = false;
            data.walk = rb.velocity.x;
        }

        //Jump
        foreach (KeyCode k in jumpKeycode)
        {
            if (Input.GetKeyDown(k) && (isGrounded() || doubleJump))
            {
                data.isJumped = true;

                if (doubleJump && !isGrounded())
                    doubleJump = false;
            }

            if (data.isJumped)
                break;
        }
        if (isGrounded())
            doubleJump = true;

        data.walk = Input.GetAxis("Horizontal") * walkSpeed;
        return data;
    }

    void WalkAndJump()
    {
        Vector2 temp = new Vector2();
        MovementData data = InputManager();

        temp = new Vector2(data.walk, data.isJumped ? jumpSpeed : rb.velocity.y);

        rb.velocity = temp;
    }

    private void Update()
    {
        WalkAndJump();


        //--------------------
        /*if (Input.GetKeyDown(KeyCode.K))
            Stun(4);*/
    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 2.5f, mask);

        if (hit.collider == null) return false;

        return true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, -transform.up * 2.5f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }
    #region Stun
    public void Stun(float time)
    {
        StartCoroutine(StunAsync(time));
    }

    IEnumerator StunAsync(float time)
    {
        stunned = true;

        yield return new WaitForSeconds(time);

        stunned = false;
    }
    #endregion
}