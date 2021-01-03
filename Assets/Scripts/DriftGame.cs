using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DriftGame : MonoBehaviour
{
    private GameManager _gameManager;

    public GameManager gameManager
    {
        get
        {
            if (_gameManager == null)
            {
                _gameManager = FindObjectOfType<GameManager>();
            }
            return _gameManager;
        }

    }

}
