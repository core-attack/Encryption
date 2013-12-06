using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Encryption
{
    public partial class GeneralForm : Form
    {
        string[] encTypes = { "Квадрат Виженера", "ГОСТ СССР 28147-89", "RC5" };
        List<char> ruBig = new List<char> { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ', 'Э', 'Ю', 'Я', ' ' };
        List<char> ruSmall = new List<char> { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ', 'э', 'ю', 'я' };
        List<char> enBig = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' '};
        List<char> enSmall = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        List<char> num = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        char[] enru = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                          'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ', 'Э', 'Ю', 'Я', ' ' };
        char[,] sqrVigenere;
        List<List<char>> allArrays = new List<List<char>>();
        //исходное сообщение
        List<char> defaultText = new List<char>();
        //исходное сообщение замененое ключевым словом
        List<char> keyDefText = new List<char>();
        //соотвествие буквы ключа с буквой исходного текста
        //Dictionary<char, char> keyTextHash = new Dictionary<char, char>();
        //Dictionary<string, char> ResultTextHash = new Dictionary<string, char>();
        Encoding encoding = Encoding.ASCII;
        string MESSAGE = "";
        string KEYMASSAGE = "";
        string ENCRYPT = "";
        string DECRYPT = "";
        string KEY = "воландеморт";
        //должен быть меньше половины длины массива всех символов
        int IMPORTANT_NUMBER = 71;
        List<string> log = new List<string>();
        List<byte[]> before = new List<byte[]>();
        List<byte[]> after = new List<byte[]>();
        string logPath = "txt\\log.txt";
        string sqrPath = "txt\\sqr.txt";
        string caPath = "txt\\crAn.txt";

        string[] bin_numbers = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
        string[] hex_numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
        Dictionary<string, string> hex = new Dictionary<string, string>();

        public GeneralForm()
        {
            InitializeComponent();
            Text = "Методы шифрования " + "[" + InputLanguage.CurrentInputLanguage.Culture.Name + "]";
            setEncType();
            generateSqrVigenere(ruBig);
            allArrays.Add(ruBig);
            allArrays.Add(ruSmall);
            allArrays.Add(enBig);
            allArrays.Add(enSmall);
            allArrays.Add(num);
            comboBoxW.Items.Add("16");
            comboBoxW.Items.Add("32");
            comboBoxW.Items.Add("64");
            for (int i = 0; i < bin_numbers.Length; i++)
                hex[bin_numbers[i]] = hex_numbers[i];
        }

        void setEncType()
        {
            foreach (string s in encTypes)
                comboBoxEncType.Items.Add(s);
            comboBoxEncType.Text = comboBoxEncType.Items[comboBoxEncType.Items.Count - 1].ToString();
        }

        private void buttonEnc_Click(object sender, EventArgs e)
        {
            encrypt(richTextBox.Text, true);
        }
        
        string generateKey(List<char> arr, int maxLenght)
        {
            Random r = new Random();
            string k = "";
            int mas = 0;
            while (k.Length < maxLenght)
            {
                //выбираем массив
                mas = r.Next(arr.Count - 1);
                k += arr[mas];
            }
            return k;
        }

        string generateKey(int length)
        {
            Random r = new Random();
            string k = "";
            int mas = 0;
            while (k.Length < length)
            {
                //выбираем массив
                mas = r.Next(allArrays.Count - 1);
                k += allArrays[mas][r.Next(allArrays[mas].Count - 1)];
            }
            return k;
        }

        //возвращает заданное количество подключей заданным размером (в битах)
        string[] generateKey(int count, int size)
        {
            Random r = new Random();
            string k = "";
            int mas = 0;
            string[] keys = new string[count];
            for (int i = 0; i < count; i++)
            {
                while ((k.Length + 1) * 16  <= size)
                {
                    //выбираем массив
                    mas = r.Next(allArrays.Count - 1);
                    k += allArrays[mas][r.Next(allArrays[mas].Count - 1)];
                }
                k = "";
                mas = 0;
                keys[i] = k;
            }
            return keys;
        }

        List<byte[]> splitKeys(byte[] KEY, int size) 
        {
            List<byte[]> result = new List<byte[]>();
            byte[] key = new byte[size];
            int count = 0;
            int index = 0;
            for (int i = 0; i < KEY.Length; i++)
            {
                if (count < size)
                {
                    index = i % size;
                    key[index] = KEY[i];
                    count++;
                }
                else
                {
                    result.Add(key);
                    count = 0;
                    key = new byte[size];
                    index = i % size;
                    key[index] = KEY[i];
                    count++;
                }
                if (i == KEY.Length - 1)
                    result.Add(key);
            }
            return result;
        }


        //разбивает строку на указанное количество подстрок заданного размера (в битах)
        string[] splitString(string s, int count, int size)
        {
            string[] arr = new string[count];
            string sub = "";
            int k = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if ((sub.Length + 1) * 16 <= size)
                {
                    sub += s[i];
                }
                else
                {
                    if (k < arr.Length)
                    {
                        arr[k] = sub;
                        k++;
                        sub = "";
                    }
                }
            }
            if (sub.Length != 0)
            {
                sub.PadRight(size / 8, ' ');
                if (k < arr.Length)
                    arr[k] = sub;
            }
            return arr;
        }


        //увеличивает строку до нужной длины путём добавления её самой в её конец
        string lengthString(int length, string s)
        {
            string result = "";
            int count = length / s.Length;
            
            if (count == 0)//т.е. длина ключа слишком большая
            {
                for (int i = 0; i < length; i++)
                    result += s[i];
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    result += s;
                }
                int ost = length % s.Length;
                if (ost != 0)
                {
                    for (int i = 0; i < ost; i++)
                        result += s[i];
                }
            }
            return result;
        }

        void generateSqrVigenere(List<char> array)
        {
            sqrVigenere = new char[array.Count, array.Count];
            for (int i = 0; i < array.Count; i++)
            {
                for (int j = 0; j < array.Count; j++)
                {
                    sqrVigenere[i, j] = array[j];
                }
                char s = array[0];
                array.RemoveAt(0);
                array.Insert(array.Count, s);
            }
            
        }

        char[,] generateChangedSqrVigenere(List<char> array)
        {
            char[,] sqr = new char[array.Count, array.Count];
            for (int i = 0; i < array.Count; i++)
            {
                for (int j = 0; j < array.Count; j++)
                {
                    sqr[i, j] = array[j];
                }
                char s = array[0];
                array.RemoveAt(0);
                array.Insert(array.Count, s);
            }
            return sqr;
        }

        string[,] generateChangedSqrVigenere(List<string> array)
        {
            string[,] sqr = new string[array.Count, array.Count];
            for (int i = 0; i < array.Count; i++)
            {
                for (int j = 0; j < array.Count; j++)
                {
                    sqr[i, j] = array[j];
                }
                string s = array[0];
                array.RemoveAt(0);
                array.Insert(array.Count, s);
            }
            return sqr;
        }

        byte[,] generateChangedSqrVigenere(List<byte> array)
        {
            byte[,] sqr = new byte[array.Count, array.Count];
            for (int i = 0; i < array.Count; i++)
            {
                for (int j = 0; j < array.Count; j++)
                {
                    sqr[i, j] = array[j];
                }
                byte s = array[0];
                array.RemoveAt(0);
                array.Insert(array.Count, s);
            }
            return sqr;
        }


        //задает массив букв замененный ключом
        void setDefaultTextList(string s)
        {
            KEYMASSAGE = "";
            defaultText.Clear();
            keyDefText.Clear();
            int l = s.Length / KEY.Length + 1;
            string keytext = "";
            for (int i = 0; i < l; i++)
                keytext += KEY;
            for (int i = 0; i < s.Length; i++)
            {
                defaultText.Add(s[i]);
                keyDefText.Add(keytext[i]);
                KEYMASSAGE += keytext[i];
            }

        }

        //возвращает по символам-координатам соответствующий элемент квадрата Виженера
        char getChar(char x, char y)
        {
            int idx1 = -1;
            int idx2 = -1;
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ru-RU");
            if (InputLanguage.CurrentInputLanguage.Culture.Name.Equals(ci.Name))
                for (int i = 0; i < ruBig.Count; i++)
                {
                    if (ruBig[i].Equals(Char.ToUpper(x)))
                        idx1 = i;
                    if (ruBig[i].Equals(Char.ToUpper(y)))
                        idx2 = i;
                }
            else
                foreach (char c in enBig)
                {
                    for (int i = 0; i < enBig.Count; i++)
                    {
                        if (enBig[i].Equals(Char.ToUpper(x)))
                            idx1 = i;
                        if (enBig[i].Equals(Char.ToUpper(y)))
                            idx2 = i;
                    }
                }
            return sqrVigenere[idx1, idx2];
        }

        byte getChar(byte x, byte y, byte[,] sqr)
        {

            int idx1 = -1;
            int idx2 = -1;
            for (int i = 0; i < sqr.GetLength(0); i++)
                for (int j = 0; j < sqr.GetLength(1); j++)
                {
                    if (sqr[i, 0].Equals(x))
                        idx1 = i;
                    if (sqr[0, j].Equals(y))
                        idx2 = j;
                }
            return sqr[idx1, idx2];
        }

        //разбивает сообщение на блоки, указанной величины в битах
        List<string> getAllBlocks(int size, string mes)
        {
            if (size % 2 != 0)
            {
                List<string> list = new List<string>();
                string block = "";
                for (int i = 0; i < mes.Length; i++)
                {
                    //one symbol of char required 2 bytes
                    //16 = 2 байта, проверяем, будет ли добавление следующего символа увеличивать строку выше допустимого размера
                    if (16 * (block.Length + 1) <= size)
                    {
                        block += mes[i];
                    }
                    else
                    {
                        list.Add(block);
                        block = "";
                    }
                }
                if (block.Length != 0)
                {
                    //дополняем последний блок пробелами
                    block.PadRight(4, ' ');
                    list.Add(block);
                    block = "";
                }
                return list;
            }
            else
            {
                MessageBox.Show("Величина блока должна быть кратной 2! Параметр выличины блока size = " + size.ToString());
                return null;
            }
            
        }
        
        List<byte[]> getAllBlocks(int size, int blockSize, byte[] mes)
        {
            List<byte[]> result = new List<byte[]>();
            if (size % blockSize != 0)
            { MessageBox.Show("Ничего делать не буду, хочу блоки размером, кратным 8"); }
            else
            {
                byte[] bytes;
                if (size != 64)
                    bytes= new byte[blockSize];
                else
                    bytes = new byte[size / blockSize];
                int count = 0;
                for (int i = 0; i < mes.Length; i++)
                {
                    if (count < blockSize)
                    {
                        int index = i % blockSize;
                        bytes[index] = mes[i];
                        count++;
                    }
                    else //последний массив может содержать лишние символы
                    {
                        result.Add(bytes);
                        if (size != 64)
                            bytes = new byte[blockSize];
                        else
                            bytes = new byte[size / blockSize];
                        count = 0;
                        int index = i % blockSize;
                        bytes[index] = mes[i];
                        count++;
                    }
                    if (i == mes.Length - 1)
                        result.Add(bytes);
                }
            }
            return result;
        }

        //возвращает левый или правый подблок блока
        string subBlock(string block, string leftORright)
        {
            string sBlock = "";
            if (block.Length / 2 != 0)
                MessageBox.Show("Длина блока нечетная: " + block.Length);
            else
            {
                int count = block.Length / 2;
                if (leftORright.Equals("left"))
                {
                    for (int i = 0; i < count; i++)
                        sBlock += block[i];
                }
                else if (leftORright.Equals("right"))
                {
                    for (int i = count; i < block.Length; i++)
                        sBlock += block[i];
                }
            }
            return sBlock;
        }

        byte[] subBlock(byte[] block, string leftORright)
        {
            int count = block.Length / 2;
            byte[] sblock = new byte[count];
            if ("left".Equals(leftORright))
                for (int i = 0; i < count; i++)
                    sblock[i] = block[i];
            else
                for (int i = count; i < block.Length; i++)
                    sblock[i - count] = block[i];
            return sblock;
        }

        //десятичное в любую
        string tenToSS(long ten, int SS)
        {
            List<double> listCel = new List<double>();
            List<double> listOst = new List<double>();
            long cel = -1;
            long ost = 0;
            string result = "";
            while (cel != 0)
            {
                cel = ten / SS;
                listCel.Add(cel);
                ost = ten % SS;
                listOst.Add(ost);
                ten = cel;
            }

            for (int i = listOst.Count - 1; i >= 0; i--)
                result += listOst[i];
            return result;
        }

        //двоичное в десятичное
        public double conv2to10(string s)
        {
            double result = 0;
            double stepen = 0;
            double pokazatel = 2;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '1')
                {
                    result += Math.Pow(pokazatel, stepen);
                }
                else if (s[i] != '0')
                {
                    return -1;
                }
                stepen += 1;
            }
            return Convert.ToInt32(result);
        }

        //складывает два двоичных числа
        string binSum(string a, string b)
        {
            int A = Convert.ToInt32(a, 2);
            int B = Convert.ToInt32(b, 2);
            int C = A + B;
            return Convert.ToString(C, 2);
        }

        //бинарное в шестнадцатиричное
        string to_hex(string bin)
        {
            string result = "";
            int j = bin.Length - 1;
            List<string> l = new List<string>();
            while (j >= 0)
            {
                string s = "";
                if (j > 3)
                    s = bin.Substring(j - 3, 4);
                else if (bin.Length % 4 != 0)
                    s = bin.Substring(0, bin.Length % 4); 
                while (s.Length < 4)
                    s = "0" + s;
                result = hex[s] + result; 
                j -= 4;
            }
            return result;
        }

        //складывает два двоичных числа
        string binSum(string a, string b, int ss, int W)
        {
            long A = Convert.ToInt64("0x" + a, ss);
            long B = Convert.ToInt64("0x" + b, ss);//FIXME при больших значениях становится отрицательным
            long C = A + B;
            string hex = to_hex(tenToSS(C, 2));
            switch (W)
            {
                case 16: 
                    while (hex.Length > 4)
                        return hex.Remove(0, 1);
                    break;
                case 32:
                    while (hex.Length > 8)
                        return hex.Remove(0, 1);
                    break;
                case 64:
                    while (hex.Length > 16)
                        return hex.Remove(0, 1);
                    break;
            }
            return hex;
        }



        //суммирует байтовые числа по модулю 2 в size степени (для ГОСТА!)
        byte[] sumMod(byte[] x, byte[] y, int size)
        {
            try
            {
                string a = "";
                string b = "";
                string c = "";
                //string[] z = new string[x.Length];
                for (int i = 0; i < x.Length; i++)
                {
                    //z[i] = Convert.ToString(x[i] + y[i], 2);
                    a += eightnaryNumber(tenToSS(Convert.ToInt32(x[i]), 2));
                    b += eightnaryNumber(tenToSS(Convert.ToInt32(y[i]), 2));
                }
                
                List<byte> result = new List<byte>();
                if (size == 32)
                {
                    setlog(x, a);
                    log.Add("+ mod 2^32");
                    setlog(y, b);
                    log.Add("=");
                    c = binSum(a, b);
                    if (c.Length > size)
                        c = c.Substring(c.Length - size);
                    while (c.Length != 32)
                        c = "0" + c;
                    for (int i = x.Length - 1; i >= 0; i--)
                    {
                        string s = c.Substring(i * 8, 8);
                        result.Add(Convert.ToByte(conv2to10(s)));
                    }
                    result.Reverse();
                    setlog(result.ToArray(), c);
                }
                else if (size == 2)
                {
                    setlog(x, a);
                    log.Add("+ mod 2");
                    setlog(y, b);
                    log.Add("=");
                    string resultS = "";
                    if (a.Length >= b.Length)
                    {
                        int count = a.Length - b.Length;
                        for (int i = b.Length - 1; i >= 0; i--)
                            if (a[i + count] == '1' && b[i] == '1')
                                resultS = "0" + resultS;
                            else if (a[i + count] == '1' && b[i] == '0')
                                resultS = "1" + resultS;
                            else if (a[i + count] == '0' && b[i] == '1')
                                resultS = "1" + resultS;
                            else if (a[i + count] == '0' && b[i] == '0')
                                resultS = "0" + resultS;
                        for (int i = 0; i < count; i++)
                            if (a[i] == '1')
                                resultS = "1" + resultS;
                            else
                                resultS = "0" + resultS;
                    }
                    else
                    {
                        int count = b.Length - a.Length;
                        for (int i = a.Length - 1; i >= 0; i--)
                            if (a[i] == '1' && b[i + count] == '1')
                                resultS = "0" + resultS;
                            else if (a[i] == '1' && b[i + count] == '0')
                                resultS = "1" + resultS;
                            else if (a[i] == '0' && b[i + count] == '1')
                                resultS = "1" + resultS;
                            else if (a[i] == '0' && b[i + count] == '0')
                                resultS = "0" + resultS;
                        for (int i = count - 1; i >= 0; i--)
                            if (b[i] == '1')
                                resultS = "1" + resultS;
                            else
                                resultS = "0" + resultS;
                    }
                    string str = resultS;
                    char[] chars = str.ToCharArray();
                    string rS = new string(chars);
                    while (resultS.Length != 32)
                        resultS = "0" + resultS;
                    for (int i = 0; i < x.Length; i++ )
                    {
                        string s = resultS.Substring(i * 8, 8);
                        result.Add(Convert.ToByte(conv2to10(s)));
                    }
                    setlog(result.ToArray(), rS);
                }
                return result.ToArray();
            }
            catch (Exception e)
            {
                log.Add(e.Message + "\n" + e.StackTrace);
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
                return null;
            }
        }
        //для RS5
        byte[] sumModRC5(byte[] x, byte[] y, int size)
        {
            try
            {
                string a = "";
                string b = "";
                string c = "";
                //string[] z = new string[x.Length];
                for (int i = 0; i < x.Length; i++)
                    a += eightnaryNumber(tenToSS(Convert.ToInt32(x[i]), 2));
                for (int i = 0; i < y.Length; i++)
                    b += eightnaryNumber(tenToSS(Convert.ToInt32(y[i]), 2));

                c = binAdd(a, b);

                List<byte> result = new List<byte>();
                if (size != 2)
                {
                    setlog(x, a);
                    log.Add("+ mod 2^" + size);
                    setlog(y, b);
                    log.Add("=");
                    string resultS = c;
                    string str = c;
                    char[] chars = str.ToCharArray();
                    string rS = new string(chars);
                    while (resultS.Length < size)
                        resultS = "0" + resultS;
                    while (resultS.Length > size)
                        resultS = resultS.Remove(0, 1);
                    if (x.Length <= y.Length)
                        for (int i = 0; i < x.Length; i++)
                        {
                            string s = resultS.Substring(resultS.Length - i * 8 - 8, 8);
                            result.Add(Convert.ToByte(conv2to10(s)));
                        }
                    else
                        for (int i = 0; i < y.Length; i++)
                        {
                            string s = resultS.Substring(resultS.Length - i * 8 - 8, 8);
                            result.Add(Convert.ToByte(conv2to10(s)));
                        }
                    result.Reverse();
                    setlog(result.ToArray(), rS);
                }
                else if (size == 2)
                {
                    setlog(x, a);
                    log.Add("+ mod 2");
                    setlog(y, b);
                    log.Add("=");
                    string resultS = "";
                    if (a.Length >= b.Length)
                    {
                        int count = a.Length - b.Length;
                        for (int i = b.Length - 1; i >= 0; i--)
                            if (a[i + count] == '1' && b[i] == '1')
                                resultS = "0" + resultS;
                            else if (a[i + count] == '1' && b[i] == '0')
                                resultS = "1" + resultS;
                            else if (a[i + count] == '0' && b[i] == '1')
                                resultS = "1" + resultS;
                            else if (a[i + count] == '0' && b[i] == '0')
                                resultS = "0" + resultS;
                        for (int i = 0; i < count; i++)
                            if (a[i] == '1')
                                resultS = "1" + resultS;
                            else
                                resultS = "0" + resultS;
                    }
                    else
                    {
                        int count = b.Length - a.Length;
                        for (int i = a.Length - 1; i >= 0; i--)
                            if (a[i] == '1' && b[i + count] == '1')
                                resultS = "0" + resultS;
                            else if (a[i] == '1' && b[i + count] == '0')
                                resultS = "1" + resultS;
                            else if (a[i] == '0' && b[i + count] == '1')
                                resultS = "1" + resultS;
                            else if (a[i] == '0' && b[i + count] == '0')
                                resultS = "0" + resultS;
                        for (int i = count - 1; i >= 0; i--)
                            if (b[i] == '1')
                                resultS = "1" + resultS;
                            else
                                resultS = "0" + resultS;
                    }
                    string str = resultS;
                    char[] chars = str.ToCharArray();
                    string rS = new string(chars);
                    //while (resultS.Length < 32)
                        //resultS = "0" + resultS;
                    for (int i = 0; i < x.Length; i++)
                    {
                        string s = resultS.Substring(i * 8, 8);
                        result.Add(Convert.ToByte(conv2to10(s)));
                    }
                    setlog(result.ToArray(), rS);
                }
                return result.ToArray();
            }
            catch (Exception e)
            {
                log.Add(e.Message + "\n" + e.StackTrace);
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
                return null;
            }
        }
        //сложение двух бинарных чисел
        string binAdd(string aS, string bS)
        {
            while (aS.Length > bS.Length)
                bS = "0" + bS;
            while (aS.Length < bS.Length)
                aS = "0" + aS;
            char[] a = aS.ToCharArray();
            char[] b = bS.ToCharArray();
            int carry = 0;
            int d = 0;
            string s = "";
            for (int i = a.Length - 1; i >= 0; i--)
            {
                d = (Encoding.Default.GetBytes(a[i].ToString())[0] - Encoding.Default.GetBytes("0")[0])
                    + (Encoding.Default.GetBytes(b[i].ToString())[0] - Encoding.Default.GetBytes("0")[0]) + carry;
                carry = d / 2;
                d = d % 2;
                byte[] bb = {Convert.ToByte(d + Encoding.Default.GetBytes("0")[0])};
                s = Encoding.Default.GetString(bb) + s;
            }
            if (carry != 0)
                s = '1' + s;
            return s;
        }

        //вычитание двух бинарных чисел
        string binDif(string aS, string bS)
        {
            while (aS.Length > bS.Length)
                bS = "0" + bS;
            while (aS.Length < bS.Length)
                aS = "0" + aS;
            char[] a = aS.ToCharArray();
            char[] b = bS.ToCharArray(); 
            int j = 0;
            string s = "";
            for (int i = a.Length - 1; i >= 0; i--)
            {
                switch (a[i])
                {
                    case '0': {
                        if (b[i] == '0')
                        {
                            s = 0 + s;
                        }
                        else if (b[i] == '1')
                        {
                            s = 1 + s;
                            if (a[i - 1] == '1') 
                                a[i - 1] = '0';
                            else 
                            {
                               j = 1;
                               while ((i - j > 0) && (a[i - j] == '0')) 
                               {
                                     a[i - j] = '1';
                                     j++;
                               }
                               a[i - j] = '0';
                            }
                        }
                    }
                        break;
                    case '1':
                        {
                            if (b[i] == '0')
                            {
                                s = 1 + s;
                            }
                            else if (b[i] == '1')
                            {
                                s = 0 + s;
                            }
                        }
                        break;
                }
            }
            return s;
        }

        //для RS5 (из a вычитаем b)
        byte[] difModRC5(byte[] x, byte[] y, int size)
        {
            try
            {
                string a = "";
                string b = "";
                string c = "";
                for (int i = 0; i < x.Length; i++)
                    a += eightnaryNumber(tenToSS(Convert.ToInt32(x[i]), 2));
                for (int i = 0; i < y.Length; i++)
                    b += eightnaryNumber(tenToSS(Convert.ToInt32(y[i]), 2));
                c = binDif(a, b);
                List<byte> result = new List<byte>();
                if (size != 2)
                {
                    setlog(x, a);
                    log.Add("- mod 2^" + size);
                    setlog(y, b);
                    log.Add("=");
                    string resultS = c;
                    int ii = resultS.Length;
                    string str = resultS;
                    char[] chars = str.ToCharArray();
                    string rS = new string(chars);
                    while (resultS.Length < size)
                        resultS = "0" + resultS;
                    //while (resultS.Length > size)
                        //resultS = resultS.Remove(0, 1);
                    if (x.Length <= y.Length)
                        for (int i = 0; i < x.Length; i++)
                        {
                            string s = resultS.Substring(resultS.Length - i * 8 - 8, 8);
                            result.Add(Convert.ToByte(conv2to10(s)));
                        }
                    else
                        for (int i = 0; i < y.Length; i++)
                        {
                            string s = resultS.Substring(resultS.Length - i * 8 - 8, 8);
                            result.Add(Convert.ToByte(conv2to10(s)));
                        }
                    result.Reverse();
                    setlog(result.ToArray(), rS);
                }
                return result.ToArray();
            }
            catch (Exception e)
            {
                log.Add(e.Message + "\n" + e.StackTrace);
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        //подстановка в соответствии с таблицами подстановок
        byte[] replace(byte[] bytes, byte[] key, string type)
        {
            log.Add("Начало подстановки...");
            int countMove = 0;
            for (int i = 0; i < key.Length; i++)
                countMove += key[i];
            //формируем прямой массив всевозможных символов
            byte[] arr = new byte[256];
            for (int i = 0; i < 256; i++)
                arr[i] = Convert.ToByte(i);
            //сдвинутый массив 
            byte[] arrModif; 
            //учитывай, что при сдвиге на длину массива, результирующий массив не изменится! 
            if (countMove % 2 == 0)
            { arrModif = moveLeft(arr, 2 + IMPORTANT_NUMBER); }
            else if (countMove % 3 == 0)
            { arrModif = moveLeft(arr, 3 + IMPORTANT_NUMBER); }
            else if (countMove % 5 == 0)
            { arrModif = moveLeft(arr, 5 + IMPORTANT_NUMBER); }
            else if (countMove % 7 == 0)
            { arrModif = moveLeft(arr, 7 + IMPORTANT_NUMBER); }
            else if (countMove % 11 == 0)
            { arrModif = moveLeft(arr, 11 + IMPORTANT_NUMBER); }
            else if (countMove % 13 == 0)
            { arrModif = moveLeft(arr, 13 + IMPORTANT_NUMBER); }
            else
            { arrModif = moveLeft(arr, IMPORTANT_NUMBER); }
            setlog(arrModif, "Массив замен");
            //получилось соответствие между символами прямого и сдвинутого массивов
            if (type.Equals("encrypt"))
                return tableReplace(arr, arrModif, bytes);
            return tableReplace(arrModif, arr, bytes);
        }

        //подставляет значения b2 в b1
        byte[] tableReplace(byte[] b1, byte[] b2, byte[] replaceable)
        {
            byte[] result = new byte[replaceable.Length];
            int[] indexes = new int[replaceable.Length];
            int k = 0;
            for (int i = 0; i < b1.Length; i++)
                for (int j = 0; j < replaceable.Length; j++)
                    if (replaceable[j].Equals(b1[i]))
                    {       
                        indexes[k] = i;
                        k++;
                    }
            for (int i = 0; i < indexes.Length; i++)
            {
                
                result[i] = b2[i];
            }

            return result;
        }

        //операции табличных подстановок в 4 байтовых подблоках 
        byte[] replace(byte[] bytes, byte[] key, string type, int empty)
        {
            try
            {
                List<byte[]> result = new List<byte[]>();
                byte[,] sqr = getSqrVigenere(0);//generateChangedSqrVigenere(enru.ToList());
                if (type.Equals("encrypt"))
                    result.Add(replaceBlockEncrypt(bytes, sqr, key));
                else
                    result.Add(replaceBlockDecrypt(bytes, sqr, key));
            
                //получаем 8 частей, для каждой из которых применим подстановку
                //for (int i = 0; i < bytes.Length; i++)
                //{
                //    string s = tenToSS(Convert.ToInt32(bytes[i]), 2);
                //    byte[] sub = new byte[2];
                //    sub[0] = Convert.ToByte(conv2to10(getMySubStr(s, 0, 4)));
                //    sub[1] = Convert.ToByte(conv2to10(getMySubStr(s, 1, 4)));
                //    result.Add(sub);
                //}
                //List<byte[]> resultOut = new List<byte[]>();
                //всего подключей 8, как и частей для подстановок
                //for (int i = 0; i < result.Count; i++)
                //{
                //    //char[] arr = moveArray(Convert.ToChar(keys[i][0]));
                //    //char[,] sqr = generateChangedSqrVigenere(arr.ToList());
                //    char[,] sqr = generateChangedSqrVigenere(enru.ToList());
                //    byte[] replacedSubBlock = replaceBlock(bytes[i], sqr, key);
                //    result.Add(replacedSubBlock);
                //}
                byte[] arr_result = new byte[4];
                int k = 0;
                for (int i = 0; i < result.Count; i++)
                    for (int j = 0; j < result[i].Length; j++)
                    {
                        arr_result[k] = result[i][j];
                        k++;
                    }
                return arr_result;
            }
            catch (Exception e)
            {
                log.Add(e.Message + "\n" + e.StackTrace);
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        byte[] replaceBlockEncrypt(byte[] replaceableBlock, byte[,] sqrV, byte[] key)
        {
            try
            {
                log.Add("Заменяем"); // сверху исходный текст, слева ключ
                //т.е. в нулевой строке таблицы ищем соотвествие символу исходного теста
                //а в нулевом столбце - символу ключа
                byte[] replacingBlock = new byte[replaceableBlock.Length];
                int index = 0;
                //string keyS = encoding.GetString(key);
                //string mes = encoding.GetString(replaceableBlock);
                bool exit = false;
                for (int k = 0; k < replaceableBlock.Length; k++)
                {
                    for (int i = 0; i < sqrV.GetLength(0); i++)
                    {
                        if (sqrV[i, 0].Equals(key[k]))
                            for (int j = 0; j < sqrV.GetLength(1); j++)
                            {
                                byte bbbb = sqrV[i, 0];
                                if (sqrV[0, j].Equals(replaceableBlock[k]))
                                {
                                    byte bbbbb = sqrV[0, j];
                                    if (index < replacingBlock.Length)
                                    {
                                        byte b = sqrV[i, j];
                                        StringBuilder sb = new StringBuilder();
                                        byte[] b1 = new byte[1];
                                        b1[0] = sqrV[i, 0];
                                        byte[] b2 = new byte[1];
                                        b2[0] = sqrV[0, j];
                                        byte[] b3 = new byte[1];
                                        b3[0] = sqrV[i, j];
                                        sb.AppendFormat("Символ ключа sqrV[" + i.ToString() + ", " + 0.ToString() + "] = {0}, символ исходного текста sqrV[" + 0.ToString() + ", " + j.ToString() + "] = {1}, символ шифр-текста sqrV[" + i.ToString() + ", " + j.ToString() + "] = {2}", Encoding.Default.GetString(b1), Encoding.Default.GetString(b2), Encoding.Default.GetString(b3));
                                        log.Add(sb.ToString());
                                        replacingBlock[index] = b;
                                        index++;
                                        exit = true;
                                    }
                                }
                                if (exit)
                                    break;
                            }
                        if (exit)
                            break;
                    }
                    exit = false;
                }
                return replacingBlock;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        byte[] replaceBlockDecrypt(byte[] replaceableBlock, byte[,] sqrV, byte[] key)
        {
            try
            {
                byte[] replacingBlock = new byte[replaceableBlock.Length];
                int index = 0;
                //string keyS = encoding.GetString(key);
                //string mes = encoding.GetString(replaceableBlock);
                bool exit = false;
                for (int k = 0; k < replaceableBlock.Length; k++)
                {
                    for (int i = 0; i < sqrV.GetLength(0); i++)
                    {
                        if (sqrV[i, 0].Equals(key[k]))
                            for (int j = 0; j < sqrV.GetLength(1); j++)
                            {
                                byte bbbb = sqrV[i, 0];
                                if (sqrV[i, j].Equals(replaceableBlock[k]))
                                {
                                    byte bbbbb = sqrV[i, j];
                                    if (index < replacingBlock.Length)
                                    {
                                        byte b = sqrV[0, j];
                                        replacingBlock[index] = b;
                                        StringBuilder sb = new StringBuilder();
                                        byte[] b1 = new byte[1];
                                        b1[0] = sqrV[i, 0];
                                        byte[] b2 = new byte[1];
                                        b2[0] = sqrV[0, j];
                                        byte[] b3 = new byte[1];
                                        b3[0] = sqrV[i, j];
                                        sb.AppendFormat("Символ ключа sqrV[" + i.ToString() + ", " + 0.ToString() + "] = {0}, символ исходного текста sqrV[" + 0.ToString() + ", " + j.ToString() + "] = {1}, символ шифр-текста sqrV[" + i.ToString() + ", " + j.ToString() + "] = {2}", Encoding.Default.GetString(b1), Encoding.Default.GetString(b3), Encoding.Default.GetString(b2));
                                        log.Add(sb.ToString());
                                        index++;
                                        exit = true;
                                    }
                                }
                                if (exit)
                                    break;
                            }
                        if (exit)
                            break;
                    }
                    exit = false;
                }
                return replacingBlock;
            }
            catch (Exception e)
            {
                log.Add(e.Message + "\n" + e.StackTrace);
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        //сдвигает массив влево так, чтобы первая буква начиналась с заданной 
        char[] moveArray(char b) 
        {
            try
            {
                char[] result = new char[enru.Length];
                bool notExist = true;
                for (int i = 0; i < enru.Length; i++)
                {
                    if (enru[i] == b)
                    {
                        notExist = false;
                        char[] left = enru.Take(i - 1).ToArray();
                        int k = 0;
                        for (int j = i; j < enru.Length; j++)
                        {
                            if (k >= result.Length)
                                break;
                            result[k] = enru[j];
                            k++;
                        }
                        foreach (char c in left)
                        {
                            if (k >= result.Length)
                                break;
                            result[k] = c;
                            k++;
                        }
                    }
                }
                if (notExist)
                    return enru;
                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        //сдвигает элементы массива на указанное количество элементов влево
        byte[] moveLeft(byte[] a, int count)
        {
            int i = 0;
            while (i != count - 1)
            {
                byte b1 = a[0];
                for (int j = 0; j < a.Length; j++)
                {
                    if (j == a.Length - 1)
                        a[j] = b1;
                    else
                        a[j] = a[j + 1]; 
                }
                i++;
            }
            return a;
        }

        byte[] moveRight(byte[] a, int count)
        {
            int i = 0;
            while (i != count - 1)
            {
                byte b1 = a[a.Length - 1];
                for (int j = a.Length - 2; j >= 0; j--)
                    a[j + 1] = a[j];
                a[0] = b1;
                i++;
            }
            return a;
        }

        string moveLeft(char[] a, int count)
        {
            int i = 0;
            while (i != count - 1)
            {
                char b1 = a[0];
                for (int j = 0; j < a.Length; j++)
                {
                    if (j == a.Length - 1)
                        a[j] = b1;
                    else
                        a[j] = a[j + 1];
                }
                i++;
            }
            string s = "";
            foreach (char c in a)
                s += c;
            return s;
        }



        //выводит сообщение во всех кодировках
        string writeInAllEncodings(string message)
        {
            string result = "";
            foreach (EncodingInfo ei in Encoding.GetEncodings())
            {
                Encoding e = ei.GetEncoding();
                byte[] b = e.GetBytes(message);
                result += "\n" + e.EncodingName + "/n" + e.GetString(b);
            }
            return result;
        }

        //всегда возвращает число из трех знаков
        string threenaryNumber(byte b)
        {
            string s = b.ToString();
            if (s.Length == 1)
                return "00" + s;
            else if (s.Length == 2)
                return "0" + s;
            return s;
        }

        string eightnaryNumber(string s)
        {
            if (s.Length == 0)
                return "00000000" + s;
            else if (s.Length == 1)
                return "0000000" + s;
            else if (s.Length == 2)
                return "000000" + s;
            else if (s.Length == 3)
                return "00000" + s;
            else if (s.Length == 4)
                return "0000" + s;
            else if (s.Length == 5)
                return "000" + s;
            else if (s.Length == 6)
                return "00" + s;
            else if (s.Length == 7)
                return "0" + s;
            return s;
        }

        //записывает массив в лог со следующим заголовком
        void setlog(byte[] b, string caption)
        {
            string s = "";
            foreach (byte bb in b)
            {
                byte[] byt = new byte[1];
                byt[0] = bb;
                s += bb.ToString() + "(" + Encoding.Default.GetString(byt) + ") ";
            }
            if (caption != "")
                log.Add(caption + ": " + s);
            else
                log.Add(s);
        }

        void setlog(byte[] b, List<byte[]> l)
        {
            l.Add(b);
        }

        //шифрует текст 
        void encrypt(string message, bool showMessages)
        {
            try
            {
                MESSAGE = message;
                //ResultTextHash.Clear();
                string enc = "";
                if (comboBoxEncType.Text.Equals(encTypes[0]))
                {
                    setDefaultTextList(message);
                    //исходный текст - столбец, ключ - строка
                    for (int k = 0; k < defaultText.Count; k++)
                        for (int i = 0; i < sqrVigenere.GetLength(0); i++)
                        {
                            if (sqrVigenere[i, 0].Equals(Char.ToUpper(keyDefText[k])))
                            {
                                for (int j = 0; j < sqrVigenere.GetLength(1); j++)
                                    if (sqrVigenere[i, j].Equals(Char.ToUpper(defaultText[k])))
                                    {
                                        //ResultTextHash.Add(keyDefText[k].ToString() + defaultText[k].ToString(), getChar(keyDefText[k], defaultText[k]));
                                        enc += getChar(keyDefText[k], defaultText[k]);
                                    }
                            }
                        }
                    string str = "\n[" + message + "] зашифровано в [" + enc + "]";
                    if (showMessages) 
                        richTextBox.Text += str;
                }
                else if (comboBoxEncType.Text.Equals(encTypes[1]))
                {
                    log.Add("#");
                    log.Add("Получено шифруемое сообщение: " + message);
                    log.Add("Получен ключ: " + KEY);
                    //перевели строку в массив байтов
                    byte[] message_byte = Encoding.Default.GetBytes(message);
                    //log.Add("Результат конвертации сообщения в байты: " + convertArrayToString(message_byte));
                    setlog(message_byte, "Результат конвертации сообщения в байты");
                    //разбить сообщение на блоки по 64 бита
                    //List<string> allBlocks = getAllBlocks(64, message);
                    List<byte[]> allBlocks = getAllBlocks(64, 8, message_byte);
                    log.Add("Сообщение разбито на 64-битовые подблоки:");
                    for (int m = 0; m < allBlocks.Count; m++)
                        setlog(allBlocks[m], m.ToString() + "-й подблок");
                    //сгенерировать 256 битный секретный ключ, состоящий из 8-и 32 битных подключей
                    byte[] key = Encoding.Default.GetBytes(KEY);
                    setlog(key, "Результат конвертации ключа в байты");
                    //log.Add("Результат конвертации ключа в байты: " + convertArrayToString(key));
                    if (key.Length != 32)
                    {
                        KEY = lengthString(32, KEY);
                        key = Encoding.Default.GetBytes(KEY);
                        if (showMessages)
                        {
                            StringBuilder sb = new StringBuilder();
                            string skey = Encoding.Default.GetString(key);
                            sb.AppendFormat("Величина ключа (KEY = {0}) не соответствует требуемой величине в 256 бит (32 символа). \n Будет использован сгенерированный ключ: {1}", KEY.Length, skey);
                            sb.AppendLine();
                            MessageBox.Show(sb.ToString());
                        }
                    }
                    List<byte[]> Q = splitKeys(key, 4);
                    log.Add("Ключ разбит на 8 32-битовых подключей:");
                    for (int m = 0; m < Q.Count; m++)
                        setlog(Q[m], m.ToString() + "-й подключ");
                    int i = 0;
                    int j = 0;
                    //пройтись циклом по всем блокам, используя алгоритм шифрования
                    for (int k = 0; k < allBlocks.Count; k++)
                    {
                        i = 1;
                        byte[] V;
                        byte[] R = subBlock(allBlocks[k], "right");
                        byte[] L = subBlock(allBlocks[k], "left");
                        setlog(R, before);
                        setlog(L, before);
                        setlog(R, "R");
                        setlog(L, "L");
                        while (i < 32)
                        {
                            log.Add("  i = " + i.ToString());
                            V = new byte[4];
                            for (int ii = 0; ii < V.Length; ii++)
                                V[ii] = R[ii];
                            j = i < 25 ? (i - 1) % 8 : (32 - i) % 8;
                            if (checkBox1.Checked)
                            {
                                R = sumMod(R, Q[j], 32);
                                setlog(R, "Операция суммирования по модулю 2 в 32 подблока R  " + k.ToString() + "-го подблока и " + j.ToString() + "-го подключа");
                            }
                            if (checkBox2.Checked)
                            {
                                R = replace(R, Q[j], "encrypt");
                                setlog(R, "Операция замены подблока R " + k.ToString() + "-го подблока  и " + j.ToString() + "-го подключа");
                            }
                            if (checkBox3.Checked)
                            {
                                R = moveLeft(R, 11);
                                setlog(R, "Операция сдвига на 11 влево подблока R " + k.ToString() + "-го подблока ");
                            }
                            if (checkBox4.Checked)
                            {
                                R = sumMod(R, L, 2);
                                setlog(R, "Операция суммирования по модулю 2 подблоков R и L " + k.ToString() + "-го подблока ");
                            }
                            for (int ii = 0; ii < L.Length; ii++)
                                L[ii] = V[ii];
                            i++;
                        }
                        log.Add("Левый подблок " + k.ToString() + "-го подблока зашифрован в:" + convertArrayToString(L));
                        foreach (byte b in L)
                            enc += threenaryNumber(b);
                        log.Add("Правый подблок " + k.ToString() + "-го подблока зашифрован в:" + convertArrayToString(R));
                        foreach (byte b in R)
                            enc += threenaryNumber(b);
                    }
                    log.Add("Сообщение зашифровано в:" + enc);
                    if (showMessages)
                        richTextBox.Text += "\n[" + message + "] зашифровано в [" + enc + "]";
                }
                else if (comboBoxEncType.Text.Equals(encTypes[2]))
                {
                    List<byte> list = Encoding.Default.GetBytes(message).ToList();
                    byte[] message_byte = list.ToArray();
                    int W = Convert.ToInt32(comboBoxW.Text);
                    int R = Convert.ToInt32(textBoxR.Text);
                    int b = Convert.ToInt32(textBoxL.Text);
                    if (W != 32 && showMessages) { MessageBox.Show("Данная версия продукта поддерживает пока только 32-битовые блоки шифрования.", "Ой-ёй!"); }
                    else
                    {
                        log.Add("Шифрование RC5 - " + W + "/" + R + "/" + b);
                        setlog(message_byte, "Сообщение разбито на байты");
                        List<byte[]> allBlocks = getAllBlocks(W, W / 8, message_byte);
                        log.Add("Сообщение разбито на 64-битовые подблоки:");
                        for (int m = 0; m < allBlocks.Count; m++)
                            setlog(allBlocks[m], m.ToString() + "-й подблок");
                        byte[] key = Encoding.Default.GetBytes(KEY);
                        setlog(key, "Результат конвертации ключа в байты");
                        if (key.Length != b)
                        {
                            KEY = lengthString(b, KEY);
                            key = Encoding.Default.GetBytes(KEY);
                            if (showMessages)
                            {
                                StringBuilder sb = new StringBuilder();
                                string skey = Encoding.Default.GetString(key);
                                sb.AppendFormat("Величина ключа (KEY = {0}) не соответствует требуемой величине в {2} байт(-а). \n Будет использован сгенерированный ключ: {1}", KEY.Length, skey, b);
                                sb.AppendLine();
                                MessageBox.Show(sb.ToString());
                            }
                        }
                        string[] Q = magicGenerator(key, W, R, b);
                        log.Add("Ключи: ");
                        string ss = "";
                        foreach (string s in Q)
                            ss += s + " ";
                        log.Add(ss);
                        for (int k = 0; k < allBlocks.Count; k++)
                        {
                            byte[] A = subBlock(allBlocks[k], "left");
                            setlog(A, "Левый подблок");
                            byte[] B = subBlock(allBlocks[k], "right");
                            setlog(B, "Правый подблок");
                            A = sumModRC5(A, Encoding.Default.GetBytes(Q[0]), W);
                            setlog(A, "Сложение с нулевым ключом подблока А");
                            B = sumModRC5(B, Encoding.Default.GetBytes(Q[1]), W);
                            setlog(B, "Сложение с первым ключом подблока B");
                            for (int i = 0; i < R; i++)
                            {
                                if (checkBox5.Checked)
                                { A = sumModRC5(A, B, 2); setlog(A, "Суммирование по модулю 2"); }
                                if (checkBox6.Checked)
                                { A = moveLeft(A, lightSum(B)); setlog(A, "Смещение влево на " + lightSum(B)); }
                                if (checkBox7.Checked)
                                { A = sumModRC5(A, Encoding.Default.GetBytes(Q[2 * i]), W); setlog(A, "Суммирование по модулю " + W); }
                                if (checkBox5.Checked)
                                { B = sumModRC5(B, A, 2); setlog(B, "Суммирование по модулю 2"); }
                                if (checkBox6.Checked)
                                { B = moveLeft(B, lightSum(A)); setlog(B, "Смещение влево на " + lightSum(A)); }
                                if (checkBox7.Checked)
                                { B = sumModRC5(B, Encoding.Default.GetBytes(Q[2 * i + 1]), W); setlog(B, "Суммирование по модулю " + W); }
                            }
                            log.Add("Левый подблок " + k.ToString() + "-го подблока зашифрован в:" + convertArrayToString(A));
                            foreach (byte by in A)
                                enc += threenaryNumber(by);
                            log.Add("Правый подблок " + k.ToString() + "-го подблока зашифрован в:" + convertArrayToString(B));
                            foreach (byte by in B)
                                enc += threenaryNumber(by);
                        }
                        log.Add("Сообщение зашифровано в:" + enc);
                        if (showMessages)
                            richTextBox.Text += "\n[" + message + "] зашифровано в [" + enc + "]";
                    }
                }
                ENCRYPT = enc;
            }
            catch (Exception e)
            {
                log.Add(e.Message + "\n" + e.StackTrace);
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
            }
        }

        int lightSum(byte[] b)
        {
            int res = 0;
            foreach (byte p in b)
                res += Convert.ToInt16(p);
            return res;
        }

        string[] magicGenerator(byte[] k, int W, int R, int b)
        {
            //string p16 = "b7e1";
            //string q16 = "9e37";
            //string p32 = "b7e15163";
            //string q32 = "9e3779b9";
            //string p64 = "b7e151628aed2a6b";
            //string q64 = "9e3779b97f4a7c15";
            //генерация констант
            string p = "";
            string q = "";
            switch (comboBoxW.Text)
            {
                case "16": 
                    { 
                        p = "b7e1";
                        q = "9e37";
                    }
                    break;
                case "32": 
                    { 
                        p = "b7e15163";
                        q = "9e3779b9";
                    }
                    break;
                case "64": 
                    { 
                        p = "b7e151628aed2a6b";
                        q = "9e3779b97f4a7c15";
                    }
                    break;
            }
            //разбиение ключа на слова
            int count_bytes_in_word = W / 8;
            int c = b / count_bytes_in_word;
            while (c % count_bytes_in_word != 0)
            {
                c++;
            }
            string[] L = new string[c];
            if (b == 0 && c == 0)
            {
                L = new string[1];
                c = 1;
                L[0] = "0";
            }
            else
            {
                string s = "";
                int i = 0;
                int len = 0;
                for (int j = 0; j < k.Length; j++ )
                {
                    if (len % count_bytes_in_word == 0 && len != 0)
                    {
                        if (i < c)
                        {    
                            L[i] = s;
                            i++;
                            byte[] by = { k[j] };
                            s = Encoding.Default.GetString(by); 
                        }
                        else
                            break;
                    }
                    else
                    {
                        byte[] by = { k[j] };
                        s += Encoding.Default.GetString(by); 
                    }
                    len++;
                    if (j == k.Length - 1)
                        if (len % count_bytes_in_word == 0 && len != 0)
                            if (i < c)
                            {
                                L[i] = s;
                                i++;
                                byte[] by = { k[j] };
                                s = Encoding.Default.GetString(by);
                            }
                }
            }
            //построение таблицы расширенных ключей
            string[] S = new string[2 * (R + 1)];
            S[0] = p;
            for (int i = 1; i < S.Length; i++)
            {
                S[i] = binSum(S[i - 1], q, 16, W);
            }
            //перемешивание
            string G = "0";
            string H = "0";
            int N = 0;
            if (3 * c > 6 * (R + 1))
                N = 3 * c;
            else
                N = 6 * (R + 1);
            
            for (int m = 0; m < N; m++)
            {
                for (int i = 0; i < S.Length; i++)
                {
                    i = (i + 1) % (2 * (R + 1));
                    string s = binSum(Convert.ToString(binSum(S[i], G, 16, W)), H, 16, W);
                    char[] chars = new char[s.Length];
                    for(int ii = 0; ii < s.Length; ii++)
                        chars[ii] = s[ii];
                    G = S[i] = moveLeft(chars, 3);
                }
                for (int j = 0; j < L.Length; j++)
                {
                    j = (j + 1) % c;
                    string s = binSum(Convert.ToString(binSum(L[j], G, 16, W)), H, 16, W);
                    char[] chars = new char[s.Length];
                    for(int jj = 0; jj < s.Length; jj++)
                        chars[jj] = s[jj];
                    //long inta = Convert.ToInt64("0x" + G, 16);
                    //long intb = Convert.ToInt64("0x" + H, 16);
                    //string ss = (inta + intb).ToString();
                    H = L[j] = moveLeft(chars, 11);
                }

            }
            return S;
        }

        string getStrBytes(string s)
        {
            string str = "";
            byte[] b = Encoding.Default.GetBytes(s);
            foreach (byte c in b)
            {
                str += c.ToString();
            }
            return str;
        }

        //переводит строку, содержащую коды байт в байты
        byte[] getBytes(string s)
        {
            while (s.Length % 3 != 0)
                s += '0';
            List<byte> bytes = new List<byte>();
            string b = "";
            if (s.Length != 0)
                b += s[0];
            for (int i = 1; i < s.Length; i++)
            {
                if (i % 3 != 0)
                    b += s[i];
                else 
                {
                    if (Convert.ToInt16(b) > 255)
                        bytes.Add(245);
                    else
                        bytes.Add(Convert.ToByte(b));
                    b = "";
                    b += s[i];
                }
                if (i == s.Length - 1)
                    if (Convert.ToInt16(b) > 255)
                        bytes.Add(245);
                    else
                        bytes.Add(Convert.ToByte(b));
            }
            return bytes.ToArray();
        }

        //дешифрует полученный текст в соответствии с ключом
        void decrypt(string enc, bool showMessages)
        {
            try
            {
                setDefaultTextList(enc);
                string decr = "";
                if (comboBoxEncType.Text.Equals(encTypes[0]))
                {
                    for (int k = 0; k < keyDefText.Count; k++)
                        for (int i = 0; i < sqrVigenere.GetLength(0); i++)
                            if (sqrVigenere[i, 0].Equals(Char.ToUpper(keyDefText[k])))
                            {
                                for (int j = 0; j < sqrVigenere.GetLength(1); j++)
                                    if (sqrVigenere[i, j].Equals(Char.ToUpper(enc[k])))
                                    {
                                        decr += sqrVigenere[0, j];
                                        break;
                                    }
                                break;
                            }

                }
                else if (comboBoxEncType.Text.Equals(encTypes[1]))
                {
                    log.Add("#");
                    log.Add("Получен шифр-текст: " + enc);
                    log.Add("Получен ключ: " + KEY);
                    //перевели строку в массив байтов
                    byte[] message_byte = getBytes(enc);
                    //log.Add("Результат конвертации шифр-текста в байты: " + convertArrayToString(message_byte));
                    setlog(message_byte, "Результат конвертации шифр-текста в байты");
                    //кодировка будет Windows кириллица (1251), где один символ = 8 битам 
                    //MessageBox.Show(Encoding.Default.GetString(message_byte));
                    //разбить сообщение на блоки по 64 бита
                    //List<string> allBlocks = getAllBlocks(64, message);
                    List<byte[]> allBlocks = getAllBlocks(64, 8, message_byte);
                    log.Add("Шифр-текст разбит на 64-битовые подблоки:");
                    for (int m = 0; m < allBlocks.Count; m++)
                        setlog(allBlocks[m], m.ToString() + "-й подблок");
                        //log.Add(m.ToString() + "-й подблок:" + convertArrayToString(allBlocks[m]));
                    //MessageBox.Show(Encoding.Default.GetString(message_byte));
                    //сгенерировать 256 битный секретный ключ, состоящий из 8-и 32 битных подключей
                    //string[] key = new string[8];
                    byte[] key = Encoding.Default.GetBytes(KEY);
                    setlog(key, "Результат конвертации ключа в байты");
                    //log.Add("Результат конвертации ключа в байты: " + convertArrayToString(key));
                    if (key.Length != 32)
                    {
                        KEY = lengthString(32, KEY);
                        key = Encoding.Default.GetBytes(KEY);
                        if (showMessages)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendFormat("Величина ключа (KEY = {0}) не соответствует требуемой величине в 256 бит (32 символа). \n Будет использован сгенерированный ключ: {1}", KEY.Length, key);
                            sb.AppendLine();
                            MessageBox.Show(sb.ToString());
                        }
                    }
                    List<byte[]> Q = splitKeys(key, 4);
                    log.Add("Ключ разбит на 8 32-битовых подключей:");
                    for (int m = 0; m < Q.Count; m++)
                        setlog(Q[m], m.ToString() + "-й подключ");
                        //log.Add(m.ToString() + "-й подключ:" + convertArrayToString(Q[m]));
                    int i = 0;
                    int j = 0;
                    //пройтись циклом по всем блокам, используя алгоритм шифрования
                    for (int k = 0; k < allBlocks.Count; k++)
                    {
                        i = 1;
                        byte[] V;
                        byte[] R = subBlock(allBlocks[k], "right");
                        byte[] L = subBlock(allBlocks[k], "left");
                        setlog(R, "R");
                        setlog(L, "L");
                        while (i < 32)
                        {
                            log.Add("  i = " + i.ToString());
                            V = new byte[4];
                            for (int ii = 0; ii < V.Length; ii++)
                                V[ii] = L[ii];
                            j = i <= 8 ? (i - 1) % 8 : (32 - i) % 8;
                            if (checkBox1.Checked)
                            {
                                L = sumMod(L, Q[j], 32);
                                setlog(L, "Операция суммирования по модулю 2 в 32 подблока L и " + j.ToString() + "-го подключа");
                            }
                            if (checkBox2.Checked)
                            {
                                L = replace(L, Q[j], "decrypt");
                                setlog(L, "Операция замены подблока L и " + j.ToString() + "-го подключа");
                            }
                            if (checkBox3.Checked)
                            {
                                L = moveLeft(L, 11);
                                setlog(L, "Операция сдвига на 11 влево подблока L");
                            }
                            if (checkBox4.Checked)
                            {
                                L = sumMod(R, L, 2);
                                setlog(L, "Операция суммирования по модулю 2 подблоков R и L");
                            }
                            for (int ii = 0; ii < R.Length; ii++)
                                R[ii] = V[ii];
                            i++;
                        }
                        setlog(R, after);
                        setlog(L, after);
                        log.Add("Левый подблок " + k.ToString() + "-го подблока расшифрован в:" + convertArrayToString(L));
                        foreach (byte b in L)
                        {
                            byte[] bA = new byte[1];
                            bA[0] = b;
                            decr += Encoding.Default.GetString(bA);
                        }
                        log.Add("Правый подблок " + k.ToString() + "-го подблока расшифрован в:" + convertArrayToString(R));
                        foreach (byte b in R)
                        {
                            byte[] bA = new byte[1];
                            bA[0] = b;
                            decr += Encoding.Default.GetString(bA);
                        }
                    }
                    
                }
                else if (comboBoxEncType.Text.Equals(encTypes[2]))
                {
                    byte[] message_byte = getBytes(enc);
                    int W = Convert.ToInt32(comboBoxW.Text);
                    int R = Convert.ToInt32(textBoxR.Text);
                    int b = Convert.ToInt32(textBoxL.Text);
                    if (W != 32 && showMessages) { MessageBox.Show("Данная версия продукта поддерживает пока только 32-битовые блоки шифрования.", "Ой-ёй!"); }
                    else
                    {
                        log.Add("Дешифрование RC5 - " + W + "/" + R + "/" + b);
                        setlog(message_byte, "Сообщение разбито на байты");
                        List<byte[]> allBlocks = getAllBlocks(W, W / 8, message_byte);
                        log.Add("Сообщение разбито на 64-битовые подблоки:");
                        for (int m = 0; m < allBlocks.Count; m++)
                            setlog(allBlocks[m], m.ToString() + "-й подблок");
                        byte[] key = Encoding.Default.GetBytes(KEY);
                        setlog(key, "Результат конвертации ключа в байты");
                        if (key.Length != b)
                        {
                            KEY = lengthString(b, KEY);
                            key = Encoding.Default.GetBytes(KEY);
                            if (showMessages)
                            {
                                StringBuilder sb = new StringBuilder();
                                string skey = Encoding.Default.GetString(key);
                                sb.AppendFormat("Величина ключа (KEY = {0}) не соответствует требуемой величине в {2} байт(-а). \n Будет использован сгенерированный ключ: {1}", KEY.Length, skey, b);
                                sb.AppendLine();
                                MessageBox.Show(sb.ToString());
                            }
                        }
                        string[] Q = magicGenerator(key, W, R, b);
                        log.Add("Ключи: ");
                        string ss = "";
                        foreach (string s in Q)
                            ss += s + " ";
                        log.Add(ss);
                        for (int k = 0; k < allBlocks.Count; k++)
                        {
                            byte[] A = subBlock(allBlocks[k], "left");
                            setlog(A, "Левый подблок");
                            byte[] B = subBlock(allBlocks[k], "right");
                            setlog(B, "Правый подблок");
                            for (int i = R - 1; i >= 0; i--)
                            {
                                if (checkBox7.Checked)
                                { B = difModRC5(B, Encoding.Default.GetBytes(Q[2 * i + 1]), W); setlog(B, "Разность по модулю " + W); }
                                if (checkBox6.Checked)
                                { B = moveRight(B, lightSum(A)); setlog(B, "Смещение вправо на " + lightSum(B)); }
                                if (checkBox5.Checked)
                                { B = sumModRC5(B, A, 2); setlog(B, "Суммирование по модулю 2"); }
                                if (checkBox7.Checked)
                                { A = difModRC5(A, Encoding.Default.GetBytes(Q[2 * i]), W); setlog(A, "Разность по модулю " + W); }
                                if (checkBox6.Checked)
                                { A = moveRight(A, lightSum(B)); setlog(A, "Смещение вправо на " + lightSum(B)); }
                                if (checkBox5.Checked)
                                { A = sumModRC5(A, B, 2); setlog(A, "Суммирование по модулю 2"); }
                            }
                            B = difModRC5(B, Encoding.Default.GetBytes(Q[1]), W);
                            setlog(B, "Разность с первым ключом подблока B");
                            A = difModRC5(A, Encoding.Default.GetBytes(Q[0]), W);
                            setlog(A, "Разность с нулевым ключом подблока А");
                            setlog(B, after);
                            setlog(A, after);
                            log.Add("Левый подблок " + k.ToString() + "-го подблока расшифрован в:" + convertArrayToString(A));
                            foreach (byte by in A)
                            {
                                byte[] bA = new byte[1];
                                bA[0] = by;
                                decr += Encoding.Default.GetString(bA);
                            }
                            log.Add("Правый подблок " + k.ToString() + "-го подблока расшифрован в:" + convertArrayToString(B));
                            foreach (byte by in B)
                            {
                                byte[] bA = new byte[1];
                                bA[0] = by;
                                decr += Encoding.Default.GetString(bA);
                            }
                        }
                    }
                }
                log.Add("Итог:");
                int num = 0;
                if (before.Count == after.Count)
                    for (int i = 0; i < before.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            setlog(before[i], "подблок R " + num.ToString() + "-го подблока " + "до");
                            setlog(after[i], "подблок R " + num.ToString() + "-го подблока " + "после");
                        }
                        else
                        {
                            setlog(before[i], "подблок L " + num.ToString() + "-го подблока " + "до");
                            setlog(after[i], "подблок L " + num.ToString() + "-го подблока " + "после");
                            num++;
                        }
                    }
                log.Add("Результат расшифровки: " + decr);
                if (showMessages)
                    richTextBox.Text += "\n[" + enc + "] дешифровано в [" + decr + "]";
                DECRYPT = decr;
            }
            catch (Exception e)
            {
                log.Add(e.Message + "\n" + e.StackTrace);
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
            }
        }

        private void buttonDec_Click(object sender, EventArgs e)
        {
            decrypt(richTextBox.Text, true);
        }

        private void ключToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(KEY, "Сгенерированный ключ: ");
        }

        private void сгенерироватьКлючToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KEY = generateKey(32); 
        }

        private void изменитьКлючToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            toolStripTextBoxKey.Text = KEY;
        }

        private void изменитьКлючToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            KEY = toolStripTextBoxKey.Text;
        }

        string showSqrViginere(char[,] sqrVigenere)
        {
            string s = "";
            for (int i = 0; i < sqrVigenere.GetLength(0); i++)
            {
                for (int j = 0; j < sqrVigenere.GetLength(1); j++)
                {
                    if (i == -1)
                    {
                        if (j + 1 < 10)
                            s += "0" + (j + 1).ToString() + " ";
                        else
                            s += j + 1 + " ";
                    }
                    else if (j == -1)
                    {
                        if (i + 1 < 10)
                            s += "0" + (i + 1).ToString() + " ";
                        else
                            s += i + 1 + " ";
                    }
                    else
                        s += sqrVigenere[i, j] + "[" + getRigthNum(i) + "," + j.ToString() + "]";
                }
                s += "\n";
            }
            return s;
        }

        string getRigthNum(int i)
        {
            if (i.ToString().Length == 1)
                return "0" + i.ToString();
            return i.ToString();
        }

        string showSqrViginere(string[,] sqrVigenere)
        {
            string s = "";
            for (int i = -1; i < sqrVigenere.GetLength(0); i++)
            {
                for (int j = -1; j < sqrVigenere.GetLength(1); j++)
                {
                    if (i == -1)
                    {
                        if (j + 1 < 10)
                            s += "0" + (j + 1).ToString() + " ";
                        else
                            s += j + 1 + " ";
                    }
                    else if (j == -1)
                    {
                        if (i + 1 < 10)
                            s += "0" + (i + 1).ToString() + " ";
                        else
                            s += i + 1 + " ";
                    }
                    else
                        s += sqrVigenere[i, j] + "[" + getRigthNum(i) + "," + j.ToString() + "]";
                }
                s += "\n";
            }
            return s;
        }

        string showSqrViginereCode(byte[,] sqrVigenere)
        {
            string s = "";
            for (int i = -1; i < sqrVigenere.GetLength(0); i++)
            {
                for (int j = -1; j < sqrVigenere.GetLength(1); j++)
                {
                    if (i == -1)
                    {
                        if (j + 1 < 10)
                            s += "0" + (j + 1).ToString() + " ";
                        else
                            s += j + 1 + " ";
                    }
                    else if (j == -1)
                    {
                        if (i + 1 < 10)
                            s += "0" + (i + 1).ToString() + " ";
                        else
                            s += i + 1 + " ";
                    }
                    else
                        s += sqrVigenere[i, j] + "[" + getRigthNum(i) + "," + j.ToString() + "]";
                }
                s += "\n";
            }
            return s;
        }

        private void показатьКвадратВиженераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(sqrPath, showSqrViginereCode(getSqrVigenere(0)));
            System.Diagnostics.Process.Start(Application.StartupPath + "\\" + sqrPath);
        }

        private void показатьЗамененныйКлючомТекстToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Text += "\nШифруемое сообщение: " + MESSAGE;
            richTextBox.Text += "\nКлюч: " + KEY;
            richTextBox.Text += "\nЗамененное ключом сообщение: " + KEYMASSAGE;
            richTextBox.Text += "\nЗашифрованное сообщение: " + ENCRYPT;
            richTextBox.Text += "\nДешифрованное сообщение: " + DECRYPT;
        }

        private void GeneralForm_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ru-RU");
            if (InputLanguage.CurrentInputLanguage.Culture.Name.Equals(ci.Name))
                generateSqrVigenere(ruBig);
            else
                generateSqrVigenere(enBig);
            Text = "Методы шифрования " + "[" + InputLanguage.CurrentInputLanguage.Culture.Name + "]";

        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            setDefaultTextList(richTextBox.Text);
            richTextBox.Text = "";
        }

        int curPos = 0;
        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox.Text == "")
                setDefaultTextList(richTextBox.Text);
        }

        private void расшифроватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decrypt(richTextBox.SelectedText, true);
        }

        private void зашифроватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encrypt(richTextBox.SelectedText, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                viewLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void viewLog()
        {
            log.Insert(0, DateTime.Now.ToString());
            log.Insert(0, "");
            File.AppendAllLines(logPath, log);
            System.Diagnostics.Process.Start(Application.StartupPath + "\\" + logPath);
            log.Clear();
        }

        //поскольку многие символы не отображаются, лучше использовать их коды
        // на величину move этот массив будет сдвинут влево
        byte[,] getSqrVigenere(int move)
        {
            //формируем массив всевозможных символов
            byte[] bytes = new byte[256];
            for (int i = 0; i < 256; i++)
                bytes[i] = Convert.ToByte(i);
            byte[] result = moveLeft(bytes, move);
            return generateChangedSqrVigenere(result.ToList());
        }

        string convertArrayToString(byte[] bytes)
        {
            string s = "";
            foreach (byte b in bytes)
                s += b.ToString() + " ";
            return s;
        }

        private void показатьКодыСимволовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Application.StartupPath + "\\" + sqrPath , getCodes());
            System.Diagnostics.Process.Start(Application.StartupPath + "\\" + sqrPath);
        }

        string getCodes()
        {
            byte[,] sqr = getSqrVigenere(0);
            //return showSqrViginereCode(sqr);
            string s = "";
            for (int i = 0; i < sqr.GetLength(0); i++)
            {
                byte[] b = new byte[1];
                b[0] = sqr[0, i];
                s += Encoding.Default.GetString(b) + " = " + b[0] + "; \n"; 
            }
            return s;
        }

        private void toolStripMenuItemLog_Click(object sender, EventArgs e)
        {
            viewLog();
        }

        private void comboBoxEncType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEncType.SelectedIndex == 2)
            {
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBoxL.Visible = true;
                textBoxR.Visible = true;
                comboBoxW.Visible = true;
                //checkBox5.Visible = true;
                //checkBox6.Visible = true;
                //checkBox7.Visible = true;
                KEY = "5725369";
            }
            else 
            {
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                textBoxL.Visible = false;
                textBoxR.Visible = false;
                comboBoxW.Visible = false;
                KEY = "воландеморт";
                //checkBox5.Visible = false;
                //checkBox6.Visible = false;
                //checkBox7.Visible = false;
            }
        }

        private void comboBoxW_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void тестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            setlog(moveLeft(a, 5), "Влево на 5");
            setlog(moveRight(a, 5), "Вправо на 5");
        }

        private void comboBoxW_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void проверитьРассеиваниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cryptoAnalysis();
        }

        int countInStr(char c, string s)
        {
            int kol = 0;
            foreach (char ch in s)
                if (c.Equals(ch))
                    kol++;
            return kol;
        }

        bool isHere(List<string> l, string s)
        {
            foreach (string ss in l)
                if (ss.Equals(s))
                    return true;
            return false;
        }

        void cryptoAnalysis()
        {
            try
            {
                string report = DateTime.Now.ToString() + "\nКриптоанализ шифра " + comboBoxEncType.Text + "\n";
                string[] messeges = { "1234567890", "1a2b3c4d5e6f7g8h9i0j", "РеГиСтР не ИМЕЕТ vAlUe", "Просто предложение, содержащее следующие знаки: !\"№;%:?*()<>. Также это сообщение должно быть достаточно длинным.", "СловоWordСловоWordСловоWordСловоWordСловоWord" };

                foreach (string mes in messeges)
                {
                    /*Рассеивание – нивелирование влияния статистических свойств открытого текста на криптограмму. 
                     * Рассеивание распространяет влияние одного символа открытого текста на большое число символов криптограммы. 
                     * Рассеивание обычно достигается использованием методов перестановки.

                     * Перемешивание – усложнение восстановления взаимосвязи статистических свойств открытого текста и криптограммы, а также между ключом и криптограммой. 
                     * Перемешивание соответствует использованию методов замены*/

                    report += "Анализируется сообщение: " + mes + "\n";
                    encrypt(mes, false);
                    decrypt(ENCRYPT, false);
                    report += "Шифр текст (криптограмма): " + ENCRYPT + "\n";
                    KEY = generateKey(num, 32);
                    report += "Ключ: " + KEY + "\n";
                    report += "Расшифрованное сообщение: " + DECRYPT + "\n";
                    report += "Проверка рассеивания..." + "\n";
                    //рассеивание 
                    string enc = ENCRYPT;
                    string dec = DECRYPT;
                    enc = enc.Remove(0, 1);
                    report += "Удалим первый символ криптограммы (" + enc + ")\n";
                    decrypt(enc, false);
                    report += "Получили следующую расшифровку: " + DECRYPT + "\n";

                    enc = ENCRYPT;
                    enc = enc.Remove(4, 1);
                    report += "Удалим пятый символ криптограммы (" + enc + ")\n";
                    decrypt(enc, false);
                    report += "Получили следующую расшифровку: " + DECRYPT + "\n";

                    enc = ENCRYPT;
                    enc = enc.Remove(6, 1);
                    report += "Удалим седьмой символ криптограммы (" + enc + ")\n";
                    decrypt(enc, false);
                    report += "Получили следующую расшифровку: " + DECRYPT + "\n";

                    enc = ENCRYPT;
                    enc = enc.Remove(0, enc.Length / 3);
                    report += "Удалим треть символов криптограммы (" + enc + ")\n";
                    decrypt(enc, false);
                    report += "Получили следующую расшифровку: " + DECRYPT + "\n";

                    //перемешиваение (несколько раз шифровать сообщения)
                    report += "Проверка перемешивания..." + "\n";
                    report += "Вычисление количества символов в криптограмме и исходном сообщении..." + "\n";
                    enc = ENCRYPT;
                    report += "Исходное сообщение содержит:" + "\n";
                    List<string> was = new List<string>();
                    foreach (char c in mes)
                    {
                        string str = c + "(" + countInStr(c, mes) + "); ";
                        if (!isHere(was, str))
                            was.Add(str);
                    }
                    foreach (string s in was)
                        report += s;
                    report += "\n";
                    report += "Криптограмма содержит:" + "\n";
                    List<string> is_ = new List<string>();
                    foreach (char c in enc)
                    {
                        string str = c + "(" + countInStr(c, enc) + "); ";
                        if (!isHere(is_, str))
                            is_.Add(str);
                    }
                    foreach (string s in is_)
                        report += s;
                    report += "\n";
                    report += "Изменим значение криптоключа." + "\n";
                    KEY = generateKey(num, 32);
                    string key = KEY;
                    KEY = KEY.Remove(0, 1);
                    report += "Удалим первый символ криптоключа (" + KEY + ")\n";
                    decrypt(enc, false);
                    report += "Получили следующую расшифровку: " + DECRYPT + "\n";

                    KEY = key;
                    KEY = KEY.Remove(4, 1);
                    report += "Удалим пятый символ криптоключа (" + KEY + ")\n";
                    decrypt(enc, false);
                    report += "Получили следующую расшифровку: " + DECRYPT + "\n";

                    KEY = key;
                    KEY = KEY.Remove(6, 1);
                    report += "Удалим седьмой символ криптоключа (" + KEY + ")\n";
                    decrypt(enc, false);
                    report += "Получили следующую расшифровку: " + DECRYPT + "\n";

                    KEY = key;
                    KEY = KEY.Remove(0, KEY.Length / 3);
                    report += "Удалим треть символов криптоключа (" + KEY + ")\n";
                    decrypt(enc, false);
                    report += "Получили следующую расшифровку: " + DECRYPT + "\n";

                    KEY = key;

                }
                int kol = 0;
                byte[] code = new byte[1];
                string ss = "";
                string message;
                int[] count;
                int[] getTen;
                byte[] arra;
                while (kol < 50)
                {
                    count = new int[256];
                    //случайным образом сгенерируем 10 сообщений, зашифруем их и посчитаем количество встречаний различных символов
                    report += "Генерация и шифровка 10 сообщений..." + "\n";
                    for (int i = 0; i < 10; i++)
                    {
                        message = generateKey(16);
                        report += (i + 1).ToString() + ". " + message + "\n";
                        KEY = generateKey(num, 32);
                        encrypt(message, false);
                        report += "=>" + ENCRYPT + "\n";
                        arra = getBytes(ENCRYPT);
                        foreach (byte b in arra)
                            count[Convert.ToInt16(b)]++;

                    }
                    report += "Подсчет символов в получившихся криптограммах (выводятся не символы, а их ASCII коды)..." + "\n";
                    for (int i = 0; i < count.Length; i++)
                    {
                        report += i.ToString() + "(" + count[i] + "); ";
                    }

                    report += "\n" + "Записываем 10 часто встречающихся символов...";
                    getTen = getMaxsValue(count, 10);
                    ss += kol.ToString() + ". ";
                    foreach (int i in getTen)
                    {
                        code[0] = Convert.ToByte(i);
                        ss += Encoding.Default.GetString(code) + ":" + count[i].ToString() + ", code:" + i.ToString() + "; ";
                    }
                    ss += "\n";
                    kol++;
                }
                report += "\n" + "10 часто встречающихся символов в 50 разных генерациях и шифровках 10 сообщений: " + "\n";
                report += ss;

                //посчитаем количество совпадающих символов в исходном сообщении и шифре

                
                //случайным образом сгенерируем 10 сообщений, зашифруем их и посчитаем количество встречаний различных символов
                report += "Генерация и шифровка 100 сообщений..." + "\n";
                report += "Проверка на повторения..." + "\n";
                int koll = 0;
                bool ok = false;
                byte[] M;
                byte[] E;
                int total = 0;
                int KOL = 1000;
                for (int i = 0; i < KOL; i++)
                {
                    message = generateKey(16);
                    count = new int[16];

                    KEY = generateKey(num, 32);
                    encrypt(message, false);

                    M = Encoding.Default.GetBytes(message);
                    E = getBytes(ENCRYPT);
                    for (int k = 0; k < M.Length; k++)
                        for (int j = 0; j < E.Length; j++)
                            if (M[k].Equals(E[j]))
                            {
                                count[k]++;
                            }
                    ok = false;
                    foreach (int ii in count)
                        if (!ii.Equals(0))
                            ok = true;
                    if (ok)
                    {

                        for (int k = 0; k < M.Length; k++)
                            if (!count[k].Equals(0))
                            {
                                report += (i + 1).ToString() + ". " + message + "\n";
                                report += "=>" + Encoding.Default.GetString(E) + "\n";
                                code[0] = M[k];
                                report += Encoding.Default.GetString(code) + ":" + count[k] + "; ";
                                total += count[k];
                            }
                        koll++;
                        report += "\n";
                    }

                }
                report += "Количество шифровок без соответствий:" + (KOL - koll).ToString() + " из " + KOL.ToString() + "\n";
                report += "Среднее количество совпадающих символов в сообщения и дешифровки:" + ((double)(total / koll)).ToString() + "\n";

                string[] arr = report.Split('\n');
                File.WriteAllLines(caPath, arr);
                System.Diagnostics.Process.Start(@"C:\Users\Николай\Documents\Visual Studio 2010\Projects\Encryption\Encryption\bin\Debug\" + caPath);
                richTextBox.Text = report;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
            }
        }
        //возвращает заданное число индексов элементов с максимальными значениями 
        int[] getMaxsValue(int[] arr, int count)
        {
            int[] maxs = new int[count];
            List<int> arrI = arr.ToList();
            for (int i = 0; i < count; i++)
            {
                int max = arrI.Max();
                maxs[i] = arrI.IndexOf(max);
                arrI.RemoveAt(maxs[i]);
            }
            return maxs;
        }

        private void показатьРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\Николай\Documents\Visual Studio 2010\Projects\Encryption\Encryption\bin\Debug\" + caPath);
        }

    }
}
