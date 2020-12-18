using System;
using System.Collections.Generic;

namespace delegateTest
{
    class Program   //任务管理类
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Father[] fathers = new Father[3];
            Father.TestEvent += Task_TestEvent;
            for (int i = 0; i < 3; i++)
            {
                Father task = new Task();//管理类  注册
                fathers[i] = task;
            }

            //task.TestEvent += Task_TestEvent;
            for (int i = 0; i < 3; i++)
            {
                fathers[i].Call();
            }
           
            Console.ReadLine();

        }

        private static void Task_TestEvent(string msg)
        {
            Console.WriteLine("任务管理类：" + msg);
        }
    }

    public delegate void TestEventHandler(string msg);
    interface Father
    {
        static event TestEventHandler TestEvent;//父类定义事件
        void Call();
    }

    //人物类
    public class Task : Father
    {
        public event TestEventHandler TestEvent;

        public void Call()
        {
            Console.WriteLine("触发事件");
            TestEvent?.Invoke("触发事件");//子类触发
        }
    }

 
  

}
