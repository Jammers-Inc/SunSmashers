using General_Scripts;
using UnityEngine;

public class BondingBox : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        SceneManager.manager.ReloadScene();
    }
}
