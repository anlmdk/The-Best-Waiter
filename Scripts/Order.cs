using UnityEngine;

public class Order : MonoBehaviour
{
    public OrderBar orderBar;

    // Maximum order variable
    public int maxOrder = 100;

    // Const string compareTag
    const string PLAYER = "Player";

    private void Start()
    {
        orderBar.SetMaxOrder(maxOrder);
    }
    private void Update()
    {
        if (GameManager.order > maxOrder)
        {
            GameManager.order = maxOrder;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(PLAYER))
        {
            if (GameManager.order < maxOrder)
            {
                GameManager.order += 10;
                orderBar.SetOrder(GameManager.order);
            }
            Destroy(this.gameObject);
        }
    }
}
