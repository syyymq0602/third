using System;

namespace _2020201649_gz
{
    class Program
    {
        //  选用SS1、SS3、SS4车型
        static void Main(string[] args)
        {
            Console.WriteLine("请输入坡道角度（‰）：");
            // 定义下坡角度（‰）
            int angle = Convert.ToInt32(Console.ReadLine())*(-1);
            // 定义下坡距离（m）
            Console.WriteLine("请输入下坡距离（m）：");
            double S = Convert.ToDouble(Console.ReadLine());
            // 定义限速（km/h）
            Console.WriteLine("请输入线路限速（km/h）：");
            double V_lim = Convert.ToDouble(Console.ReadLine());
            // 定义重力加速度
            const double G = 9.81;
            // 单一下坡坡道附加阻力为角度值
            double g = angle;
            // 定义计算初始条件
            double V = V_lim;
            double X = 0;
            double t = 0;
            // 定义计算时间间隔（由于计算精度会丢失，不适合太小）
            const double dt = 0.1;
            while(X<S)
            {
                double A = -(-SS1(V) - g) * G / 1000;
                X = X + V / 3.6 * dt + 0.5 * A * Math.Sqrt(dt);  //速度单位为km/h
                t = t + dt;
                V = V + 3.6 * A * dt;
                if (V<0)
                {
                    Console.WriteLine("error!");
                    break;
                }
            }
            if (V >= 0)
            {
                Console.WriteLine();
                Console.WriteLine("限速 {0}km/h ，单一下坡距离为 {1}m 的进坡特征速度为{2:N3}km/h。", V_lim, S, V);
            }

            // Console.WriteLine(t);
        }
        // 选用SS1、SS3、SS4车型计算
        public static double SS1(double speed)
        {
            var res = 2.25 + 0.019 * speed + 0.00032 * Math.Sqrt(speed);
            return res;
        }
    }
}
