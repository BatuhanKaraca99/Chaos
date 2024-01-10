using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    float waitingTime = 3f;
    bool interaction = false;
    [SerializeField] private GameObject nextLevelUI;

    private void Awake()
    {
        nextLevelUI = GameObject.FindGameObjectWithTag("LevelUI");
    }

    private void Start()
    {
        nextLevelUI.SetActive(false);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        ActivateUI(collision);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        ActivateUI(collision);
    }

    private void Update()
    {
        if (interaction)
        {
            waitingTime -= 0.3f;
        }
    }

    private void ActivateUI(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            nextLevelUI.SetActive(true);
            interaction = true;
            if (waitingTime < 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

}
