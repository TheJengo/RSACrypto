using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSACrypto
{
    public abstract class RSA
    {
        public int p { get; set; }
        public int q { get; set; }
        protected int PublicKey { get; set; }
        protected int PrivateKey { get; set; }
        protected int Word { get; set; }
        public string HataMesaji { get; set; }
        public RSA()
        {

        }
        public RSA(int p, int q, int PublicKey, int Word)
        {
            this.p = p;
            this.q = q;
            if(isPrime(this.p) != 1 && isPrime(this.q) != 1)
            {
                HataMesaji = "Girdiğiniz Sayilar Geçerli Asal sayilar değildir."
            }else{
                this.PublicKey = PublicKey;
                this.PrivateKey = (p-1)*(q-1);
                if (GCD(PublicKey,PrivateKey) == 1)
                {
                    PrivateKey += ExtendedEuclid(PublicKey, PrivateKey);
                }
                this.Word = Word;
            }
        }
        protected int isPrime(int p)
        {   
            int i;
            for (i = 2; i < p; i++)
            {
                if( p % i == 0)
                {
                    return 0;
                }
            }
                return 1;
        }
        protected int GCD(int a, int b)
        {
            while(a != b)
            {
                if (a > b)
                 a = a - b;
                if (b > a)
                 b = b - a;
            }
            return a;
        }
        protected int ExtendedEuclid(int e, int d)
        {
            int[] x = { 1, 0, d };
            int[] y = { 0, 1, e };
            int[] t = { 0, 0, 0 };
            int q=0,i=1;
            do
            {
                if (i == 1)
                {
                    q = x[2] / y[2];
                    for (int j = 0; j < 3;j++ )
                    {
                        t[j] = x[j] - (q * y[j]);
                    }
                }
                else
                {
                    for (int j = 0; j < 3; j++)
                    {
                        x[j] = y[j];
                        y[j] = t[j];
                    }
                    q = x[2] / y[2];
                    for (int j = 0; j < 3; j++)
                    {
                        t[j] = x[j] - (q * y[j]);
                    }
                }
                i++;
                if (y[2] == 0)
                {
                    return 0;
                }
            } while (y[2] != 1);
            
            return y[1];
        }
        public int[] ToBinary(int a)
        {
            int digit = 1;
            int temp = a;
            while(temp != 1)
            {
                temp = temp / 2 ;
                digit++;
            }
            int[] arr = new int[digit];           
            for(int i = 0 ; i < digit ; i++  )
            {
                arr[i] = a % 2;
                a = a / 2;
            }
            return arr;
        }
        public int Respond(int Key, int p, int q, int Word)
        {
            // Modular Aritmetic Power!!!
            int[] arr = ToBinary(Key);
            double x = 1;
            double m = p * q;
            double temp = Word;
            double power = Math.Pow(temp, 2) % m;
            if (arr[0] == 1)
            {
                power = temp % m;
            }
            foreach (int i in arr)
            {
                if (i == 1)
                {
                    x = (x * power) % m;
                    power = Math.Pow(temp, 2) % m;
                    temp = power;
                }
                else
                {
                    power = Math.Pow(temp, 2) % m;
                    temp = power;
                }
            }
            return Convert.ToInt32(x);
        }
        public abstract int RSAOutput();
    }
}
