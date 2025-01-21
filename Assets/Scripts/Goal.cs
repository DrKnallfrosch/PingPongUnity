using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public TMP_Text leftText;
    public TMP_Text rightText;
    public TMP_Text winnerText;
    public UnityEngine.UI.Button resetButton;
    public UnityEngine.UI.Button menuButton;
    private Rigidbody2D _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        resetButton.onClick.AddListener(ResetGame);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (leftText.text == "5")
        {
            winnerText.text = "Left Player Wins!";
            _rb.linearVelocity = Vector2.zero;
            resetButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
        }
        else if (rightText.text == "5")
        {
            winnerText.text = "Right Player Wins!";
            _rb.linearVelocity = Vector2.zero;
            resetButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Goal"))
        {
            _rb.transform.position = new Vector2(0, -1.01f);
            if (other.transform.position.x < 0)
            {
                rightText.text = (int.Parse(rightText.text) + 1).ToString();
            }
            else
            {
                leftText.text = (int.Parse(leftText.text) + 1).ToString();
            }
        }
    }
    
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
