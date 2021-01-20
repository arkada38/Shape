namespace Shape.BW.Models
{
  public class Shape
  {
    public ShapeParam<decimal> A { get; set; } = new();
    public ShapeParam<decimal> B { get; set; } = new();
    public ShapeParam<decimal> C { get; set; } = new();

    public void Calc()
    {
      if (!A.HasValue)
      {
        if (B.HasValue && C.HasValue)
        {
          A.ComputedValue = C.Value - B.Value;
        }
      }
      if (!B.HasValue)
      {
        if (A.HasValue && C.HasValue)
        {
          B.ComputedValue = C.Value - A.Value;
        }
      }
      if (!C.HasValue)
      {
        if (A.HasValue && B.HasValue)
        {
          C.ComputedValue = A.Value + B.Value;
        }
      }
    }
  }

  public class ShapeParam<T> where T : struct
  {
    public T? UserValue { get; set; }
    public T? ComputedValue { get; set; }
    public bool HasValue =>
      UserValue.HasValue || ComputedValue.HasValue;
    public T Value => UserValue ?? ComputedValue ?? default;
  }
}