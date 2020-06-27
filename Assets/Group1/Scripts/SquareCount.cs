using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SquareCount : MonoBehaviour
{
    [SerializeField] private GameObject _endGameSprite;
    [SerializeField] private CircleMovement _greenCircle;
    [SerializeField] private List<SquareMovement> _redSquares;
    private float _minDistance;

    public void End()
    {
        _endGameSprite.SetActive(true);
    }

    private void Update()
    {
        foreach (var square in _redSquares)
        {
            if (square == null)
                continue;

            if (Vector3.Distance(_greenCircle.transform.position, square.transform.position) < _minDistance)
            {
                DestroySquare(square);
                CheckSquareCount();
            }
        }
    }

    public void DestroySquare(SquareMovement square)
    {
        if (square.TryGetComponent(out SquareMovement _square))
        {
            Destroy(_square);
        }
    }

    private void CheckSquareCount()
    {
        _redSquares = _redSquares.Where(square =>square !=null).ToList();
        if (_redSquares.Count == 0)
        {
            _greenCircle.enabled = false;
        }
    }
}
