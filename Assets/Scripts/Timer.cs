using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Timer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay = 0.5f;

    private bool _isCoroutinePaused = true;
    private int _time = 0;

    private void Start()
    {
        _text.text = "0";
        StartCoroutine(Counter());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            _isCoroutinePaused = !_isCoroutinePaused;
        }
    }

    private IEnumerator Counter()
    {
        while (true)
        {
            if(_isCoroutinePaused == false) 
            {
                _time++;
                DisplayCountdown(_time);
                yield return new WaitForSeconds(_delay);
            }
            else
            {
                yield return null;
            }
        }
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString();
    }
}
