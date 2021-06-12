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
        }

        private void Start()
        {
            _astronaut = GetComponent<Astronaut>();
        }

        
        public void Attach(GameObject other)
        {
            _rb.constraints = RigidbodyConstraints2D.FreezeAll;
            _astronaut.spaceShip.ActivateHinge();
            _astronaut.spaceShip.Next();
            _astronaut.LookAt(other.transform);
            isAttached = true;
            _astronaut.spaceShip.ResetShot();
            _astronaut.spaceShip.DetachOthers(gameObject);
            _astronaut.spaceShip.AttachmentCallback(gameObject);
        }
    
        public void Detach()
        {
            if (isAttached)
            {
                _rb.constraints = RigidbodyConstraints2D.None;
                isAttached = false;
                _astronaut.StartReturn();
            }
        }
    
        
    
    }
}
