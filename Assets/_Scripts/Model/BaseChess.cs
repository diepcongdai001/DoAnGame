using UnityEngine;
using System.Collections;

public abstract class BaseChess : MonoBehaviour {

    [SerializeField]
    private Vector3 offsetPosition;
    public ChessInfo Info { get; private set; }

    [SerializeField]
    protected EPlayer _player;

    public EPlayer Player
    {
        get
        {
            return _player;
        }

        protected set
        {
            _player = value;
        }
    }

    private Vector2 _originalLocation;
    public Vector2 Location { get; private set; }

    public void SetInfo(ChessInfo info)
    {
        _originalLocation = new Vector2(info.X1, info.Y1);
        this.Info = info;
        this.transform.position = offsetPosition + new Vector3(info.Y1 * ChessBoard.Current.CELL_SIZE, 0,
            info.X1 * ChessBoard.Current.CELL_SIZE); 
    }

    public abstract void Move();
}
