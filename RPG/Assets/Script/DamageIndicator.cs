using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    public float lifetime = 1.0f;
    public float speed = 0.5f;

    float elapsedTime;
    TextMesh textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMesh>();

    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        this.transform.position += Vector3.up * speed * Time.deltaTime;
        Color c = textMesh.color;
        c.a = 1.0f - Mathf.Sqrt(elapsedTime / lifetime); 
        textMesh.color = c;

        if (elapsedTime >= lifetime)
        {
            Destroy(this.gameObject);
        }
    }
}
