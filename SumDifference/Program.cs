
/*
    -uses Cramer's Rule to solve basic 2 X 2 linear equation with sum and difference
    -asks for user input of sum and difference
*/

#region main

decimal sum, difference;


Console.WriteLine("Enter the sum  of two numbers: ");

if(decimal.TryParse(Console.ReadLine(), out sum))
{
    Console.WriteLine($"You entered sum of {sum}");
}
else{
    Console.WriteLine("Wrong type. Try again");
    Environment.Exit(0);
}

Console.WriteLine("Enter differce of the above numbers");
if(decimal.TryParse(Console.ReadLine(), out difference))
{
    Console.WriteLine($"You entered difference of {difference}");
}
else{
    Console.WriteLine("Wrong type. Try again");
    Environment.Exit(0);
}



decimal [] nums = SolveEquation(1, 1, 1, -1, sum, difference);

Console.WriteLine("The numbers are: ");
foreach(decimal x in nums)
{
    Console.Write($"{x} ");
}
Console.WriteLine();

#endregion


#region helper static methods

/*
        This method uses Cramer's Rule to solve 2 X 2 Linear equation
        equation is a11 x + a12 y = k1
                    a21 x + a22 y = k2
                    a11, a12, a21, a22 are coefficients and k1, k2 are constants
*/

static decimal[] SolveEquation(decimal a11, decimal a12, decimal a21, decimal a22, decimal k1, decimal k2)
{
    decimal [] result = new decimal[2];

    decimal det = FindDet(a11, a12, a21, a22);
    
    //if determinant of coefficients is 0, there is no unique solution
    if(det == Decimal.Zero)
    {
    throw new ArgumentException();
    }

    
    decimal detX = FindDet(k1, a12, k2, a22);
    decimal detY = FindDet(a11, k1, a21, k2);

    result[0] = detX/det;
    result[1] = detY/det;
    return result;

}

/*
It's a private method to find the determinant of 2 X 2 matrix  | a11  a12 |
                                                                | a21   a22 |
*/

static decimal FindDet(decimal a11, decimal a12, decimal a21, decimal a22)

{
    return a11 * a22 - a21 * a12;
}

#endregion



