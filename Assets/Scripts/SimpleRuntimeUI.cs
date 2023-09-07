using UnityEngine;
using UnityEngine.UIElements;

public class SimpleRuntimeUI : MonoBehaviour
{
    [SerializeField] UIDocument doc;
     private Button _btnStart;
    private Button _btnQuit;

    //private int _clickCount;

    //Add logic that interacts with the UI controls in the `OnEnable` methods
    private void OnEnable()
    {
        // The UXML is already instantiated by the UIDocument component
        //var uiDocument = GetComponent<UIDocument>();

        _btnStart = doc.rootVisualElement.Q("btn-start") as Button;
        _btnQuit = doc.rootVisualElement.Q("btn-quit") as Button;

        _btnStart.RegisterCallback<ClickEvent>(PrintClickMessage);

        var _inputFields = doc.rootVisualElement.Q("input-message");
        _inputFields.RegisterCallback<ChangeEvent<string>>(InputMessage);
    }

    private void OnDisable()
    {
        _btnStart.UnregisterCallback<ClickEvent>(PrintClickMessage);
    }

    private void PrintClickMessage(ClickEvent evt)
    {
        //++_clickCount;

        //Debug.Log($"{"button"} was clicked!" +
        //        (_btnQuit.value ? " Count: " + _clickCount : ""));
        Debug.Log("Button Clicked");
    }

    public static void InputMessage(ChangeEvent<string> evt)
    {
        Debug.Log($"{evt.newValue} -> {evt.target}");
    }
}