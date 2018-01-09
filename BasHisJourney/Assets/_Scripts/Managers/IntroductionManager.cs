using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionManager : MonoBehaviour
{
    public Text IntroductionTextObject;
    public Button NextButton;
    public Image[] CinematicBars;
    public Image FadeGameIn;
    public string[] IntroductionText, MovementIntroText;

    private string[] _introText;
    private int _value;
    private bool _performance;

    void Awake()
    {
        if (!IntroductionTextObject)
            return;

        _performance = true;

        _introText = IntroductionText;

        IntroductionTextObject.text = _introText[0];
    }

    void Start()
    {
        FadeGameIn.CrossFadeAlpha(0f, 3f, true);
        StartCoroutine(SetInOrActive(FadeGameIn.gameObject, 3, false));
    }

    void Update()
    {
        if (IntroductionText[IntroductionText.Length -1] == IntroductionText[_value] && _performance)
        {
            Debug.Log("Laatste");
            NextButton.gameObject.SetActive(false);
            IntroductionTextObject.CrossFadeAlpha(0,1f,false);
            StartCoroutine(SetAlphaAfterTime(IntroductionTextObject, 2, 255));
            _introText = MovementIntroText;
            IntroductionTextObject.text = _introText[0];
            foreach (var bar in CinematicBars)
            {
                bar.CrossFadeAlpha(0, 1f, false);
            }

            _performance = false;
        }
    }

    public void NextText()
    {
        _value++;
        IntroductionTextObject.text = _introText[0 + _value];
    }

    IEnumerator SetInOrActive(GameObject obj, int _time, bool _active)
    {
        yield return new WaitForSeconds(_time);
        obj.SetActive(_active);
    }

    IEnumerator SetAlphaAfterTime(Text obj, int _time, int _amount)
    {
        yield return new WaitForSeconds(_time);
        obj.CrossFadeAlpha(_amount, _time, false);
    }
}