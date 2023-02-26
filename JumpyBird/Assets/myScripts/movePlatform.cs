using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour
{
    public float speed = 2f; // platformların hareket hızı
    public float distance = 5f; // platformların hareket edeceği mesafe
    public bool isMovingRight; // platformların başlangıç yönü

    private Vector2 movement; // platformların hareket yönü
    private Vector3 startingPosition; // platformların başlangıç pozisyonu
    private Vector3 rightPosition; // sağdaki pozisyon
    private Vector3 leftPosition; // soldaki pozisyon

    void Start()
    {
        startingPosition = transform.position;
        rightPosition = startingPosition + new Vector3(distance, 0, 0);
        leftPosition = startingPosition - new Vector3(distance, 0, 0);

        if (isMovingRight)
        {
            movement = new Vector2(1, 0);
        }
        else
        {
            movement = new Vector2(-1, 0);
        }
    }

    void Update()
    {
        // platformların hareket etmesi
        transform.Translate(movement * speed * Time.deltaTime);

        // sağ tarafa doğru hareket ederken sağdaki noktaya ulaşırsa yönü tersine çevirir
        if (transform.position.x >= rightPosition.x)
        {
            isMovingRight = false;
            movement = new Vector2(-1, 0);
        }

        // sola doğru hareket ederken soldaki noktaya ulaşırsa yönü tersine çevirir
        if (transform.position.x <= leftPosition.x)
        {
            isMovingRight = true;
            movement = new Vector2(1, 0);
        }
    }
}
