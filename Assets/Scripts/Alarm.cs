using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private float _speedOfVolumeChange;
    private bool _isThief;
    private bool _isInside;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        _isThief = collision.TryGetComponent<Thief>(out Thief component);

        if (_isThief)
        {
            _alarm.Play();
            _isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isThief = collision.TryGetComponent<Thief>(out Thief component);

        if (_isThief)
        {
            _isInside = false;
        }

    }

    private void Update()
    {
        if (_isInside)
        {
            _alarm.volume += _speedOfVolumeChange;
        }
        else
        {
            _alarm.volume -= _speedOfVolumeChange;
        }
        if (_alarm.volume == 0)
        {
            _alarm.Stop();
        }
    }
}
