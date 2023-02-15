Console.WriteLine("enter a formula");
string formula = Console.ReadLine()!;
int result = Evaluate(formula);
System.Console.WriteLine($"The result is: {result}");

int Evaluate(string formula)
{
    int result = 0;

    formula = formula.Replace(" ", "");

    if (formula == "") { return 0; }

    bool minus = formula.Contains('-');
    bool plus = formula.Contains('+');
    if (!minus && !plus) { return int.Parse(formula); }

    int indexOfOperator;
    char op = '+';
    do
    {
        indexOfOperator = FindIndexOfNextOperator(formula);
        if (indexOfOperator == -1)
        {
            if (op == '+') { result += int.Parse(formula); }
            else { result -= int.Parse(formula); }
        }
        else
        {
            string leftFormula = formula.Substring(0, indexOfOperator);
            if (op == '+') { result += int.Parse(leftFormula); }
            else { result -= int.Parse(leftFormula); }

            op = formula[indexOfOperator];
            formula = formula.Substring(indexOfOperator + 1);
        }
    }
    while (indexOfOperator != -1);

    return result;
}

int FindIndexOfNextOperator(string formula)
{
    int IndexOfPlus = formula.IndexOf('+');
    int IndexOfMinus = formula.IndexOf('-');
    if (IndexOfPlus == -1) { return IndexOfMinus; }
    if (IndexOfMinus == -1) { return IndexOfPlus; }
    return Math.Min(IndexOfPlus, IndexOfMinus);
}
