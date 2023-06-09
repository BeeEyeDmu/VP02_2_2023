using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _024_Student
{
  public class Student
  {
    public string Name { get; set; }
    public int Age { get; set; }
    public string Major { get; set; }

    public Student(string n, int a, string m)
    {
      Name = n;
      Age = a;
      Major = m;
    }

    public void DisplayInfo()
    {
      Console.WriteLine("이름 : " + Name);
      Console.WriteLine("나이 : " + Age);
      Console.WriteLine("전공 : " + Major);
    }
    //private string name;
    //private int age;
    //private string major;

    //public Student(string n, int a, string m)
    //{
    //  name = n;
    //  age = a;
    //  major = m;
    //}

    //public void DisplayInfo()
    //{
    //  Console.WriteLine("이름 : " + name);
    //  Console.WriteLine("나이 : " + age);
    //  Console.WriteLine("전공 : " + major);
    //}
  }
  internal class Program
  {
    static void Main(string[] args)
    {
      Student s = new Student("홍길동", 20, "의료IT공학");
      s.DisplayInfo();
    }
  }
}
