using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour
{
    [SerializeField] Vector2 dimensions;
    [SerializeField] float magnitude;

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= 0 || transform.localScale.y <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localScale = new Vector3
            (transform.localScale.x - magnitude * dimensions.x * Time.deltaTime,
            transform.localScale.y - magnitude * dimensions.y * Time.deltaTime,
            transform.localScale.z);
        }
    }
}
