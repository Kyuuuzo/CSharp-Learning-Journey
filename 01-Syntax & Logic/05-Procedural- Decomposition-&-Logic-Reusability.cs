/*
 * =======================================================================
 * PROJECT  : CSharp-Learning-Journey
 * TOPIC    : Procedural Decomposition & Logic Reusability
 * MODULE   : 01-Basic
 * AUTHOR   : Kyuuuzo
 * DATE     : 16 Maret 2026
 * * DESCRIPTION:
 * Modul ini mendemonstrasikan implementasi Method (Function) sebagai unit
 * logika independen untuk meningkatkan skalabilitas kode. Fokus utama
 * mencakup penggunaan 'private static' untuk enkapsulasi level class,
 * mekanisme 'Return Value' untuk ekstraksi data (Name), serta penggunaan
 * 'Parameters' (Line) untuk abstraksi visual. Modul ini juga menerapkan
 * Defensive Programming melalui metode 'Warn' guna memastikan integritas
 * input numerik pada runtime.
 * =======================================================================
 */

using System;

class Method
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine(Line("░▒▓", 8));
        Console.WriteLine("Info Player");
        Console.WriteLine(Line("░▒▓", 8));
        string namePlayer = Name();

        Console.Clear();
        Console.WriteLine("=== Data Kesimpan! ===");
        Console.WriteLine($"Nama Player: {namePlayer}");
        Console.WriteLine(Line("==--==", 8));
        Console.WriteLine("Tugas Selesai. Tekan apa saja untuk keluar.");
        Console.ReadKey();
    }

    private static string Name()
    {
        Console.Clear();
        Console.WriteLine("\nWah, belum masukkin nama nih?\n");
        Console.WriteLine("Masukkan Nama kamu!\n");
        string name = Console.ReadLine();
        while (string.IsNullOrEmpty(name) || name.Length > 24)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("\nParah, masa ga ada nama? Tulis lagi!:    ");
                name = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nNamanya kepanjangan! Masukkin lagi:  ");
                name = Console.ReadLine();
            }
        }
        Console.Clear();
        Console.WriteLine($"Okey. Met datang, {name}! Tekan ENTER untuk lanjut.");
        Console.ReadKey();

        return name;
    }

    private static int Warn() //Ini memang tidak dipakai, tapi saya selalu persiapkan pada setiap kode.
    {
        Console.WriteLine("\nPilih!:   ");
        string input = Console.ReadLine();
        int control;
        while (!int.TryParse(input, out control))
        {
            Console.WriteLine("\nAduh. Input salah! Mohon ulangi: ");
            input = Console.ReadLine();
        }
        return control;
    }

    private static string Line(string type, int length)
    {
        string line = "";
        for (int x = 0; x < length; x++)
        {
            line += type;
        }
        return line;
    }
}
