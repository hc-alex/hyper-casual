using PathCreation;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PathFollower : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private PathCreator _pathCreator;

        private Rigidbody _rigidbody;
        private float _distanceTravelled;
        
        private bool _isMoving = true;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.MovePosition(_pathCreator.path.GetPointAtDistance(_distanceTravelled));
        }

        private void Update()
        {
            if(!_isMoving)
                return;
            
            _distanceTravelled += Time.deltaTime * _speed;
            
            Vector3 nextPoint = _pathCreator.path.GetPointAtDistance(_distanceTravelled);
            nextPoint.y = transform.position.y;
            
            transform.LookAt(nextPoint);
            _rigidbody.MovePosition(nextPoint);
        }

        public void Stop() => 
            _isMoving = false;
    }
}
