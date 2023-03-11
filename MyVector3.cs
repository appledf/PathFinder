using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using robotManager.Helpful;


public class MyVector3
{
    public Vector3 Position = new Vector3();
    public bool IsMajor = false;

    public MyVector3(Vector3 position)
    {
        Position = position;
    }
    public MyVector3(Vector3 position,bool isMajor)
    {
        Position = position;
        IsMajor = isMajor;
    }
    public MyVector3(float x,float y,float z,string type)
    {
        this.Position = new Vector3(x, y, z, type);
    }
    public MyVector3(float x, float y, float z,string type,bool isMajor)
    {
        this.Position = new Vector3(x, y, z, type);
        IsMajor = isMajor;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Position.X.ToString()+",");
        sb.Append(Position.Y.ToString() + ",");
        sb.Append(Position.Z.ToString() + ",");
        sb.Append(this.IsMajor.ToString());
        return sb.ToString();
    }
}
