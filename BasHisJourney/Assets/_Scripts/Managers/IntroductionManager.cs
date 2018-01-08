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
    public string[] IntroductionText;

    private string _lastText;

    private int _value;

    void Awake()
    {
        if (!IntroductionTextObject)
            return;

        IntroductionTextObject.text = IntroductionText[0];
    }

    void Start()
    {
        FadeGameIn.CrossFadeAlpha(0f, 3f, true);
        
    }

    void Update()
    {
        if (FadeGameIn.color.a < 2f)
           FadeGameIn.gameObject.SetActive(false);

        if (IntroductionText[IntroductionText.Length -1] == IntroductionText[_value])
        {
            Debug.Log("Laatste");
            NextButton.gameObject.SetActive(false);
            IntroductionTextObject.CrossFadeAlpha(0,1f,false);
            foreach (var bar in CinematicBars)
            {
                bar.CrossFadeAlpha(0, 3f, false);
            }
        }
    }

    public void NextText()
    {
        _value++;
        IntroductionTextObject.text = IntroductionText[0 + _value];
    }
}
