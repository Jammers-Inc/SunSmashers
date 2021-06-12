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

        public SpaceShip.Scripts.SpaceShip spaceShip;
        private bool _isRetracting;
        [Range(1,10)]
        public int returnSpeed;
    
        private Vector3 _lastPos;
        private Vector3 _lerpStart;
        private float _lerpFac;

        private float _flownDistance;
        [Range(1,1000)]
        public float maxDistance;
        private Transform _originalParent;

        private void OnEnable()
        {
            _originalParent = transform.parent; 
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
            _a = GetComponent<Attachable>();
        }

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            Debug.DrawLine(_lastPos, transform.position, _sr.color, 10, true);
            
            //Debug.DrawLine(transform.position, transform.forward, Color.red);
            _lastPos = transform.position;
        }

        private void LateUpdate()
        {
            ReturnToShip();
        }

        private void FixedUpdate()
        {
            if((transform.position - spaceShip.transform.position).magnitude > maxDistance) StartReturn();
            
        }
        
        public void detachFromShip(bool detach)
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

        public void ReturnToShip()
        {
            if (_isRetracting)
            {
                transform.position = Vector3.Lerp(_lerpStart, spaceShip.transform.position, _lerpFac);
                _lerpFac += Time.deltaTime * returnSpeed;
            }
        }

        public void StartReturn()
        {
            _isRetracting = true;
            _lerpStart = transform.position;
            LookAt(spaceShip.transform);
        }
        
        public void EndReturn()
        {
            _isRetracting = false;
            _lerpFac = 0;
            SetUsed(false);
            detachFromShip(false);
            spaceShip.ResetShot();
            
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Planet"))
            {
                if (((int) Math.Pow(2, other.gameObject.layer) & _a.attachableLayers.value) > 0 && _isRetracting)
                {
                    _a.Attach(other.gameObject);
                    return;
                }
            }
            StartReturn();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == 11)
            {
                if (_isRetracting )
                {
                    EndReturn();
                }
            }
        }

        public void LookAt(Transform other)
        {
            _rb.angularVelocity = 0;
            Vector3 dir = other.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    
}
