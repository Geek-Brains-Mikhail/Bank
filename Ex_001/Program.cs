//************BeginnigDictionaries************//
var rate = new Dictionary<string,double>()
{
    ["rub"] = 1   ,
    ["usd"] = 60,
    ["eur"] = 62,
    ["chf"] = 65,
    ["cny"] = 9
};

var currenciesAvailable = new Dictionary<string,string>()
{
    ["rub"] = "Российский рубль",
    ["usd"] = "Американский доллар",
    ["eur"] = "Американское евро",
    ["chf"] = "Швейцарский франк",
    ["cny"] = "Китайский юань"
};
var balance = new Dictionary<string,double>()
{
    ["rub"] = 6000,
    ["usd"] = 100,
    ["eur"] = 100,
    ["chf"] = 95,
    ["cny"] = 700
};
//************BeginnigMethods************//
void OutputCourse (Dictionary<string,double> dic)
{
    foreach(var course in dic)
    {
        Console.WriteLine($"{course.Key} = {course.Value}");
    }
}

void OutputCurrency(Dictionary<string,string> dic)
{
    foreach(var currency in dic)
    {
        Console.WriteLine($"{currency.Key} = {currency.Value}");
    }
}
void OutputBalance(Dictionary<string,double> dictionar)
{
    foreach(var balance in dictionar)
    {
        Console.WriteLine($"{balance.Key} = {balance.Value}");
    }
}
void ConvertCurrency (Dictionary<string,double> balance, Dictionary<string,double> rate,string login, int password)
{
    Console.WriteLine("Для доступа к конвертированию введите логин и пароль!") ;
    Console.Write("Введите логин: ");
    string checklogin = Console.ReadLine();
    Console.Write("Введите пароль: ");
    int checkpassword = Convert.ToInt32(Console.ReadLine());
    
    if(checklogin == login && checkpassword == password)
    {
        Console.WriteLine("Вход разрешен.");
        bool statusConversions = true;
        while(statusConversions)
        {
            Console.Write("Хотите конвертировать валюту(Если хотите, напишете - 'yes', если нет, то напишите - 'no' ): ");
            if(Console.ReadLine().ToLower() == "yes")
            {
                Console.Write("Введите валюту, которую хотите конвертировать: ");
                string firstCurrency = Console.ReadLine();
                Console.Write("Введите валюту, в которую хотите конвертировать " + firstCurrency + ": ");
                string secondCurrency = Console.ReadLine();
                Console.Write($"Введите количество {firstCurrency}, которое вы хотите конвертировать в {secondCurrency}: ");
                double numberConversions = Convert.ToDouble(Console.ReadLine());
                if(firstCurrency.ToLower() != "rub" && secondCurrency.ToLower() !="rub")
                {  
                    if(numberConversions <= balance[firstCurrency])
                    {   
                        double firstCount = numberConversions * rate[firstCurrency];  //balance[firstCurrency] * rate[firstCurrency];
                        double secondCount = Math.Round(firstCount / rate[secondCurrency],2);
                        double manipulatroOne =  balance[firstCurrency] - numberConversions;
                        Console.WriteLine($"после конвертации {firstCurrency} в {secondCurrency} на вашем счете будет {balance[secondCurrency] + secondCount} {secondCurrency}  и  {manipulatroOne} {firstCurrency};");
                        Console.Write("Конвертируем?:('yes' or 'not') : ");
                        if(Console.ReadLine().ToLower() == "yes")
                        {
                            balance[secondCurrency] += secondCount;
                            balance[firstCurrency] -= numberConversions;
                            Console.WriteLine("Конвертация прошла очень успешно!)");
                        }
                    }   
                }
                else if(firstCurrency.ToLower() == "rub")
                {       
                    if(numberConversions <= balance[firstCurrency])
                        {   
                            double firstCount =  Math.Round(numberConversions/ rate[secondCurrency] ,  2)  ;
                            double manipulatroOne =  balance[firstCurrency] - numberConversions;
                            Console.WriteLine($"после конвертации {firstCurrency} в {secondCurrency} на вашем счете будет {balance[secondCurrency] + firstCount} {secondCurrency}  и  {manipulatroOne} {firstCurrency};");
                            Console.Write("Конвертируем?:('yes' or 'not') : ");
                            if(Console.ReadLine().ToLower() == "yes")
                            {
                                balance[secondCurrency] += firstCount;
                                balance[firstCurrency] -= numberConversions;
                                Console.WriteLine("Конвертация прошла очень успешно!)");
                            }
                        }  
                }
                else if(secondCurrency.ToLower() == "rub")
                {       
                    if(numberConversions <= balance[firstCurrency])
                        {   
                            double firstCount =  Math.Round( numberConversions * rate[firstCurrency],2) ;
                            double manipulatorOne =  balance[firstCurrency] - numberConversions;
                            Console.WriteLine($"после конвертации {firstCurrency} в {secondCurrency} на вашем счете будет {balance[secondCurrency] + firstCount} {secondCurrency}  и  {manipulatorOne} {firstCurrency};");
                            Console.Write("Конвертируем?:('yes' or 'not') : ");
                            if(Console.ReadLine().ToLower() == "yes")
                            {
                                balance[secondCurrency] += firstCount;
                                balance[firstCurrency] -= numberConversions;
                                Console.WriteLine("Конвертация прошла очень успешно!)");
                            }
                        }  
                } 
            }
            else
            {
                statusConversions = false;
            }
        }
    }
    else
    {
        Console.WriteLine("В доступе отказано!(");
    }   
}
//************BeginningCode**********//
bool isWork = true;
string workDecision ="";
Console.WriteLine("Приветствуем вас в нашем сервисе- конвертере. В честь нашего открытия, после регистрации, на вашем счету будет валюта разного номинала\n");
Console.Write("Хотите зарегестрироваться?(Введите 'yes' or 'no'): ");
string registrationStatus = Console.ReadLine();
if(registrationStatus.ToLower() == "yes")
{
    Console.Write("Введите логин: ");
    string login = Console.ReadLine();
    Console.Write("Введите пароль: ");
    int password = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Регистрация прошла успешно!)Приятного пользования нашим сервисом\n");
    while(isWork)
    {
        Console.Write("Введите, что вы хотите сделать(Чтобы получить инструкцию, напишите - 'help') : ");
        workDecision = Console.ReadLine();
        switch(workDecision.ToLower())
        {
            case "help":
                Console.WriteLine("Exchangerate - узнать обменный курс.\nCurrenciesExchange - узнать наименования валют.\nConvertCurrency - конвертировать свою валюту.\nBalance - узнать свой баланс\nExit -  выйти  из программы");
                break;
            case "exit" :
                isWork = false;
                break;
            case "exchangerate":
                OutputCourse(rate);
                break;
            case "currenciesexchange":
                OutputCurrency(currenciesAvailable);
                break;
            case "convertcurrency" :
                ConvertCurrency(balance, rate, login, password);
                break;
            case "balance" :
                OutputBalance(balance);
                break;
        }
    }
}
else
{
    Console.WriteLine("Досвидания!");
}