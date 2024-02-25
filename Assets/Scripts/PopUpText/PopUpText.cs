public class PopUpText : TextView
{
    public bool CanReturnToPool { get; private set; }

    private PopUpTextAnimation _textAnimation;

    protected override void OnAwake() => _textAnimation = GetComponent<PopUpTextAnimation>();

    protected override void UpdateText(string value)
    {
        string updatedText = $"+{value}";
        Text.text = updatedText;
    }

    public void PopUp(string income)
    {
        CanReturnToPool = false;
        UpdateText(income);
        _textAnimation.Play(Text);
    }

    public void ReturnToPool() => CanReturnToPool = true;
}