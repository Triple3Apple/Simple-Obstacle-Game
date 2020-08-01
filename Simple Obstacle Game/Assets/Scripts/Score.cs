using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform playerTransform = null;
    [SerializeField] private Text scoreText = null;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ((int)playerTransform.position.z).ToString();  // converting and rounding number
    }
}
