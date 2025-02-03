using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScorpion : MonoBehaviour
{
    
    [Header("Bullet Configuration")]
    [SerializeField] float speed = 15;
    [SerializeField] float limitX;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.x >= limitX) gameObject.SetActive(false);
    }

}
