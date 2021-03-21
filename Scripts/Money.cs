using UnityEngine;

public class Money : MonoBehaviour
{
    // Const for compareTag
    const string PLAYER = "Player";

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(PLAYER))
        {
            Destroy(gameObject);
            GameManager.money += 1;
        }
    }
}
