using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 2D vector class
/// </summary>
[System.Serializable]
public class MyVector
{
    public float X;
    public float Y;
    public MyVector(float x, float y)
    {
        this.X = x;
        this.Y = y;
    }
    public MyVector Add(MyVector first)
    {
        /*float x = this.X + first.X;
        float y = this.Y + first.Y;
        var vectorResultante = new MyVector(x, y);
        return vectorResultante;*/
        return this + first;
    }

    public static MyVector operator +(MyVector a, MyVector b)
    {
        return new MyVector(a.X + b.X, a.Y + b.Y);
    }
    public MyVector Diff(MyVector first)
    {
        //float x = this.X - first.X;
        //float y = this.Y - first.Y;
        //var vectorResultante = new MyVector(x, y);
        //return vectorResultante;
        return first - this;
    }
    public static MyVector operator -(MyVector a, MyVector b)
    {
        return new MyVector(a.X - b.X, a.Y - b.Y);
    }

    public float Punto(MyVector first)
    {
        float x = this.X * first.X + this.Y * first.Y;
        return x;
    }

    public MyVector Normalize()
    {
        return new MyVector((X / this.Magnitud()), (Y / this.Magnitud()));
    }

    public float Magnitud()
    {
        return Mathf.Sqrt(this.X * this.X + this.Y * this.Y);
    }

    public MyVector Escalar(float a)
    {
        float x = this.X * a;
        float y = this.Y * a;
        return new MyVector(x, y);
    }

    public static MyVector operator *(MyVector a, float b)
    {
        return new MyVector(a.X * b, a.Y * b);
    }

    public static MyVector operator /(MyVector a, float b)
    {
        if (b != 0) return new MyVector(a.X / b, a.Y / b);
        else return null;
    }
    public override string ToString()
    {
        return (X + " , " + Y);
    }

    public MyVector Lerp(MyVector vector1, float k)
    {
        //MyVector vector = vector1.Diff(this);
        // return this.Add(((vector).Escalar(k)));
        return this + ((vector1 - this) * k);
    }

    public void Draw(Color color)
    {
        Vector2 vector = new Vector2(X, Y);
        Debug.DrawRay(Vector2.zero, vector, color);
    }
    public void Draw(Color color, MyVector vectorSobrecarga)
    {
        Vector2 sobrecarga = new Vector2(vectorSobrecarga.X, vectorSobrecarga.Y);

        Vector2 vector = new Vector2(X, Y);
        Debug.DrawRay(vector, sobrecarga, color);
    }

    // Implicit Cast Operator: Convierte el argumento en el tipo de dato que castea
    public static implicit operator Vector3(MyVector vector) => new Vector3(vector.X, vector.Y);


}
