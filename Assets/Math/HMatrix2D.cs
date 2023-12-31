using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D : MonoBehaviour
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        entries = new float[3, 3]; // creates a new matrix
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                entries[x, y] = multiArray[x, y]; // initializes a 3 by 3 matrix by looping through the rows and columns 
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22) // manually creates a new matrix by allowing us to intitalize each value                                                                                                                      
    {
        entries[0,0] = m00;
        entries[0,1] = m01;
        entries[0,2] = m02;
        entries[1,0] = m10;
        entries[1,1] = m11;
        entries[1,2] = m12;
        entries[2,0] = m20;
        entries[2,1] = m21;
        entries[2,2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D newMatrix = new HMatrix2D();
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                newMatrix.entries[x, y] = (left.entries[x, y] + right.entries[x, y]); // matrix addition
            }
        }
        return newMatrix;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D newMatrix = new HMatrix2D();
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                newMatrix.entries[x, y] = (left.entries[x, y] - right.entries[x, y]); // matrix subtraction
            }
        }
        return newMatrix;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D newMatrix = new HMatrix2D();
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                newMatrix.entries[x, y] = (left.entries[x, y] * scalar); // matrix multiplication ( scalar )
            }
        }
        return newMatrix;
    } 

    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D(
            left.entries[0, 0] * right.x + left.entries[0, 1] * right.y + left.entries[0, 2] * right.h,
            left.entries[1, 0] * right.x + left.entries[1, 1] * right.y + left.entries[1, 2] * right.h
            );
    } 

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
       /* return new HMatrix2D
        (

           left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],
           left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],
           left.entries[0, 0] * right.entries[0, 2] + left.entries[0, 1] * right.entries[1, 2] + left.entries[0, 2] * right.entries[2, 2],

           left.entries[1, 0] * right.entries[0, 0] + left.entries[1, 1] * right.entries[1, 0] + left.entries[1, 2] * right.entries[2, 0],
           left.entries[1, 0] * right.entries[0, 1] + left.entries[1, 1] * right.entries[1, 1] + left.entries[1, 2] * right.entries[2, 1],
           left.entries[1, 0] * right.entries[0, 2] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],

           left.entries[2, 0] * right.entries[0, 0] + left.entries[2, 1] * right.entries[1, 0] + left.entries[2, 2] * right.entries[2, 0],
           left.entries[2, 0] * right.entries[0, 1] + left.entries[2, 1] * right.entries[1, 1] + left.entries[2, 2] * right.entries[2, 1],
           left.entries[2, 0] * right.entries[0, 2] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2]); */
        HMatrix2D newMatrix = new HMatrix2D();
        for (int x = 0; x < 3; x++) // checks for each row and column in the matrix
        {
            for (int y = 0; y < 3; y++)
            {
                newMatrix.entries[x, y] = 0; // sets the new matrix to have a value of 0 at all points
                for (int z = 0; z < 3; z++) // accounts for the remultiplying of the rowws and columns e.g. [0, 0] will multiply with [0, (1), (2) and (3)]
                {
                    newMatrix.entries[x, y] += left.entries[x, z] * right.entries[z, y]; // does the formula for multiplying matrices
                }
            }
        }
        return newMatrix; 
    }
    
    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (left.entries[x, y] != right.entries[x, y]) // checks if matrices are equal
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (left.entries[x, y] != right.entries[x, y]) // checks is matrices are not equal
                {
                    return true;
                }
            }
        }
        return false;
    }

   /* public override bool Equals(object obj)
    {
        // your code here
    }

    public override int GetHashCode()
    {
        // your code here
    } */

    /*public HMatrix2D transpose()
    {
        return // your code here
    }

    public float getDeterminant()
    {
        return // your code here
    } */

    public void setIdentity()
    {
        /*for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (y == x)
                {
                    entries[x, y] = 1;
                }
                else
                {
                    entries[x, y] = 0;
                }
            }
        } */
        for (int x = 0; x < 3; x++)
        {
            for(int y = 0; y < 3; y++)
            {
                entries[x, y] = x == y ? 1 : 0;
            }
        }
    }

    public void setTranslationMat(float transX, float transY)
    {
        setIdentity();

        entries[0, 2] = (float)transX;
        entries[1, 2] = (float)transY; // translation matrix (its in the slides)
    }

    public void setRotationMat(float rotDeg)
    {
        setIdentity();
        float rad = rotDeg * Mathf.Deg2Rad;
        entries[0, 0] = Mathf.Cos(rad);
        entries[0, 1] = -Mathf.Sin(rad);
        entries[1, 0] = Mathf.Sin(rad);
        entries[1, 1] = Mathf.Cos(rad); // rotation matrix 
    }

    public void setScalingMat(float scaleX, float scaleY)
    {
        // your code here
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
