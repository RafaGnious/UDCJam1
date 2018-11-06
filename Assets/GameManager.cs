using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] float Sensitivity;
    [SerializeField] RectTransform Objective;
    [SerializeField] Image Crosshair;
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] TextMeshProUGUI ScoreDisplay;
    [SerializeField] float Speed = -2f;
    [SerializeField] float InitialSpeed = -10f;
    int Points;
    // Use this for initialization
    void Start()
    {
        Objective.eulerAngles = new Vector3(0f, 0f, Random.Range(0f, 360f));
    }

    void Reset()
    {
        Points = 0;
        Objective.eulerAngles = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
        Crosshair.color = Color.white;
        GameOverScreen.SetActive(false);
        ScoreDisplay.SetText("Score: 0");
        Start();
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameOverScreen.activeSelf)
        {
            transform.eulerAngles += new Vector3(0f, 0f, (Speed * Points + InitialSpeed) * Time.deltaTime);
            if (Mathf.Abs((transform.eulerAngles.z - (((int)transform.eulerAngles.z / 360) * 360)) - Objective.eulerAngles.z) < Sensitivity)
            {
                Crosshair.color = Color.green;
                if (Input.anyKeyDown)
                {
                    Points++;
                    Objective.eulerAngles = new Vector3(0f, 0f, Random.Range(0f, 360f));
                    ScoreDisplay.SetText("Score: {0}", Points);
                }
            }
            else if (Input.anyKeyDown) GameOverScreen.SetActive(true);
            else Crosshair.color = Color.white;
        }
        else if (Input.anyKeyDown) Reset();
    }
}
