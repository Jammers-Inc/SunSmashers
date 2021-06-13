using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Serialization;

namespace GameObjects.Astronaut.Scripts
{
    public class Astronaut : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private SpriteRenderer _sr;
        private Attachable _a;

        public Sprite[] sprites;

        public SpaceShip.Scripts.SpaceShip spaceShip;
        
        [Range(0.001f,10)]
        public int returnSpeed;
        [Range(0.01f,30)]
        public float maxDistance;
        
        public SoundPlayer soundPlayer;
    
        private Vector3 _lastPos;
        private Vector3 _lerpStart;
        
        private float _lerpFac;
        private float _flownDistance;
        private bool _isRetracting;
        private bool _isFlying;
        private int _defaultLayer;



        private void OnEnable()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
            _a = GetComponent<Attachable>();
            _defaultLayer = gameObject.layer;
        }

        private void Update()
        {
            LerpToShip();
        }
        
        public void SetVisualTargets(Transform other, bool attached)
        {
            _sr.sprite = sprites[attached ? 1 : 0];
            LookAt(other.position);
            _isFlying = !attached;
        }

        private void FixedUpdate()
        {
            if(_isFlying) LookAt(transform.position + (Vector3)_rb.velocity.normalized);
            if ((transform.position - spaceShip.transform.position).magnitude > maxDistance)
            {
                StartReturn();
                soundPlayer.PlayMissedSound();
            }
        }
        
        public void DetachFromShip(bool detach)
        {
            Transform spaceShipTransform = spaceShip.transform;
            Transform myTransform = transform;
            myTransform.parent = detach ? null : spaceShipTransform;
            myTransform.position = detach ? myTransform.position : spaceShipTransform.position ;
        }
        public void SetUsed(bool used)
        {
            GetComponent<SpriteRenderer>().enabled = used;
            foreach (CircleCollider2D circleCollider2D in GetComponents<CircleCollider2D>())
            {
                circleCollider2D.enabled = used;
            }
            _rb.simulated = used;
            if (!used)
            {
                _rb.velocity = Vector2.zero;
                _rb.angularVelocity = 0;
            }
        }

        public void LerpToShip()
        {
            if (_isRetracting)
            {
                Vector3 position = spaceShip.transform.position;
                transform.position = Vector3.Lerp(_lerpStart, position, _lerpFac);
                LookAt(position);
                _lerpFac += Time.deltaTime * returnSpeed;
            }
        }

        public void StartReturn()
        {
            _isRetracting = true;
            _lerpStart = transform.position;
            gameObject.layer = 15;
            SetVisualTargets(spaceShip.transform, false);
        }
        
        public void EndReturn()
        {
            _isRetracting = false;
            _lerpFac = 0;
            SetUsed(false);
            DetachFromShip(false);
            spaceShip.ResetShot();
            gameObject.layer = _defaultLayer;
            soundPlayer.StopFlySound();
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Planet"))
            {
                if (((int) Math.Pow(2, other.gameObject.layer) & _a.attachableLayers.value) > 0 && !_isRetracting)
                {
                    _a.Attach(other.gameObject);
                    return;
                }
            }
            soundPlayer.PlayFailSound();
            StartReturn();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == 12)
            {
                soundPlayer.PlayEnterSunSound();
                return;
            }
            if (other.gameObject.layer == 11)
            {
                if (_isRetracting)
                {
                    EndReturn();
                }
            }
        }

        public void LookAt(Vector3 other)
        {
            _rb.angularVelocity = 0;
            Vector3 dir = other - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
