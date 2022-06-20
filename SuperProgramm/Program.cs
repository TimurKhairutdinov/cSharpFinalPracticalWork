
Console.WriteLine("Итоговая работа по C#.");
Console.WriteLine("Хотите ввести самостоятельно массив строк?");
Console.WriteLine("Если да, введите 'Yes'" + " если нет, введите 'No'");
string handInput = Console.ReadLine();

bool handInputStatus = false;

if (handInput.ToLower() == "yes")
{
    handInputStatus = true;
}
else if (handInput.ToLower() == "no")
{
    handInputStatus = false;
}
else while (handInput.ToLower() != "yes" || handInput.ToLower() != "no")
    {
        Console.WriteLine("Некорректный ввод, повторите!");
        handInput = Console.ReadLine();

        if (handInput.ToLower() == "yes" || handInput.ToLower() == "no")
        {
            if (handInput.ToLower() == "yes")
            {
                handInputStatus = true;
            }
            else if (handInput.ToLower() == "no")
            {
                handInputStatus = false;
            }
            break;
        }
    }

// Переменные для условия handInputStatus = false
int charRangeFrom = 0x030;
int charRangeUp = 0x05A;

int rangeSizeStringMax = 15;
int countString = new Random().Next(3, 15);


if (handInputStatus == false)
{
    Console.WriteLine("Сформирован случайный массив строк." +
    "Запятая (,) в данном случае не является элементом строки, а служит для разделения элементов массива! ");

    string[] randomTextArray = new string[countString];

    FillArrayRndmTxt(randomTextArray);
    PrintArray(randomTextArray);

    Console.WriteLine("Введите число, для сортировки строк содержащих меньше, чем это число символов, или равно ему.");
    string qtyCharInput = Console.ReadLine();

    int convertQtyChar = CheckCorrectInput(qtyCharInput);

    string[] newText = StringSort(randomTextArray, convertQtyChar);
    PrintArray(newText);
}

else if (handInputStatus == true)
{
    Console.WriteLine("Введите текст, а для разбития на отдельные ячейки массива используйте запятую (,) " +
    "Иначе весь текст попадет в одну ячейку массива!");
    string input = Console.ReadLine();

    if (input == String.Empty)
    {
        StrEmpt(input);
    }

    string[] text = InputString(input);

    Console.WriteLine("Введите число, для сортировки строк содержащих меньше, чем это число символов, или равно ему.");
    string qtyCharInput = Console.ReadLine();

    int convertQtyChar = CheckCorrectInput(qtyCharInput);

    string[] newText = StringSort(text, convertQtyChar);
    PrintArray(newText);
}

string[] InputString(string output)
{
    int countNumbers = 1;
    for (int i = 0; i < output.Length; i++)
    {
        if (output[i] == ',')
            countNumbers++;
    }

    string[] numbers = new string[countNumbers];
    int numberIndex = 0;
    for (int i = 0; i < output.Length; i++)
    {
        string subString = String.Empty;
        while (output[i] != ',')
        {
            if (i != output.Length - 1)
            {
                subString += output[i].ToString();
                i++;
            }
            else
            {
                subString += output[i].ToString();
                break;
            }
        }

        if (subString == "" || subString == " ")
            continue;

        if (i != output.Length - 1)
        {
            numbers[numberIndex] = subString;
            numberIndex++;
        }
        else numbers[numberIndex] = subString;
    }
    return numbers;
}

string StrEmpt(string str)
{
    while (str == string.Empty)
    {
        Console.WriteLine("Вы ничего не ввели, введите текст! ");
        str = Console.ReadLine();
    }
    return str;
}

void PrintArray(string[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (i == 0)
        {
            Console.Write("[");
        }
        Console.Write(array[i]);
        if (i < array.Length - 1)
        {
            Console.Write(", ");
        }
        else
        {
            Console.Write("]");
        }
    }
    Console.WriteLine();
}

int QtyStringLessQtyChar(string[] arr, int qty)
{
    int result = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        string tempString = arr[i];
        if (tempString.Length <= qty)
        {
            result++;
        }
    }
    return result;
}

string[] StringSort(string[] arrStr, int qtyChar)
{
    int size = QtyStringLessQtyChar(arrStr, qtyChar);
    string[] newArray = new string[size];
    int index = 0;
    for (int i = 0; i < arrStr.Length; i++)
    {
        string tempString = arrStr[i];
        if (tempString.Length <= qtyChar)
        {
            newArray[index] = tempString;
            index++;
        }
    }
    return newArray;
}

void FillArrayRndmTxt(string[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        string tempText = GetRndmTxt(rangeSizeStringMax, charRangeFrom, charRangeUp);
        arr[i] = tempText;
    }
}

string GetRndmTxt(int rangeSizeStringMax, int charRangeFrom, int charRangeUp)
{

    string tempString = String.Empty;
    Random rnd = new Random();
    for (int i = 0; i < rnd.Next(1, rangeSizeStringMax); i++)
    {
        tempString += (Char)new Random().Next(charRangeFrom, charRangeUp); // 0000—007F
    }
    return tempString;
}

bool CheckoForDigit(string inputText)
{
    bool digitStatus = true;
    for (int i = 0; i < inputText.Length; i++)
    {
        if (Char.IsDigit(inputText[i]) == false)
        {
            digitStatus = false;
            break;
        }
    }
    return digitStatus;
}

int CheckCorrectInput(string qtyCharInput)
{
    bool checkDigit = CheckoForDigit(qtyCharInput);
    while (checkDigit == false)
    {
        Console.WriteLine("Некорректный ввод, текст содержит что-то помимо цифр! " +
        "Повторите ввод!");
        qtyCharInput = Console.ReadLine();
        checkDigit = CheckoForDigit(qtyCharInput);
    }
    int convertQtyChar = Convert.ToInt32(qtyCharInput);
    return convertQtyChar;
}