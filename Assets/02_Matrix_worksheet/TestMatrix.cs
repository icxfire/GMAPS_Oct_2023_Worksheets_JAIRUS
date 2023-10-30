using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();
    // Start is called before the first frame update
    void Start()
    {
        //mat.setIdentity();
        // mat.Print();
        Question2();
    }

    void Question2()
    {
        HMatrix2D mat1 = new HMatrix2D(1,2,3,4,5,6,7,8,9);
        HMatrix2D mat2 = new HMatrix2D(1,4,7,2,5,8,3,6,9);
        HMatrix2D resultMat = new HMatrix2D();
        HVector2D vec1 = new HVector2D(1,2);
        HVector2D resultVec = new HVector2D();

        resultMat = mat1 * mat2;
        resultVec = mat1 * vec1;
        resultMat.Print();
    }
}
