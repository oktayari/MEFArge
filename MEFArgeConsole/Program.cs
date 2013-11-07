using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace MEFArgeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.StartTest();
            Console.ReadLine();
        }

        private void StartTest()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var compositionContainer = new CompositionContainer(assemblyCatalog);
            var arac = new Arac();
            compositionContainer.ComposeParts(arac);
            arac.Sur();
        }
    }


    internal class Arac
    {
        [Import]
        private Motor _motor;

        [Import]
        private Fren _fren;

        [Import] private Gaz _gaz;

        [Import]
        private Vites _vites;

        [Import]
        private Direksiyon _direksiyon;

        public Arac()
        {
            Console.WriteLine("Arac olusturuluyor");
        }

        public void Sur()
        {
            _motor.Calistir();
            _vites.Artir();
            _gaz.GazaBas();
            _vites.Artir();
            _gaz.GazaBas();
            _fren.Frenle();
            _vites.Azalt();
            _direksiyon.SolaDon();
            _direksiyon.Topla();
            _vites.Artir();
            _gaz.GazaBas();
            _direksiyon.SagaDon();
            _fren.Frenle();
            _direksiyon.Topla();
            _vites.Artir();
            _gaz.GazaBas();
            _vites.Azalt();
            _fren.Frenle();
            _vites.BosaAl();
            _motor.Durdur();
        }

    }

    
    [Export]
    internal class Motor
    {
        public void Calistir()
        {
            Console.WriteLine("motor calisiyor");
        }

        public void Durdur()
        {
            Console.WriteLine("motor stop edildi");
        }
    }


    [Export]
    internal class Fren
    {
        public void Frenle()
        {
            Console.WriteLine("frenliyorum");
        }
     }


    [Export]
    internal class Gaz
    {
        public void GazaBas()
        {
            Console.WriteLine("Hizlaniyorum");
        }
    }


    [Export]
    internal class Vites
    {
        private int _vitesNo;
        public Vites()
        {
            _vitesNo = 0;
            Console.WriteLine("vites bosta");
        }

        public void BosaAl()
        {
            Console.WriteLine("Vites Bosa aliniyor");
            _vitesNo = 0;
        }

        public void Artir()
        {
            _vitesNo++;
            Console.WriteLine("Vites = " +_vitesNo);
        }

        public void Azalt()
        {
            _vitesNo--;
            Console.WriteLine("Vites = " + _vitesNo);
        }

    }


    [Export]
    internal class Direksiyon
    {
        
        public void Topla()
        {
            Console.WriteLine("Direksiyon toplaniyor");
        }

        public void SolaDon()
        {
            Console.WriteLine("Sola Donuyorum");
        }

        public void SagaDon()
        {
            Console.WriteLine("Saga Donuyorum");
        }

        
    }
}
