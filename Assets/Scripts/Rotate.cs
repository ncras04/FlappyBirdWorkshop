using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float _lerpFactor = 1.0f;
    [SerializeField]
    private float _upRotateAngle = 30.0f;
    [SerializeField]
    private float _downRotateAngle = 90.0f;

    private Rigidbody2D _rigidbody = default;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody.freezeRotation = true;
        _rigidbody.rotation = 0;
    }

    private void FixedUpdate()
    {
        if (_rigidbody.linearVelocityY > 0.01)
            _rigidbody.transform.rotation = TurkeySlurpy(_upRotateAngle, _lerpFactor * 10); //10 weil gut 

        if (_rigidbody.linearVelocityY < -0.01)
            _rigidbody.transform.rotation = TurkeySlurpy(-_downRotateAngle, _lerpFactor);

    }
    private Quaternion TurkeySlurpy(float angle, float lerpFactor)
    {
        return Quaternion.Lerp(_rigidbody.transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), lerpFactor * Time.fixedDeltaTime);
    }
}
