namespace KataAttemptThree
{
    public class AttemptThree
    {
        public int Add(string numbers)
        {
            int sum = 0;
            if (numbers != "")
            {
                if (numbers.Contains("-"))
                {
                    ThrowNegetivesExtension(StringToNumbersArray(numbers));
                }
                List<int> newArrayOnumbers = new List<int>(StringToNumbersArray(numbers));
                for (int i = 0; i < newArrayOnumbers.Count; i++)
                {
                    if (newArrayOnumbers[i] > 1000)
                    {
                        i++;
                    }
                    sum += newArrayOnumbers[i];
                }
            }
            return sum;
        }


        //Create int list array of numbers 
        public List<int> StringToNumbersArray(string numbers)
        {
            List<int> arrayOfNumbers = new List<int>();
            string[] numbersArray = numbers.Split(DelimeterList(numbers), StringSplitOptions.None);
            foreach (var number in numbersArray)
            {
                if (int.TryParse(number, out int n) == true)
                {
                    arrayOfNumbers.Add(Convert.ToInt32(number));
                }
            }
            return arrayOfNumbers;
        }


        //Delimeters list method
        public string[] DelimeterList(string numbers)
        {
            List<string> delimeterList = new List<string>() { ",", "\n" };
            if (numbers.Contains("//"))
            {
                delimeterList.Add(ExtendedDelimeter(numbers));
                if (numbers.Substring(2, 1) == "[")
                {
                    foreach (var delilemterItem in BracketdDelimeter(numbers).ToCharArray())
                    {
                        delimeterList.Add(delilemterItem.ToString());
                    }
                }
                delimeterList.Add(numbers.Substring(2, 1));
                delimeterList.Remove("[");
            }
            string[] delimeters = delimeterList.ToArray();
            return delimeters;
        }


        // *** Delimeter
        public string ExtendedDelimeter(string numbers)
        {
            string delimeter = "";
            char[] characterArray = numbers.ToCharArray();
            for (int x = 2; x < characterArray.Length - 1; x++)
            {
                if (characterArray[x] == '*')
                {
                    delimeter += "*";
                }
                if (characterArray[x] == ';')
                {
                    delimeter += ";";
                }
                if (characterArray[x] == ',')
                {
                    delimeter += ",";
                }
                if (characterArray[x] == '%')
                {
                    delimeter += "%";
                }
                break;
            }
            return delimeter;
        }
        public Exception ThrowNegetivesExtension(List<int> arrayOfNumbers)
        {
            string negetives = "Negatives not allowed.";
            foreach (var item in arrayOfNumbers)
            {
                if (item < 0)
                {
                    negetives += "\n" + item;
                }
            }
            throw new Exception(negetives);
        }
        public string BracketdDelimeter(string numbers)
        {
            int index = numbers.LastIndexOf("]");
            string delimeter = numbers.Substring(3, index - 3).Replace("]", "");
            delimeter = delimeter.Replace("[", "");
            return delimeter.Trim();
        }
    }
}