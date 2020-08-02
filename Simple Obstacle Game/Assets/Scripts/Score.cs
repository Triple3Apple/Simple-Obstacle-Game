using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _playerTransform = null;
    [SerializeField] private Text _scoreText = null;

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = ((int)_playerTransform.position.z).ToString();  // converting and rounding number
    }
}
