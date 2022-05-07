using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectil : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Transform Pos;

    [SerializeField] private float LifeTime;
    private float Timer;

    private Scene scene;

    private void Start()
    {
        Pos = GetComponent<Transform>();
        Timer = Time.time;
        scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (!Input.GetButton("Fire2"))
        {
            if (Timer <= Time.time - LifeTime) Destroy(gameObject);

            Pos.Translate(Pos.forward * Speed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(scene.name);
        }
    }
}
