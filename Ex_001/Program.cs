﻿// 5. Конвертер валют. У пользователя есть баланс в каждой из представленных валют.
// С помощью команд он может попросить сконвертировать одну валюту в другую.
// Курс конвертации просто описать в программе. Программа заканчивает свою работу в тот момент,
// когда решит пользователь.

int billDollar = 5; //5 долларова
int billEuro = 5; // 5 евро
int biilRubles = 350; // 350 рублей
int billYuan = 40;// 40 юаней
int billTenge = 2800;//2800 тенге
bool isWork = true;
int dollarRubles = 60;
int dollarEuro = 1;
int dollarYuan = 7;
int dollarTenge = 480;

Console.WriteLine("\nВас приветствует самый крутой сервис по конвертированию валют.");
Console.WriteLine("В честь нашего открытия, у вас после регистрации в кошельке уже будет валюта различного номинала.");
Console.Write("Хотите зарегестрироваться?(Введите 'да' 'нет'): ");
string registrationStatus = Console.ReadLine();

if(registrationStatus.ToLower() == "да")
{
    Console.Write("Введите логин: ");
    string login = Console.ReadLine();
    Console.Write("Введите пароль: ");
    int password = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Регистрация прошла успешно!)Приятного пользования нашим сервисом\n");

    while(isWork)
        {
            Console.Write("Напишите то,что выхотите сделать(Чтобы получить инструкцию напишите - 'help'): ");
            string decision = Console.ReadLine();
            switch(decision.ToLower())
            {
                case "help" :
                    Console.WriteLine("Все возможности нашего конвертера:\n");
                    Console.WriteLine("Currencies - вывести имеющиеся валюты на вашем кошельке");
                    Console.WriteLine("ChangePassword - изменить пароль");
                    Console.WriteLine("ExchangeRate - узнать курс валют");
                    Console.WriteLine("Exit - выйти из этой программы. ");
                    break;
                case "exit":
                    isWork = false;
                    break;
                case "changepassword":
                    Console.Write("Чтобы установить новый пароль - введите старый пароль: ");
                    int oldPassword = Convert.ToInt32(Console.ReadLine());
                    if(oldPassword == password)
                    {
                        Console.WriteLine("Старый пароль введен успешно!");
                        Console.Write("Введите новый пароль: ");
                        password = Convert.ToInt32(Console.ReadLine());//Можно было бы еще через одну переменную сделать,но та практичнее и быстрей.                     
                    }
                    break;
                case  "currencies": 
                    Console.WriteLine($"У вас имеется вот столько рублей : {biilRubles}");
                    Console.WriteLine($"У вас имеется вот столько долларов : {billDollar}");
                    Console.WriteLine($"У вас имеется вот столько евро : {billEuro}");                   
                    Console.WriteLine($"У вас имеется вот столько юаней : {billYuan}");
                    Console.WriteLine($"У вас имеется вот столько тенге : {billTenge}\n");
                    break;
                case "exchangerate" :
                    Console.WriteLine("Доступные валюты для конвертации: ruble,dollar,euro,yuan,tenge");
                    Console.Write("Введите валюту, которую хотите конвертировать: ");
                    string currencyOne = Console.ReadLine();
                    Console.Write("Введите валюту, в которую хотите конвертировать: ") ;
                    string currencyTwo = Console.ReadLine();

                    if(currencyOne.ToLower() == "dollar" && currencyTwo.ToLower() == "ruble")
                    {
                        Console.WriteLine($"После конвертации вы получите вот столько рублей: {billDollar * dollarRubles}");
                        Console.Write("Если вы согласны, напишите 'да', если нет, то напишите 'нет': ");
                        string conversionOpinion = Console.ReadLine();
                        if(conversionOpinion.ToLower() == "да" )
                            {
                                biilRubles +=  billDollar * dollarRubles;
                                billDollar -= billDollar;
                                Console.WriteLine($"Конвертация прошла успешно, на вашем счету теперь вот столько рублей - {biilRubles} и вот столько долларов - {billDollar}");
                            }
                    }
                    else if(currencyOne.ToLower() == "ruble" && currencyTwo.ToLower() == "dollar")
                    {
                        Console.WriteLine($"После конвертации вы получите вот столько долларов: {biilRubles / dollarRubles}");
                        Console.Write("Если вы согласны, напишите 'да', если нет, то напишите 'нет': ");
                        string conversionOpinion = Console.ReadLine();
                        if(conversionOpinion.ToLower() == "да" )
                            {
                                billDollar +=  biilRubles /  dollarRubles   ;
                                biilRubles = biilRubles  % dollarRubles ;
                                Console.WriteLine($"Конвертация прошла успешно, на вашем счету теперь вот столько долларов - {billDollar} и вот столько рублей - {biilRubles}");
                            }
                    }
                    else if(currencyOne.ToLower() == "dollar" && currencyTwo.ToLower() == "euro")
                    {
                        Console.WriteLine($"После конвертации вы получите вот столько евро: {billEuro * dollarEuro}");
                        Console.Write("Если вы согласны, напишите 'да', если нет, то напишите 'нет': ");
                        string conversionOpinion = Console.ReadLine();
                        if(conversionOpinion.ToLower() == "да" )
                            {
                                billEuro +=  billEuro * dollarEuro;
                                billDollar -= billDollar;
                                Console.WriteLine($"Конвертация прошла успешно, на вашем счету теперь вот столько евро - {dollarEuro} и вот столько долларов - {billDollar}");
                            }
                    }
                    break;

                
            }
        }
}
else{
    Console.WriteLine("Досвидания, до скорых встреч!)");
}





