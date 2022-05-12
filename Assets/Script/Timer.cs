using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float _timeStart;
    public Text _texttimer;

    void Start()
    {
        _texttimer.text = _timeStart.ToString("F1");
    }

    void Update()
    {
        _timeStart += Time.deltaTime;
        _texttimer.text = _timeStart.ToString("F1");
    }

}