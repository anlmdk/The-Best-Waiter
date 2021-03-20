using UnityEngine;

public class Customer : MonoBehaviour
{
    public float speed;
    public Animator animator;

    const string WALKING = "Walking";
    const string STOP_WALKING = "stopWalking";

    private void Start()
    {
        animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameIsStarted == true)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            animator.SetBool(WALKING, true);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger(STOP_WALKING);
            speed = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CustomerEnd"))
        {
            animator.SetTrigger(STOP_WALKING);
            speed = 0;
        }
    }
}
