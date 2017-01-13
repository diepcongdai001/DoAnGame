using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

    private Ecellcolor _color;

    private Transform cellHoverObj;
    private Transform cellSelectedObj;

    public BaseChess CurrentChess { get; private set; }


    public Ecellcolor Color
    {
        get
        {
            return _color;
        }

        set
        {
            _color = value;
            switch (_color)
            {
                case Ecellcolor.BLACK:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.BlackCellMaterial;
                    break;
                case Ecellcolor.WHITE:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.WhiteCellMaterial;
                    break;
                default:
                    break;
            }
        }
    }

    private Ecellstate _state;
    public Ecellstate State
    {
        get
        {
            return _state;
        }

        set
        {
            _state = value;
            switch (_state)
            {
                case Ecellstate.NORMAL:
                    cellHoverObj.gameObject.SetActive(false);
                    cellSelectedObj.gameObject.SetActive(false);
                    break;
                case Ecellstate.HOVER:
                    cellHoverObj.gameObject.SetActive(true);
                    cellSelectedObj.gameObject.SetActive(false);
                    break;
                case Ecellstate.SELECTED:
                    cellHoverObj.gameObject.SetActive(false);
                    cellSelectedObj.gameObject.SetActive(true);
                    break;
                case Ecellstate.TAGETED:

                    break;
                default:
                    cellHoverObj.gameObject.SetActive(false);
                    cellSelectedObj.gameObject.SetActive(false);
                    break;
            }
        }
    }

    public float SIZE
    {
        get
        {
            return GetComponent<Renderer>().bounds.size.x;
        }
    }

    void Awake()
    {
        cellHoverObj = this.transform.GetChild(0);
        cellSelectedObj = this.transform.GetChild(1);
    }

    protected void Start()
    {
        //cellHoverObj = this.transform.GetChild(0);
        //cellSelectedObj = this.transform.GetChild(1);

        //State = Ecellstate.NORMAL;
    }

    //Thay doi trang thai
    public void SetCellState(Ecellstate cellState)
    {
        if (cellState != Ecellstate.SELECTED)
        {
            if (this.State != Ecellstate.SELECTED)
                this.State = cellState;
        }
        else
        {
            if (this.State == Ecellstate.SELECTED)
                this.State = Ecellstate.HOVER;
            else this.State = Ecellstate.SELECTED;
        }
        if (cellState == Ecellstate.UNSELECTED)
            this.State = Ecellstate.UNSELECTED;
    }

    public void SetPiece(BaseChess chess)
    {
        this.CurrentChess = chess;
    }
}
