using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*MEMBERS
 * AMRI SHABANI MWARUKA  ID NO: 102120494
 * MAKAME JUMA MAKAME    ID NO: 102120497
 */
namespace PhoneApplication
{
    //DirectoryEntry Class
    class DirectoryEntry
    {
        string name;
        string PhoneNumber;
        public DirectoryEntry(string Name, string Number)//DirectoryEntry Constructor with two parameters
        {
            name = Name;
            PhoneNumber = Number;
        }
        public string GetName()//Get method to return name from class
        {
            return name;
        }
        public string GetPhoneNumber()//Get method to return phone number from class
        {
            return PhoneNumber;
        }
        public void SetPhoneNumber(string n)//set method with parameter to set phone number
        {
            PhoneNumber = n;
        }
        public override string ToString()//ToString method for converting the entries into string
        {
            string entry = "\n\nName= " + name + "\nPhone Number= " + PhoneNumber;
            return entry;
        }
    }
    public class MyArrayList<T>//MyArrayList class in generic data type
        {
        
            T[] data;
            public int NumOfElement;
            public MyArrayList()//MyArrayList Constructor without parameter
            {
                data = new T[1];
                NumOfElement = 0;
            }
            public void Add(T newElement)//Add method for adding new element to MyArrayList
        {
            if(NumOfElement== data.Length-1)
                DoubleSizeOfArray();
                data[NumOfElement]=newElement;
                NumOfElement++;
                Console.WriteLine();
                Console.WriteLine("Total Data entered are:{0} ",data.Length);
                return;
        }
            public void DoubleSizeOfArray()//DoubleSize method for reallocating space in MyArrayList
            {
                T[] newArray = new T[data.Length * 2];
                Array.Copy(data, newArray, data.Length);
                data = newArray;
                return;
            }
            public T Remove(int index)//Method to delete element from MyArrayList
            {
                if (index >= NumOfElement)
                    Console.WriteLine("The space you requested is out of our boundary");
                T result=data[index];
                for(int i=index+1;i<= NumOfElement;i++)
                    data[i-1]=data[i];
                 return result;               
            }
            public int Count()    //Method to count number of element in MyArrayList
            {
                return NumOfElement;
            }
            public T GetValue(int index)
            {
                if(index>=NumOfElement)
                  Console.WriteLine("The space you requested is out of our boundary");
                return data[index];
            }
            public void  Set(int index, T newValue)   //Method to set new element in the array
            {
                T OldValue=data[index];
                data[index] = newValue;               
            }
        }
    class PhoneDirectory        //Phone Directory class
        {
        MyArrayList<DirectoryEntry> phoneBook;
        public void AddEntry (DirectoryEntry DE) //Add Entry method for adding new entry in the phone directry
        {
            phoneBook.Add(DE);
        }
        public void PrintDirectory()//Method for printing the entries in the phone directory
        {
            for (int i = 0; i < phoneBook.NumOfElement; i++)
                Console.WriteLine(phoneBook.GetValue(i));
        }
        public void DisplayMenu()//method for displaying choice menu
        {
            try
             {
            int choice;
            do //do while loop to repeatition of the choice
            {
                Console.WriteLine();
                Console.WriteLine("\tWelcome to Personal Directory PhoneApplication");
                Console.WriteLine("\t**********************************************");
                Console.WriteLine("Enter 1  for :    Adding  a new Name & Phone Number pair\nEnter 2  for :    Searching a Phone Number\n" +
                    "Enter 3  for :    Deleting an Existing Name and Phone Number pair\nEnter 4  for :    Modifying the Phone Number\n" +
                    "Enter 5  for :    Display Complete Directory\nEnter 6  for :    Exit");
                Console.WriteLine();
                Console.Write("Enter Your Choice: ");
                
                choice = int.Parse(Console.ReadLine());
                  
                Console.WriteLine();

                switch (choice)
                {
                       
                    case 1: AddPhoneEntry(); break;
                    case 2: SearchPhoneNumber(); break;
                    case 3: DeletePhoneEntry(); break;
                    case 4: ModifyPhoneNumber(); break;
                    case 5: PrintDirectory(); break;
                    case 6: ExitDirectoryApplication(); break;
                        
                
                    default: Console.WriteLine("Invalid Choice. Please Enter  the Correct Choice"); break;
                }
                
                } while (choice != 6);
             }
             catch (Exception) { Console.WriteLine("The choice u made is incorrect Please enter the correct One" ); }
            
        }      
        public void AddPhoneEntry()//method to add name and phone number in the phone directory
        {
            string name, phoneNumber;
            Console.Write("Enter name : ");            
                name = Console.ReadLine();
                Console.Write("\nEnter the Phone Number: ");
                phoneNumber = Console.ReadLine();   //asking the user to enter input
                AddEntry(new DirectoryEntry(name, phoneNumber));
           
        }
        public string SearchPhoneNumber()//method for searching entry from the phone directory
        {
            Console.Write("Please enter the name: ");
            string name = Console.ReadLine();
            for (int i = 0; i < phoneBook.NumOfElement; i++)
                if (phoneBook.GetValue(i).GetName() == name) 
                {
                 Console.WriteLine();
                 Console.WriteLine("The Phone Number of {0} is {1}",name,phoneBook.GetValue(i).GetPhoneNumber());
                }
            else Console.WriteLine("SORRY,THE CONTACT DOES NOT EXIST!");
            return " ,";            

        }
        public void DeletePhoneEntry()//method to delete element from the phone directory
        {
            Console.Write("Please enter the name: ");
            string name = Console.ReadLine();
            for (int i = 0; i < phoneBook.NumOfElement; i++)
                if (phoneBook.GetValue(i).GetName() == name)
                {
                    phoneBook.Remove(i);
                    Console.WriteLine("The contact {0}, has been deleted", name);
                    return;
                }
            Console.WriteLine("The contact does not exist");            
        }
        public void ModifyPhoneNumber()//method to modify entries in the phone dictory
           {               
            Console.Write("Please enter the name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
               for (int i = 0; i < phoneBook.NumOfElement; i++)
                   if (phoneBook.GetValue(i).GetName() == name)
                   {
                       Console.Write("Please enter the new number: ");                       
                       phoneBook.GetValue(i).SetPhoneNumber(Console.ReadLine());
                       Console.WriteLine();
                       Console.WriteLine(phoneBook.GetValue(i).ToString());
                       return;
                   }
               Console.WriteLine();
               Console.WriteLine("SORRY,THE CONTACT DOES NOT EXIST!!");
           }
        public void ExitDirectoryApplication()//method to exit from phone application
        {
            Console.WriteLine("\n\n\t\tBYE BYE!!");
            Console.ReadKey();
            System.Environment.Exit(0);
        }
        static void Main(string[] args)
        {
            PhoneDirectory pd = new PhoneDirectory();
            pd.phoneBook = new MyArrayList<DirectoryEntry>();
            pd.DisplayMenu();
            Console.ReadKey();
        }                        
    }
}
