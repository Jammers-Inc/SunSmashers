using System;
using UnityEngine;

[ExecuteAlways]
public class Sun : MonoBehaviour
{
    public Barrier barrier;

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

    public enum Barrier
    {
        none, blue, orange
    }
}

