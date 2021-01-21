using System;

namespace Shape.BW.Models
{
  public class Shape
  {
    public ShapeParam A { get; set; } = new();
    public ShapeParam B { get; set; } = new();
    public ShapeParam C { get; set; } = new();

    public Shape()
    {
      A.ValueChanged += (s, e) => Calc();
      B.ValueChanged += (s, e) => Calc();
      C.ValueChanged += (s, e) => Calc();
    }

    public void Calc()
    {
      ClearComputedValues();

      if (B.HasValue && C.HasValue)
      {
        A.ComputedValue = C.Value - B.Value;
      }
      if (A.HasValue && C.HasValue)
      {
        B.ComputedValue = C.Value - A.Value;
      }
      if (A.HasValue && B.HasValue)
      {
        C.ComputedValue = A.Value + B.Value;
      }
    }

    public void Clear()
    {
      A.Clear();
      B.Clear();
      C.Clear();
    }

    public void ClearComputedValues()
    {
      A.ComputedValue = null;
      B.ComputedValue = null;
      C.ComputedValue = null;
    }
  }

  public class ShapeParam
  {
    public event EventHandler<decimal?> ValueChanged;
    public decimal? UserValue { get; set; }
    public decimal? ComputedValue { get; set; }
    public bool HasValue =>
      UserValue.HasValue || ComputedValue.HasValue;
    public bool IsValid =>
      !(UserValue.HasValue && ComputedValue.HasValue && UserValue.Value != ComputedValue.Value);
    public string ValidString =>
      !IsValid ? "is-invalid" : UserValue.HasValue ? "is-valid" : string.Empty;

    public decimal? Value
    {
      get => UserValue ?? ComputedValue;
      set
      {
        if (UserValue == value || value == 0) { return; }
        UserValue = value;
        ValueChanged?.Invoke(this, value);
      }
    }

    public void Clear()
    {
      UserValue = null;
      ComputedValue = null;
    }
  }
}