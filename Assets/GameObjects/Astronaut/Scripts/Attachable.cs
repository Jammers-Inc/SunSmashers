using UnityEngine;

namespace GameObjects.Astronaut.Scripts
{
    public class Attachable : MonoBehaviour
    {
        private Rigidbody2D _rb;
        public LayerMask attachableLayers;
        public bool isAttached;
        private Astronaut _astronaut;
        

        private void OnEnable()
        {
            _rb = GetComponent<Rigidbody2D>();
            _astronaut = GetComponent<Astronaut>();
        }
        
        
        public void Attach(GameObject other)
        {
            _rb.constraints = RigidbodyConstraints2D.FreezeAll;
            _astronaut.spaceShip.ActivateHinge();
            _astronaut.spaceShip.Next();
            _astronaut.SetVisualTargets(other.transform, true);
            isAttached = true;
            _astronaut.spaceShip.ResetShot();
            _astronaut.spaceShip.DetachOthers(gameObject);
            _astronaut.spaceShip.AttachmentCallback(gameObject);
            
            _astronaut.soundPlayer.PlayGrabSound();
            _astronaut.soundPlayer.StopFlySound();
        }
    
        public void Detach()
        {
            if (isAttached)
            {
                _rb.constraints = RigidbodyConstraints2D.None;
                isAttached = false;
                _astronaut.StartReturn();
                _astronaut.soundPlayer.PlayFlySound();
                _astronaut.soundPlayer.PlayReleaseGrapSound();
            }
        }
    }
}
