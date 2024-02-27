using UnityEngine;

public class AimLineController : MonoBehaviour
{
    [SerializeField] private Transform fruitThrowTransform;
    [SerializeField] private Transform bottonTransform;
    
    private LineRenderer _lineRenderer;

    private float _topPos;
    private float _bottomPos;
    private float _x;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _x = fruitThrowTransform.position.x;
        _topPos = fruitThrowTransform.position.y;
        _bottomPos = bottonTransform.position.y;
        
        _lineRenderer.SetPosition(0, new Vector3(_x, _topPos));
        _lineRenderer.SetPosition(1, new Vector3(_x, _bottomPos));
    }

    private void OnValidate()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        
        _x = fruitThrowTransform.position.x;
        _topPos = fruitThrowTransform.position.y;
        _bottomPos = bottonTransform.position.y;
        
        _lineRenderer.SetPosition(0, new Vector3(_x, _topPos));
        _lineRenderer.SetPosition(1, new Vector3(_x, _bottomPos));
    }
}
