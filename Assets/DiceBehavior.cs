using UnityEngine;
using System.Collections.Generic;

public class DiceBehavior : MonoBehaviour
{
    private Vector3 initialPosition;
    private float previousTime = 0;
    private AudioSource[] sounds;
    // Use this for initialization
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        SetRandomRotation();
        initialPosition = transform.position;
    }

    private void SetRandomRotation()
    {
        float x = Random.value * 2 * Mathf.PI;
        float y = Random.value * 2 * Mathf.PI;
        float z = Random.value * 2 * Mathf.PI;
        transform.rotation = new Quaternion(x, y, z, 0);
    }
	
    // Update is called once per frame
    void Update()
    {
	
        if (Time.fixedTime - previousTime > 10)
        {
            transform.position = initialPosition;
            SetRandomRotation();
            previousTime = Time.fixedTime;
        }
    }

    void OnCollisionEnter()
    {
        if (sounds != null && sounds.Length > 0)
            sounds[0].Play();
    }
}
