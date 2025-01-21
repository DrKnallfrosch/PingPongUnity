using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class OnClick : MonoBehaviour
{
    public UnityEngine.UI.Button resetButton, menuButton;
    public GameObject ball;
    
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
