using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VOID : MonoBehaviour
{
    private Scene scene;
    public Transform posPlayer;

    public Vector3 directionMouvement;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += directionMouvement * Time.deltaTime;

        transform.position = new Vector3(posPlayer.position.x, transform.position.y, transform.position.z);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(scene.name);
        }
    }

}
