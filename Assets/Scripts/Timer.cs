using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Timer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float _delay = 0.5f;

    private bool _isCoroutinePaused = true;
    private Coroutine _coroutine;

    public event Action<int> ValueChanged;

    public int Time { get; private set; }

    private void Start()
    {
        Time = 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && _isCoroutinePaused == true)
        {
            _coroutine = StartCoroutine(Counter());
            _isCoroutinePaused = false;
        }
        else if (eventData.button == PointerEventData.InputButton.Left && _isCoroutinePaused == false)
        {
            StopCoroutine(_coroutine);
            _isCoroutinePaused = true;
        }
    }

    public IEnumerator Counter()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Time++;
            ValueChanged?.Invoke(Time);
            yield return wait;
        }
    }
}
