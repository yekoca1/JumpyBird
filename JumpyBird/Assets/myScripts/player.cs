using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class player : MonoBehaviour
{
    [SerializeField] float force;  //zıplamak için uygulanan kuvvet
    Rigidbody2D rb;
    public Button xbutton;
    public TextMeshProUGUI scoreText;
    GameObject win;
    GameObject lose;
    public int puan;

    public float xMin, xMax; 

    void Start()
    {
        puan = 100;
        rb = GetComponent<Rigidbody2D>();
        win = GameObject.FindWithTag("WinText");
        lose = GameObject.FindWithTag("LoseText");
        xbutton = GameObject.FindWithTag("Button").GetComponent<Button>();
        xbutton.onClick.AddListener(RestartGame);
        scoreText = GameObject.FindWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        win.SetActive(false);
        lose.SetActive(false);
        xbutton.gameObject.SetActive(false);
        xbutton.interactable = false;
    }

    void FixedUpdate()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
        transform.position = newPosition;
        scoreText.text = "Puan : " + puan.ToString();

        if (Input.GetMouseButton(0))
        {
            rb.velocity = Vector2.up*force;
        }

        if (puan == 0)
        {
            Time.timeScale = 0f;
            lose.SetActive(true);
            xbutton.gameObject.SetActive(true);
            xbutton.interactable = true;
        }

        if (win.activeSelf)
        {
            xbutton.gameObject.SetActive(true);
            xbutton.interactable = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("obstacle"))
        {
            puan -= 20;
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Finish"))
        {
            Time.timeScale = 0f;
            win.SetActive(true);
            xbutton.gameObject.SetActive(true);
            xbutton.interactable = true;
        }

        else if(other.CompareTag("Bottom"))
        {
            Time.timeScale = 0f;
            xbutton.gameObject.SetActive(true);
            xbutton.interactable = true;   
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }   
}
