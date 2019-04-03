#define WANGKAI 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.Threading;

namespace ConsoleApp1
{
    struct Book {
        public string name;
    }

    class A {}
    /**
    * c#不支持多继承！！！所以只能用单继承！
    **/
    interface B {}
    interface C {}
    interface D {}
    abstract class E {
        // 抽象方法
        public abstract void test();
        
        public virtual void test1() {
            Console.WriteLine( "virtual method 必须在子类当中去实现!" );
        }
        // public virtual void test2() = 0; // 虚方法必须有方法体！
    }


    class Cat : A, B, C, D {
        private string name;
        public static int variable;
        public string color { get; set;  } // 设置为可读可写属性
        public int MyProperty { get; set; }


        [Conditional("WANGKAI")]
        public static void say() {
            Console.WriteLine( "只有定义了DEBUG，才可以执行这个方法" );
        }

        [Obsolete("deprecated method, it will be marked by error", false)]
        public static void deprecatedMethod() {
            Console.WriteLine( "please don't call me, I am just a deprecated method!" );
        }

        public static void visitStatic() {
            variable = 1;
            // name = "adasd"; // 静态方法只能方法静态属性
        }
        public Cat(string name) {
            this.name = name;
        }
        public string getName() {
            return this.name;
        }

        // 引用传递，相当于传递的是地址
        public void test1(ref int a) { }
        // 输出传递， 用于返回多个值
        public void updateBug(out int b) {
            b = 110; // 必须对out类型的参数进行输出，否则就是无意义参数，无法通过编译甚至编辑器检查
        }
        /**
         * 结构体是值类型的，包括其中包括的字段也是
         * 
         **/
        public void acceptStruct(Book book) {
            book.name = "开啊开";
        }

        ~Cat() {
            Console.WriteLine("析构函数！！");
        }

        // 重载运算符号
        public static Cat operator +(Cat a) {
            return a;
        }

        // 索引器， 一般用于自定义集合当中
        public string this[ int index ]
        {
            get {
                return this.name;
            }
            set
            {
                if (index >=  0)
                {
                    this.name = value;
                }
            }
        }
       
    }
    class Program
    {
        public static void test1(string s) {
            Console.WriteLine( "deletgate1");
        }
        public static void test2(string s)
        {
            Console.WriteLine("deletgate2");
        }
        // 类似于c语言当中的函数指针一样
        public delegate void MyDelegate(string s);
        static  void Main(string[] args)
        {
            
            Cat.say();
            Cat.say();
            Cat.deprecatedMethod();

            Cat cat = new Cat("");

            MyDelegate m = new MyDelegate(test1);
            m += test2;
            m("test");

            // cat.color = "assas";
            Book book;
            book.name = "asad";
            cat.acceptStruct( book );
            Console.WriteLine( book.name );

            double? d = 110d;
            double c = d ?? 520;
            Console.WriteLine( c );
            // 相当于
            Nullable<int> n = new Nullable<int>(889);
            Console.WriteLine( n );
            /*
            Console.WriteLine( "程序！！" );

            Cat cat1 = new Cat( "maomi" );
            dynamic c1 = cat1;

            Console.WriteLine( c1.getName() );
            Console.WriteLine( cat1.getName() );

            string str = @"c:\windows.......";
            Console.WriteLine( str );

            string str2 = @"c:\windows.......
            adsdsadsadsa
            asdsadasd
            asdsad";
            Console.WriteLine(str2);

            // 哈哈 C#里面也是有指针的咯！！
            try
            {
                int i = 2;
                Boolean b = false;
                Boolean.TryParse("true", out b ); // 解析后，将变量赋予b
                Console.WriteLine( b );
                // char* c;
                // *c = 'a';
            }
            catch (Exception e) {
                e.ToString();
            }
            */


            // 集合
            /*
            Hashtable ht = new Hashtable();
            ht.Add("b", "b");
            ht.Add("c", "c");
            ht.GetEnumerator();
            */

            /**
             * C#对线程的支持 
             */
            ThreadStart threadStart = new ThreadStart( delegate () {
                while (true ) {
                    Console.WriteLine("我创建了匿名函数");
                    Thread.Sleep(100);
                }
            } );
            ThreadStart threadStart2 = new ThreadStart(delegate () {
                while (true)
                {
                    Console.WriteLine("我创建了匿名函数222");
                    Thread.Sleep(100);
                }
            });

            Thread t1 = new Thread(threadStart );
            Thread t2 = new Thread(threadStart2);

            t1.Start();
            t2.Start();

            Console.ReadKey();
        }
    }
}
