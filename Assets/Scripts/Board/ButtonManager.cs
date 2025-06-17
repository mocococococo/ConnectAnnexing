using UnityEngine;

/// <summary>
/// ① Press Trigger を叩いて押下アニメを再生し  
/// ② BaseColor をトグルで切り替える
/// </summary>
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Animator))]
public class ButtonController : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] private Color unpressedColor = new(0.38f, 0.82f, 1f); // デフォルト: シアン
    [SerializeField] private Color pressedColor   = new(1f,   0.84f, 0f);  // デフォルト: ゴールド

    [Header("Animator")]
    [SerializeField] private string pressTriggerName = "ButtonPress";

    private Renderer  _renderer;
    private Material  _matInstance;
    private Animator  _anim;
    private bool      _isPressed = false;

    private static readonly int BaseColorID = Shader.PropertyToID("_BaseColor");

    private void Awake()
    {
        _renderer     = GetComponent<Renderer>();
        _matInstance  = _renderer.material;   // インスタンス化して 1 ボタンだけ色変更
        _anim         = GetComponent<Animator>();

        SetColor(unpressedColor);
    }

    /// <summary>BoardManager から呼び出す</summary>
    public void Toggle()
    {
        _isPressed = !_isPressed;

        // ① Trigger で押下アニメ再生
        _anim.SetTrigger(pressTriggerName);

        // ② 色を切り替え（永久保持）
        SetColor(_isPressed ? pressedColor : unpressedColor);
    }

    private void SetColor(Color c)
    {
        _matInstance.SetColor(BaseColorID, c);
    }
}
