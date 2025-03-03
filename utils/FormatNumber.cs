namespace ThermalPrinterLibrary_CSharp.utils
{
    public static class FormatNumber
    {
        public static string Convert(int number, bool useEnglish = false)
        {
            if (useEnglish)
            {
                return NumberToWordsEnglish(number);
            }
            else
            {
                return NumberToWordsSpanish(number);
            }
        }

        private static string NumberToWordsEnglish(int number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "Minus " + NumberToWordsEnglish(Math.Abs(number));

            string words = "";

            if (number / 1_000_000 > 0)
            {
                words += NumberToWordsEnglish(number / 1_000_000) + " Million ";
                number %= 1_000_000;
            }

            if (number / 1_000 > 0)
            {
                words += NumberToWordsEnglish(number / 1_000) + " Thousand ";
                number %= 1_000;
            }

            if (number / 100 > 0)
            {
                words += NumberToWordsEnglish(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                string[] units = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                               "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                string[] tens = { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += units[number];
                else
                {
                    words += tens[number / 10];
                    if (number % 10 > 0)
                        words += "-" + units[number % 10];
                }
            }

            return words.Trim();
        }

        private static string NumberToWordsSpanish(int number)
        {
            if (number == 0)
                return "Cero";

            if (number < 0)
                return "Menos " + NumberToWordsSpanish(Math.Abs(number));

            string words = "";

            if (number / 1_000_000 > 0)
            {
                words += NumberToWordsSpanish(number / 1_000_000) + " Millón ";
                number %= 1_000_000;
            }

            if (number / 1_000 > 0)
            {
                words += NumberToWordsSpanish(number / 1_000) + " Mil ";
                number %= 1_000;
            }

            if (number / 100 > 0)
            {
                words += NumberToWordsSpanish(number / 100) + " Ciento ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "y ";

                string[] units = { "Cero", "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Ocho", "Nueve", "Diez",
                               "Once", "Doce", "Trece", "Catorce", "Quince", "Dieciséis", "Diecisiete", "Dieciocho", "Diecinueve" };
                string[] tens = { "Cero", "Diez", "Veinte", "Treinta", "Cuarenta", "Cincuenta", "Sesenta", "Setenta", "Ochenta", "Noventa" };

                if (number < 20)
                    words += units[number];
                else
                {
                    words += tens[number / 10];
                    if (number % 10 > 0)
                        words += " y " + units[number % 10];
                }
            }

            return words.Trim();
        }
    }
}
