using ProjecteKanBan;
using System.ComponentModel;

public class ItemKanBan : INotifyPropertyChanged
{
    private int _id;
    private string _tasca;
    private string _estat;
    private string _color;
    private string _dataStart;
    private string _dataFinish;
    private Responsable _responsable;

    public event PropertyChangedEventHandler PropertyChanged;

    public int id
    {
        get { return _id; }
        set
        {
            _id = value;
            OnPropertyChanged("id");
        }
    }

    public string tasca
    {
        get { return _tasca; }
        set
        {
            _tasca = value;
            OnPropertyChanged("tasca");
        }
    }

    public string estat
    {
        get { return _estat; }
        set
        {
            _estat = value;
            OnPropertyChanged("estat");
        }
    }

    public string color
    {
        get { return _color; }
        set
        {
            _color = value;
            OnPropertyChanged("color");
        }
    }

    public string dataStart
    {
        get { return _dataStart; }
        set
        {
            _dataStart = value;
            OnPropertyChanged("dataStart");
        }
    }

    public string dataFinish
    {
        get { return _dataFinish; }
        set
        {
            _dataFinish = value;
            OnPropertyChanged("dataFinish");
        }
    }

    public Responsable responsable
    {
        get { return _responsable; }
        set
        {
            _responsable = value;
            OnPropertyChanged("responsable");
        }
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
