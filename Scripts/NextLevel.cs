using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NextLevel : MonoBehaviour
{
    private int levelNumber;
    public TextMeshProUGUI levelText;

    private void Start()
    {
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        levelNumber.ToString();
        levelText.text = "LEVEL " + levelNumber + " COMPLETED!";
    }
    public void NextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
