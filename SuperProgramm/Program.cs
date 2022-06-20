
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

int charRangeFrom = 0x030;
int charRangeUp = 0x05A;

int rangeSizeStringMax = 15;
int countString = new Random().Next(1, 10);


if (handInputStatus == false)
{
    Console.WriteLine("Создание массива строк.");

    string[] randomTextArray = new string[countString];

    FillArrayRndmTxt(randomTextArray);
    PrintArray(randomTextArray);

    Console.WriteLine("Введите число, для сортировки строк содержащих меньше, чем это число символов.");
    int qtyCharInput = Convert.ToInt32(Console.ReadLine());

    string[] newText = StringSort(randomTextArray, qtyCharInput);
    PrintArray(newText);


}
else if (handInputStatus == true)
{
    Console.WriteLine("Введите текст, а для разбития на отдельные ячейки массива используйте запятую (,) " +
    "Иначе весь текст попадет в одну ячейку массива!");
    string input = Console.ReadLine();
    while (input == String.Empty)
    {
        StrEmpt(input);
        input = Console.ReadLine();
    }

    string[] text = InputString(input);

    Console.WriteLine("Введите число, для сортировки строк содержащих меньше, чем это число символов.");
    int qtyCharInput = Convert.ToInt32(Console.ReadLine());
    string[] newText = StringSort(text, qtyCharInput);
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

void StrEmpt(string str)
{
    if (str == string.Empty)
    {
        Console.WriteLine("Вы ничего не ввели, введите текст! ");
    }
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
        if (tempString.Length < qty)
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