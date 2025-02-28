using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Timer _timer;

    private void Start()
    {
        _text.text = "0";
    }

    private void OnEnable()
    {
        _timer.ValueChanged += DisplayCountdown;
    }

    private void OnDisable()
    {
        _timer.ValueChanged -= DisplayCountdown;
    }

    private void DisplayCountdown(int time)
    {
        _text.text = time.ToString();
    }
}
