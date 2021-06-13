using System;
using GameObjects.Astronaut.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace GameObjects.SpaceShip.Scripts
{
    public class SpaceShip : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private SpriteRenderer _sr;
        private Camera _cam;
        private DistanceJoint2D _joint;
        private UpdateLineRendererTarget _updateLineRenderer;

        public AudioSource audio;
        public GameObject aimPreview;
        public Color[] colors;
        
        public Astronaut.Scripts.Astronaut[] astronauts;
        [Range(0, 100000)]
        public float launchForce;

        public bool orangeFirst;

        public float lazzorLength;
        
        Vector2 gravity;
        private int _next;
        private Vector3 _lastPos;
        private Vector3 _mousePos;

        

        private bool _isShot;
        private static readonly int EmissionColor = Shader.PropertyToID("EmissionColor");

        private void OnEnable()
        {
            _sr = GetComponent<SpriteRenderer>();
            _joint = GetComponent<DistanceJoint2D>();
            _rb = GetComponent<Rigidbody2D>();
            _updateLineRenderer = aimPreview.GetComponent<UpdateLineRendererTarget>();
            _cam = Camera.main;
        }

        private void Start()
        {
            gravity = Physics2D.gravity;
            _next = orangeFirst ? 1 : 0;
            _rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        private void Update()
        { 
            Vector3 position = transform.position;
        
            _sr.flipX = _rb.velocity.x < 0;
            _updateLineRenderer.target.position = position + (GetWorldPositionOnPlane(_mousePos,0) - position).normalized * lazzorLength;
            _updateLineRenderer.renderer.material.SetColor(EmissionColor, colors[_next]);
        }

        public void Shoot(InputAction.CallbackContext context)
        {
            if (!_isShot)
            {
                audio.Play();
                Astronaut.Scripts.Astronaut target = astronauts[_next];
                target.DetachFromShip(true);
                target.soundPlayer.PlayFlySound();
                
                Rigidbody2D rb = target.gameObject.GetComponent<Rigidbody2D>();
                Vector3 launchDirection = (GetWorldPositionOnPlane(_mousePos,0) - transform.position).normalized;
                Launch(rb, launchDirection, launchForce);
                
                target.SetUsed(true);
                _isShot = true;
            }
        }
        
        public void MousePosition(InputAction.CallbackContext context)
        {
            _mousePos = context.ReadValue<Vector2>();
        }

        public void Launch(Rigidbody2D launched, Vector3 direction, float force)
        {
            launched.AddForce( direction * force);
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
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        
    }
}
