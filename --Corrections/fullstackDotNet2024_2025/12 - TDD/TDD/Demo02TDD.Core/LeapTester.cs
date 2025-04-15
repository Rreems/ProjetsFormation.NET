using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02TDD.Core;

/*
On souhaite développer une application qui nous permet de connaître si une année est bissextile

Les critères pour une années sont :

- Une année divisible par 400.
- Une année divisible par 4 mais pas par 100.
- Une année n'est pas divisible par 4000.

Le développement doit se faire en TDD
*/
public class LeapTester
{
    public bool IsLeap(int year)
    {
        // INITIAL
        //throw new NotImplementedException();

        // GREEN 1
        //if (year % 400 == 0)
        //    return true;
        //throw new NotImplementedException();

        // GREEN 2
        //if (year % 400 == 0)
        //    return true;
        //if (year % 4 == 0 && year % 100 != 0)
        //    return true;
        //throw new NotImplementedException();

        // REFACTOR 2
        //if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
        //    return true;
        //throw new NotImplementedException();

        // GREEN 3
        //if (year % 4000 == 0)
        //    return false;
        //if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
        //    return true;
        //throw new NotImplementedException();

        // GREEN 4
        //if (year % 4000 == 0)
        //    return false;
        //if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
        //    return true;
        //return false;

        // REFACTOR 4
        return (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)) && year % 4000 != 0;

    }
}
