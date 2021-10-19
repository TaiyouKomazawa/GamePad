using UnityEngine;
using UnityEngine.UI;

public class LogMenu : MonoBehaviour
{
    [SerializeField]
    private Text text_ui = null;
    [SerializeField]
    private ScrollRect scroll_view = null;
    [SerializeField]
    private int text_limit = 100000;

    private void Awake()
    {
        Application.logMessageReceived  += OnLogMessage;
    }

    private void OnDestroy()
    {
        Application.logMessageReceived  -= OnLogMessage;
    }

    private void OnLogMessage( string i_logText, string i_stackTrace, LogType i_type)
    {
        if(string.IsNullOrEmpty(i_logText)){
            return;
        }
        string add = i_logText + "\n";
        text_ui.text += add;
        Debug.Log(text_ui.text.Length - text_limit);
        if(text_ui.text.Length >= text_limit){
            text_ui.text = text_ui.text.Remove(0, add.Length);
        }
        scroll_view.verticalNormalizedPosition = 0.0f;
    }

} // class LogMenu
