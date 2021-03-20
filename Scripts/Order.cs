using UnityEngine;

public class Order : MonoBehaviour
{
    public int maxOrder = 100;

    public OrderBar orderBar;

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
        if (other.gameObject.CompareTag("Player"))
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
