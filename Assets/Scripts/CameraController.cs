using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera View Targets")]
    public Transform defaultView;
    public Transform boardView;
    public Transform myScoreView;
    public Transform myHandView;
    public Transform myBonusView;
    public Transform oppHandView;
    public Transform oppScoreView;
    public Transform myTrashDetailView;
    public Transform oppTrashDetailView;

    private Transform targetView;
    private float moveSpeed = 5f;
    private float rotateSpeed = 5f;

    public enum CameraState
    {
        Default,
        Board,
        MyScore,
        MyHand,
        MyBonus,
        OppHand,
        OppScore,
        MyTrashDetail,
        OppTrashDetail
    }

    private CameraState currentState = CameraState.Default;

    void Start()
    {
        targetView = defaultView;
        transform.position = targetView.position;
        transform.rotation = targetView.rotation;
    }

    void Update()
    {
        HandleInput();

        // ˆÊ’u•âŠÔ
        transform.position = Vector3.Lerp(
            transform.position,
            targetView.position,
            Time.deltaTime * moveSpeed
        );

        // ‰ñ“]•âŠÔ
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetView.rotation,
            Time.deltaTime * rotateSpeed
        );
    }

    void HandleInput()
    {
        switch (currentState)
        {
            case CameraState.Default:
                if (Input.GetKeyDown(KeyCode.W)) SetState(CameraState.Board);
                if (Input.GetKeyDown(KeyCode.A)) SetState(CameraState.MyScore);
                if (Input.GetKeyDown(KeyCode.S)) SetState(CameraState.MyHand);
                if (Input.GetKeyDown(KeyCode.D)) SetState(CameraState.MyBonus);
                break;

            case CameraState.Board:
                if (Input.GetKeyDown(KeyCode.W)) SetState(CameraState.OppHand);
                if (Input.GetKeyDown(KeyCode.S)) SetState(CameraState.Default);
                break;

            case CameraState.MyScore:
                if (Input.GetKeyDown(KeyCode.W)) SetState(CameraState.MyTrashDetail);
                if (Input.GetKeyDown(KeyCode.S)) SetState(CameraState.MyHand);
                if (Input.GetKeyDown(KeyCode.D)) SetState(CameraState.Default);
                break;

            case CameraState.MyHand:
                if (Input.GetKeyDown(KeyCode.W)) SetState(CameraState.Default);
                if (Input.GetKeyDown(KeyCode.A)) SetState(CameraState.MyScore);
                if (Input.GetKeyDown(KeyCode.D)) SetState(CameraState.MyBonus);
                break;

            case CameraState.MyBonus:
                if (Input.GetKeyDown(KeyCode.W)) SetState(CameraState.OppScore);
                if (Input.GetKeyDown(KeyCode.A)) SetState(CameraState.Default);
                if (Input.GetKeyDown(KeyCode.S)) SetState(CameraState.MyHand);
                break;

            case CameraState.OppHand:
                if (Input.GetKeyDown(KeyCode.A)) SetState(CameraState.OppScore);
                if (Input.GetKeyDown(KeyCode.S)) SetState(CameraState.Board);
                break;

            case CameraState.OppScore:
                if (Input.GetKeyDown(KeyCode.W)) SetState(CameraState.OppTrashDetail);
                if (Input.GetKeyDown(KeyCode.S)) SetState(CameraState.MyBonus);
                if (Input.GetKeyDown(KeyCode.D)) SetState(CameraState.OppHand);
                break;

            case CameraState.MyTrashDetail:
                if (Input.GetKeyDown(KeyCode.S)) SetState(CameraState.MyScore);
                break;

            case CameraState.OppTrashDetail:
                if (Input.GetKeyDown(KeyCode.S)) SetState(CameraState.OppScore);
                break;
        }
    }

    void SetState(CameraState newState)
    {
        currentState = newState;

        switch (newState)
        {
            case CameraState.Default: targetView = defaultView; break;
            case CameraState.Board: targetView = boardView; break;
            case CameraState.MyScore: targetView = myScoreView; break;
            case CameraState.MyHand: targetView = myHandView; break;
            case CameraState.MyBonus: targetView = myBonusView; break;
            case CameraState.OppHand: targetView = oppHandView; break;
            case CameraState.OppScore: targetView = oppScoreView; break;
            case CameraState.MyTrashDetail: targetView = myTrashDetailView; break;
            case CameraState.OppTrashDetail: targetView = oppTrashDetailView; break;
        }
    }
}
