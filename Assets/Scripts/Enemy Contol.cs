using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    public GameObject targetObject;
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetObject.transform.position, speed * Time.deltaTime);
    }
}