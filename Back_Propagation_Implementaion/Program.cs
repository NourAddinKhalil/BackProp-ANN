using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Back_Propagation_Implementaion
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BackPropagation());

            //LastShotBackProp lastShot = new LastShotBackProp(new int[] { 2, 2, 1 });

            //for (int i = 0; i < 500000; i++)
            //{
            //    lastShot.FeedForward(new float[] { 0, 0 });
            //    lastShot.BackProp(new float[] { 0 });

            //    lastShot.FeedForward(new float[] { 0, 1 });
            //    lastShot.BackProp(new float[] { 1 });

            //    lastShot.FeedForward(new float[] { 1, 0 });
            //    lastShot.BackProp(new float[] { 1 });

            //    lastShot.FeedForward(new float[] { 1, 1 });
            //    lastShot.BackProp(new float[] { 0 });
            //}
            //Console.WriteLine(lastShot.FeedForward(new float[] { 0, 0 })[0]);
            //Console.WriteLine(lastShot.FeedForward(new float[] { 0, 1 })[0]);
            //Console.WriteLine(lastShot.FeedForward(new float[] { 1, 0 })[0]);
            //Console.WriteLine(lastShot.FeedForward(new float[] { 1, 1 })[0]);

            //Console.ReadKey();
        }
    }
}
