//var detonationToTheLeft = -1;
//var detonationToTheRight = 1;


//var currentRow = targetRow;
//var currentCol = targetCol;


//while (detonationToTheLeft >= bombRadius * -1 || detonationToTheRight <= bombRadius)
//{
//    var leftIsGood = false;
//    var currentExplosionRowToTheLeft = targetRow + detonationToTheLeft;
//    var currentExplosionColToTheLeft = targetCol + detonationToTheLeft;

//    if (IndexIsValid(currentExplosionRowToTheLeft, basement.Length) ? leftIsGood = true : leftIsGood = false)
//    {
//        basement[currentExplosionRowToTheLeft][targetCol] = 1;
//    }

//    if (IndexIsValid(currentExplosionColToTheLeft, basement[targetRow].Length) ? leftIsGood = true : leftIsGood = false)
//    {
//        basement[targetRow][currentExplosionColToTheLeft] = 1;
//    }

//    if (detonationToTheLeft > bombRadius * -1 && leftIsGood)
//    {
//        basement[currentExplosionRowToTheLeft][currentExplosionColToTheLeft] = 1;
//    }

//    var rightIsGood = false;
//    var currentExplosionRowToTheRight = targetRow + detonationToTheRight;
//    var currentExplosionColToTheRight = targetCol + detonationToTheRight;

//    if (IndexIsValid(currentExplosionRowToTheRight, basement.Length) ? rightIsGood = true : rightIsGood = false)
//    {
//        basement[currentExplosionRowToTheRight][targetCol] = 1;
//    }

//    if (IndexIsValid(currentExplosionColToTheRight, basement[targetRow].Length) ? rightIsGood = true : rightIsGood = false)
//    {
//        basement[targetRow][currentExplosionColToTheRight] = 1;
//    }

//    if (detonationToTheRight < bombRadius && leftIsGood)
//    {
//        basement[currentExplosionRowToTheRight][currentExplosionColToTheRight] = 1;
//    }

//    detonationToTheLeft--;
//    detonationToTheRight++;
//}

//starting from the left side of the explosions, continuing to the right side of the explosion.using System;
using System.Collections.Generic;
using System.Text;

namespace _6.BombTheBasement
{
    class Demo
    {
    }
}
