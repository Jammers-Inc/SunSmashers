using System;
using GameObjects.Astronaut.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameObjects.SpaceShip.Scripts
{
    public class SpaceShip : MonoBehaviour
    {
    
        private Rigidbody2D _rb;
        private SpriteRenderer _sr;
        private Camera _cam;
        private DistanceJoint2D _joint;
    
        public Astronaut.Scripts.Astronaut[] astronauts;
        [Range(0, 100000)]
        public float launchForce;
        Vector2 gravity;
        private int _next;
        private Vector3 _lastPos;
        private Vector3 _mousePos;

        private bool _isShot;

        private void OnEnable()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
            _joint = GetComponent<DistanceJoint2D>();
            _cam = Camera.main;
        }

        private void Start()
        {
            gravity = Physics2D.gravity;
        }

        // Update is called once per frame
        void Update()
        {
            var position = transform.position;

            
            
            Debug.DrawLine(position, GetWorldPositionOnPlane(_mousePos,0), Color.green);
            Debug.DrawLine(_lastPos, position, _sr.color, 1f ,true);
            _lastPos = position;
        }

        public void Shoot(InputAction.CallbackContext context)
        {
            if (!_isShot)
            {
                Astronaut.Scripts.Astronaut target = astronauts[_next];
                target.detachFromShip(true);
                
                Rigidbody2D rb = target.gameObject.GetComponent<Rigidbody2D>();
                Launch(rb);
                
                target.SetUsed(true);
                _isShot = true;
            }
        }

        public void MousePosition(InputAction.CallbackContext context)
        {
            
            _mousePos = context.ReadValue<Vector2>();
        }

        public void Launch(Rigidbody2D launched)
        {
            launched.AddForce((GetWorldPositionOnPlane(_mousePos,0) - transform.position).normalized * launchForce);
        }

        public void ActivateHinge()
        {
            _joint.enabled = true;
            _joint.connectedBody = astronauts[_next].GetComponent<Rigidbody2D>();
        }

        public void Next()
        {
            _next++;
            if (_next > astronauts.Length - 1) _next = 0;
        }

        public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
            Ray ray = _cam.ScreenPointToRay(screenPosition);
            Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
            float distance;
            xy.Raycast(ray, out distance);
            return ray.GetPoint(distance);
        }

        public void ResetShot()
        {
            _isShot = false;
        }

        public void DetachOthers(GameObject sender)
        {
            foreach (Astronaut.Scripts.Astronaut astronaut in astronauts)
            {
                if(sender.Equals(astronaut.gameObject)) continue;
                Attachable a = astronaut.gameObject.GetComponent<Attachable>();
                a.Detach();
            }
        }

        public void AttachmentCallback(GameObject attached)
        {
            Physics2D.gravity = attached.transform.position.y < 0 ? -gravity : gravity;
        }
    }
}
