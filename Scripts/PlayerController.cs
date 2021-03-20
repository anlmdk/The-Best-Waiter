using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    public Rigidbody rb;
    private Animator animator;
    Touch touch;

    // Movement and jump variables
    [SerializeField] private float forwardSpeed = 0.5f;
    [SerializeField] private float swipeSpeed = 0.003f;
    [SerializeField] private float jump = 3.5f;

    // Const for animation parametres
    const string IS_WALKING = "isWalking";
    const string IS_TEXTING = "isTexting";
    const string IS_FALLING = "isFalling";
    const string IS_FALLING_BACK = "isFallingBack";
    const string STOP_WALKING = "stopWalking";
    const string IS_JUMPING = "isJumping";
    const string DEFEAT = "defeat";
    const string VICTORY = "victory";

    public float SwipeSpeed { get { return swipeSpeed; } set { swipeSpeed = value; } }
    public float ForwardSpeed { get { return forwardSpeed; } set { forwardSpeed = value; } }
    public float Jump { get { return jump; } set { jump = value; } }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        animator.SetBool(IS_WALKING, false);
    }

    void Update()
    {
        if (GameManager.gameIsStarted == true)
        {
            Walk();
            SwipeLeftOrRight();
            JumpTouch();
        }
    }
    void Walk()
    {
        float move = transform.position.z + forwardSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, move);
        animator.SetBool(IS_WALKING, true);
        animator.SetBool(IS_TEXTING, false);
    }
    void SwipeLeftOrRight()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float leftOrRight = transform.position.x + touch.deltaPosition.x * swipeSpeed;
                transform.position = new Vector3(leftOrRight, transform.position.y, transform.position.z);
            }
        }
    }
    void JumpTouch()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.y > 100f)
                {
                    rb.velocity = Vector3.zero;
                    rb.velocity = Vector3.up * jump;

                    animator.SetBool(IS_JUMPING, true);
                }
            }
        }
        else
        {
            animator.SetBool(IS_JUMPING, false);
        }
    }
    void TextingWalk()
    {
        animator.SetBool(IS_WALKING, false);
        animator.SetTrigger(IS_TEXTING);
    }
    void FallingForward()
    {
        animator.applyRootMotion = !animator.applyRootMotion;
        animator.SetBool(IS_WALKING, false);
        animator.SetBool(IS_FALLING, true);
        forwardSpeed = 0;
        StartCoroutine(WaitForLoseAnimation());
    }
    public void FallingBack()
    {
        animator.applyRootMotion = !animator.applyRootMotion;
        animator.SetBool(IS_WALKING, false);
        animator.SetBool(IS_FALLING_BACK, true);
        forwardSpeed --;
        if (forwardSpeed <= 0)
        {
            forwardSpeed = 0;
        }
        StartCoroutine(WaitForLoseAnimation());
    }
    void End()
    {
        animator.SetTrigger(STOP_WALKING);
        if (GameManager.order >= 70)
        {
            animator.SetBool(VICTORY, true);
            StartCoroutine(WaitForNextLevelAnimation());
        }
        else
        {
            animator.SetBool(DEFEAT, true);
            StartCoroutine(WaitForLoseAnimation());
        }
    }
    private IEnumerator WaitForLoseAnimation()
    {
        yield return new WaitForSeconds(2f);
        GameManager.gameIsOver = true;
    }
    private IEnumerator WaitForNextLevelAnimation()
    {
        yield return new WaitForSeconds(2f);
        GameManager.nextLevelCheck = true;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Table") || other.gameObject.CompareTag("Fences"))
        {
            FallingForward();
        }
        if (other.gameObject.CompareTag("Banana") || other.gameObject.CompareTag("Chair")
           || other.gameObject.CompareTag("Lamb") || other.gameObject.CompareTag("Customer"))
        {
            FallingBack();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Order"))
        {
            TextingWalk();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            End();
        }
    }
}
