using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private UIDocument _document;
    [SerializeField] private StyleSheet _styleSheet;

    [SerializeField] private Sprite logoSprite;
    [SerializeField] private Texture2D logoTexture;

    public static event Action StartButtonClicked;
    public static event Action QuitButtonClicked;
    

    private void Start()
    {
        StartCoroutine(Generate());
    }
    private void OnEnable()
    {
        StartCoroutine(Generate());
    }

    private void OnValidate()
    {
        if (Application.isPlaying) return;
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        yield return null;
        var root = _document.rootVisualElement;
        root.Clear();

        root.styleSheets.Add(_styleSheet);

        var container = Create("container");

        var viewBox = Create("view-box" /*, "bordered-box"*/);
        container.Add(viewBox);

        // TODO add logic for loading logo image similar to how the commented out Label is created above and added to the ui
        var logo = Create<Image>();
        logoSprite = Sprite.Create(logoTexture, new Rect(0, 0, logoTexture.width, logoTexture.height), Vector2.zero);
        logo.sprite = logoSprite;
        viewBox.Add(logo);


        var controlBox = Create("control-box" /*, "bordered-box"*/);

        var spinBtn2 = Create<Button>("Button-Style");
        spinBtn2.text = "Load Up";
        spinBtn2.clicked += StartButtonClicked;
        controlBox.Add(spinBtn2);

        var spinBtn = Create<Button>("Button-Style");
        spinBtn.text = "Tuck Tail";
        spinBtn.clicked += QuitButtonClicked;
        controlBox.Add(spinBtn);

        //var scaleSlider = Create<Slider>();
        //scaleSlider.lowValue = 0.5f;
        //scaleSlider.highValue = 2f;
        //scaleSlider.value = 1f;
        //scaleSlider.RegisterValueChangedCallback(v => ScaleChanged?.Invoke(v.newValue));
        //controlBox.Add(scaleSlider);

        container.Add(controlBox);

        root.Add(container);

        if (Application.isPlaying)
        {
            var targetPosition = container.worldTransform.GetPosition();
            var startPosition = targetPosition + Vector3.up * 100;

            controlBox.experimental.animation.Position(targetPosition, 2000).from = startPosition;
            controlBox.experimental.animation.Start(0, 1, 2000, (e, v) => e.style.opacity = new StyleFloat(v));
        }
    }

    private VisualElement Create(params string[] classNames)
    {
        return Create<VisualElement>(classNames);
    }

    private T Create<T>(params string[] classNames) where T : VisualElement, new()
    {
        var ele = new T();
        foreach (var className in classNames)
        {
            ele.AddToClassList(className);
        }

        return ele;
    }
}