using System;
using UnityEngine;

[ExecuteAlways]
public class Sun : MonoBehaviour
{
    public Barrier barrier;

    public GameObject explosion;

    public GameObject[] barriers;
    // Start is called before the first frame update
    void Update()
    {
        switch (barrier)
        {
            case Barrier.none:
                barriers[0].SetActive(false);
                barriers[1].SetActive(false);
                break;
            case Barrier.blue:
                barriers[0].SetActive(true);
                barriers[1].SetActive(false);
                break; 
            case Barrier.orange:
                barriers[0].SetActive(false);
                barriers[1].SetActive(true);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Astronaut"))
        {
            explosion.SetActive(true);
        }
    }

    public enum Barrier
    {
        none, blue, orange
    }
}

