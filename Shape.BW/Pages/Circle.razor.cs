namespace Shape.BW.Pages
{
  public partial class Circle
  {
    private decimal? _radius;

    public decimal? Radius
    {
      get => _radius;
      set
      {
        if (_radius == value) { return; }
        _radius = value;
      }
    }

    public decimal? Diameter
    {
      get => 2 * _radius;
      set
      {
        if (_radius == value / 2) { return; }
        _radius = value / 2;
      }
    }

    public void Clear()
    {
      _radius = null;
    }
  }
}
