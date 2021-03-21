using UnityEngine;

public class Customer : MonoBehaviour
{
    // Component
    public Animator animator;

    // Customer variable
    public float speed;

    // Const for animation parameters
    const string WALKING = "Walking";
    const string STOP_WALKING = "stopWalking";

    // Const for compareTags
    const string PLAYER = "Player";
    const string CUSTOMER_END = "CustomerEnd";

    private void Start()
    {
        animator.GetComponent<Animator>();
    }
    private void Update()
    {
        if (GameManager.gameIsStarted == true)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            animator.SetBool(WALKING, true);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(PLAYER))
        {
            animator.SetTrigger(STOP_WALKING);
            speed = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(CUSTOMER_END))
        {
            animator.SetTrigger(STOP_WALKING);
            speed = 0;
        }
    }
}
