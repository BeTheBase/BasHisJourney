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
        //Intro with cinematic bars
        if (IntroductionText[IntroductionText.Length -1] == IntroductionText[_value] && _performance)
        {
            Debug.Log("CheckPerformance");
            NextButton.gameObject.SetActive(false);
            IntroductionTextObject.CrossFadeAlpha(0,2f,false);
            
            StartCoroutine(SetAlphaAfterTime(IntroductionTextObject, 2, 255));
            StartCoroutine(SetStringAfterTime(MovementIntroText, 2));
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

    IEnumerator SetInOrActive(GameObject obj, int time, bool active)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(active);
    }

    IEnumerator SetAlphaAfterTime(Text obj, int time, int amount)
    {
        yield return new WaitForSeconds(time);
        obj.CrossFadeAlpha(amount, time, false);
    }

    IEnumerator SetStringAfterTime(string[] obj, int time)
    {
        yield return new WaitForSeconds(time);
        _introText = obj;
        IntroductionTextObject.text = _introText[0];
        _value = 0;
        NextButton.gameObject.SetActive(true);
    }
}